using UnityEngine;

public class AudioSourceObjects : MonoBehaviour
{
    [SerializeField] private SoundEffect[] soundEffects;
}

[System.Serializable]
public class SoundEffect
{
    public string audioName;
    public AudioClip audioClip;
}
