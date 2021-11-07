using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource myAudioSource;
    private bool musicVolume;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip music, bool loop)
    {
        if (!musicVolume) return;
        if (loop)
        {
            myAudioSource.Play();
            return;
        }
        myAudioSource.PlayOneShot(music);
    }

    public void ToggleMusicVolume(bool onOrOff)
    {
        musicVolume = onOrOff;
    }
}
