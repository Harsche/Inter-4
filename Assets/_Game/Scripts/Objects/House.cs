using UnityEngine;
using UnityEngine.Playables;

public class House : MonoBehaviour
{
    [SerializeField] private GameObject openedHouse;
    [SerializeField] private GameObject closedHouse;
    [SerializeField] private string openedSaveValue;
    private HouseData houseData;
    
    private SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        houseData = new HouseData();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        opened = Globals.SaveManager.GetValue<bool>(openedSaveValue);
        if (!opened)
        {
            CloseDoor();
            return;
        }
        OpenDoor();
    }

    public void OpenDoor()
    {
        openedHouse.SetActive(true);
        closedHouse.SetActive(false);
        Globals.SaveManager.SetValue<bool>(openedSaveValue, true);
    }

    public void CloseDoor()
    {
        closedHouse.SetActive(true);
        openedHouse.SetActive(false);
        Globals.SaveManager.SetValue<bool>(openedSaveValue, false);
    }

    public void StartCutsceneInteraction(PlayableDirector director)
    {
        director.Play();
    }
}

public class HouseData : ObjectData
{
    public bool opened { get; set; }
    public HouseData() : base() {}
}