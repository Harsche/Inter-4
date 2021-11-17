using UnityEngine;

public class ChangeCharacterInfo : MonoBehaviour
{
    [SerializeField] private CharacterInformation[] characterInformation;

    public void TriggerCharacterChange()
    {
        CharacterManager.Instance.PlaceCharacters(characterInformation);
    }
}
