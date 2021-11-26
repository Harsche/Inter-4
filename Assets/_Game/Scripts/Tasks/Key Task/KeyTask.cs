using UnityEngine;

public class KeyTask : MonoBehaviour
{
    [SerializeField] private CharacterInformation ciceraPlace;
    [SerializeField] private House donaCiceraHouse;
    private bool ciceraFoundKey;

    private void Awake()
    {
        ciceraFoundKey = (bool)Globals.DialogManager.story.variablesState["ciceraFoundKey"];
        if(Globals.CutsceneManager.WasPlayedOrCantPlay("Cutscene_09"))
            Destroy(gameObject);
        if (!ciceraFoundKey)
        {
            return;
        }
        CharacterManager.Instance.PlaceCharacters(new CharacterInformation[] { ciceraPlace });
        donaCiceraHouse.OpenDoor();
        Destroy(gameObject);
    }
}
