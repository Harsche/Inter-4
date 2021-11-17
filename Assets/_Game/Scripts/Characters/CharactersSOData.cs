using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
[CreateAssetMenu(menuName = "ScriptableObjects/Character Information")]
public class CharactersSOData : ScriptableObject
{
    public CharacterInformation[] characterInformation;

    [ContextMenu("Reset characters")]
    public void ResetCharacters()
    {
        foreach(CharacterInformation information in characterInformation)
        {
            information.presentScene = "";
        }
    }
}

[System.Serializable]
public class CharacterInformation
{
    public string presentScene;
    [JsonIgnore] public GameObject character;
    public Vector2 characterPosition;
}
