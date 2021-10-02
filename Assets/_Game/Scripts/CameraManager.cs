using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    public static GameObject PlayerCamera;

    private void Start()
    {
        if(PlayerCamera == null)
        {
            PlayerCamera = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CameraFollowPlayer()
    {
        virtualCamera.m_Follow = Globals.Player.transform;
    }

    public void CameraFollowNull()
    {
        virtualCamera.m_Follow = null;
    }
}
