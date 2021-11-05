using UnityEngine;
using UnityEngine.Playables;

public class House : MonoBehaviour
{
    [SerializeField] private GameObject openedHouse;
    [SerializeField] private GameObject closedHouse;
    private SpriteRenderer mySpriteRenderer;
    
    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OpenDoor()
    {
        openedHouse.SetActive(true);
        closedHouse.SetActive(false);
    }

    public void CloseDoor()
    {
        closedHouse.SetActive(true);
        openedHouse.SetActive(false);
    }

    public void StartCutsceneInteraction(PlayableDirector director)
    {
        director.Play();
    }
}
