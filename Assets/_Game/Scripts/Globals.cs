using UnityEngine;

public class Globals : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject dialogCanvas;

    public static GameObject Player;
    public static GameObject DialogCanvas;

    private void Start()
    {
        Application.targetFrameRate = 60;
        Player = player;
        DialogCanvas = dialogCanvas;
    }

}
