using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    
    [SerializeField] private RectTransform iconPosition;
    [SerializeField] private RectTransform mapArea;
    [SerializeField] private Vector2 gameX;
    [SerializeField] private Vector2 gameY;
    [SerializeField] private Image luizHead;
    private Rect areaRect;
    private Vector2 mapX;
    private Vector2 mapY;
    

    private void Awake() {
        areaRect = mapArea.rect;
        mapX = new Vector2(areaRect.xMin, areaRect.xMax);
        mapY = new Vector2(areaRect.yMin, areaRect.yMax);
    }

    private void OnEnable() {
        ShowPositionOnMap();
    }

    public void ShowPositionOnMap()
    {
        Vector2 playerPosition = Globals.Player.transform.position;
        iconPosition.anchoredPosition = RemapPosition(playerPosition);
    }

    private Vector2 RemapPosition(Vector2 position)
    {
        float x, y;
        x = RemapValue(position.x, gameX, mapX);
        y = RemapValue(position.y, gameY, mapY);
        return new Vector2(x, y);
    }

    private float RemapValue(float value, Vector2 axisFrom, Vector2 axisTo)
    {
        float result, percentage;
        percentage = (value - axisFrom.x) / (axisFrom.y - axisFrom.x);
        result = percentage * (axisTo.y - axisTo.x) + axisTo.x;
        return result;
    }
}
