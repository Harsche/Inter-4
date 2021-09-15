using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private GameObject dialogCanvas;

    public void StartDialog()
    {
        dialogCanvas.SetActive(true);
    }
}
