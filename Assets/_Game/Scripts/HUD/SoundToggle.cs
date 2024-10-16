using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Toggle toggle;
    private bool isActive;
    private const string prefsKey = "SoundToggle";
    private const string mixerKey = "SoundVolume";
    
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