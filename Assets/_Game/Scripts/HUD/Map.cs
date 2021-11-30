using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    [SerializeField] private Canvas CanvasHUD;
    [SerializeField] private Vector2 axisX;
    [SerializeField] private Vector2 axisY;
    [SerializeField] private Image luizHead;

    public void ShowPositionOnMap()
    {

    }

    private Vector2 RemapPosition(Vector2 position)
    {
        return Vector2.zero;
    }

    private float RemapValue(float value, Vector2 axis)
    {
        return 0;
    }
}
