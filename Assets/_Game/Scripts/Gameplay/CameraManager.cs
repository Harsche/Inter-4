using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static GameObject PlayerCamera;

    private void Awake()
    {
        if (PlayerCamera != null)
        {
            Destroy(gameObject);
            return;
        }
        PlayerCamera = gameObject;
    }
}
