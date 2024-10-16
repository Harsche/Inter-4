using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Toggle toggle;
    private const string prefsKey = "MusicToggle";
    private const string mixerKey = "MusicVolume";
    private bool isActive;

    private void Start(){
        isActive = PlayerPrefs.HasKey(prefsKey)
            ? Convert.ToBoolean(PlayerPrefs.GetInt(prefsKey))
            : true;
        audioMixer.SetFloat(mixerKey, isActive ? 0 : -80);
        toggle.SetIsOnWithoutNotify(isActive);
    }

    public void Toggle(){
        isActive = !isActive;
        audioMixer.SetFloat(mixerKey, isActive ? 0 : -80);
        PlayerPrefs.SetInt(prefsKey, Convert.ToInt32(isActive));
    }
}