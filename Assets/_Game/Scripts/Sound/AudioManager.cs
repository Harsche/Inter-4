using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip music;
    [SerializeField] private AudioClip sounds;
    private bool musicVolume;
    private bool soundVolume;

    private void Awake()
    {
    }

    public void ToggleMusicVolume(bool onOrOff)
    {
        musicVolume = onOrOff;
    }
}
