using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CutsceneVirtualCamera : MonoBehaviour
{
    [SerializeField] private bool followPlayer;

    void Start()
    {
        if (followPlayer)
        {
            GetComponent<CinemachineVirtualCamera>().m_Follow = Globals.Player.transform;
        }
    }
}
