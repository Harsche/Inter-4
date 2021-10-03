using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TriggerSceneChange : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private Vector2 newPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Globals.SceneChanger.ChangeScene(sceneName, newPosition);
        }
    }
}
