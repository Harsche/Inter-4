using UnityEngine;
using UnityEngine.Playables;
using CleverCrow.Fluid.UniqueIds;
using Ink.Runtime;

public class House : MonoBehaviour
{
    [SerializeField] private GameObject openedHouse;
    [SerializeField] private GameObject closedHouse;
    private bool changedDay;
    private string myGuid;
    private HouseData houseData;

    private void Awake()
    {
        myGuid = GetComponent<UniqueId>().Id;
        houseData = SaveManager.GetData<HouseData>(myGuid);
        if (houseData == null)
            houseData = new HouseData();
        if (!houseData.opened)
        {
            CloseDoor();
            return;
        }
        OpenDoor();
        changedDay = (bool)Globals.DialogManager.story.variablesState["changedDay"];
        if(changedDay)
            CloseDoor();
    }

    private void Start() {
        if(changedDay)
            Globals.DialogManager.story.variablesState["changedDay"] = false;
    }

    public void OpenDoor()
    {
        openedHouse.SetActive(true);
        closedHouse.SetActive(false);
        houseData.opened = true;
        SaveMyData();
    }

    public void CloseDoor()
    {
        closedHouse.SetActive(true);
        openedHouse.SetActive(false);
        houseData.opened = false;
        SaveMyData();
    }

    public void StartCutsceneInteraction(PlayableDirector director)
    {
        director.Play();
    }

    public void SaveMyData()
    {
        SaveManager.SaveData(myGuid, houseData);
    }
}

public class HouseData : ObjectData
{
    public bool opened { get; set; }
    public bool changedDay { get; set; }
}