using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static GameObject PlayerCamera;

    private void Awake()
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
}
