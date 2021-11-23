using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using CleverCrow.Fluid.UniqueIds;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private CharactersSOData charactersSOData;
    [SerializeField] private CharacterList characterList;
    public List<GameObject> currentCharacters { get; private set; } = new List<GameObject>();
    public static CharacterManager Instance;
    private string myGuid;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        myGuid = GetComponent<UniqueId>().Id;
        CharacterData characterData = SaveManager.GetData<CharacterData>(myGuid);
        if (characterData != null)
            charactersSOData.characterInformation = characterData.characterInformation;
        for (int i = 0; i < characterList.characters.Length; i++)
        {
            charactersSOData.characterInformation[i].character = characterList.characters[i];
        }
        SceneManager.sceneLoaded += SpawnSceneCharacters;
        SaveManager.SaveAllData += SaveCharacterData;
    }

    public void PlaceCharacters(CharacterInformation[] information)
    {
        foreach (CharacterInformation newInformation in information)
        {
            foreach (CharacterInformation currentInformation in charactersSOData.characterInformation)
            {
                if (newInformation.character.name == currentInformation.character.name)
                {
                    currentInformation.presentScene = newInformation.presentScene;
                    currentInformation.characterPosition = newInformation.characterPosition;
                }
            }
        }
    }

    private void SpawnSceneCharacters(Scene scene, LoadSceneMode mode)
    {
        currentCharacters.Clear();
        CharacterInformation[] presentCharacters = charactersSOData.characterInformation
            .Where(charInfo => charInfo.presentScene == scene.name)
            .ToArray();
        foreach (CharacterInformation characterInformation in presentCharacters)
        {
            GameObject character = characterInformation.character;
            Vector2 position = characterInformation.characterPosition;
            GameObject spawnedCharacter = Instantiate(character, position, Quaternion.identity);
            currentCharacters.Add(spawnedCharacter);
        }
    }

    private void SaveCharacterData()
    {
        CharacterData characterData = new CharacterData();
        characterData.characterInformation = charactersSOData.characterInformation;
        SaveManager.SaveData(myGuid, characterData);
    }
}

public class CharacterData : ObjectData
{
    public CharacterInformation[] characterInformation;
}