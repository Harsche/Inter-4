using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    public void CameraFollowPlayer()
    {
        virtualCamera.m_Follow = Globals.Player.transform;
    }

    public void CameraFollowNull()
    {
        virtualCamera.m_Follow = null;
    }
}
