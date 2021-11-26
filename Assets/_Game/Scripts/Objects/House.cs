using UnityEngine;
using UnityEngine.Playables;
using CleverCrow.Fluid.UniqueIds;

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
        changedDay = (bool)Globals.DialogManager.story.variablesState["changedDay"];
        if (changedDay && DialogManager.GameDay >= 2)
            houseData.opened = !(bool)Globals.DialogManager.story.variablesState["changedDay"];
        if (!houseData.opened)
        {
            CloseDoor();
            return;
        }
        OpenDoor();
    }

    private void Start()
    {
        if (changedDay)
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
}