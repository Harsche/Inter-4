using UnityEngine;
using UnityEngine.SceneManagement;

public class StepSound : MonoBehaviour{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] insideFootsteps;
    [SerializeField, Range(0, 1)] private float insideFootstepsVolume = 1;
    [SerializeField] private AudioClip[] outsideFootsteps;
    [SerializeField, Range(0, 1)] private float outsideFootstepsVolume = 1;

    public void PlayFootstep(){
        bool isInside = SceneManager.GetActiveScene().name.Contains("House");
        AudioClip[] footsteps = isInside ? insideFootsteps : outsideFootsteps;
        float volume = isInside ? insideFootstepsVolume : outsideFootstepsVolume;
        AudioClip clip = footsteps[Random.Range(0, footsteps.Length)];
        audioSource.PlayOneShot(clip, volume);
    }
}