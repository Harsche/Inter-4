using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string characterName;
    [SerializeField] private TextAsset dialogs;


    public string CharacterName
    {
        get { return characterName; }
    }

}
