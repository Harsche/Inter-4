using UnityEngine;

public class DestroyIfNotOnDay : MonoBehaviour
{
    [SerializeField] private int day;

    private void Awake() {
        if(DialogManager.GameDay != day)
            Destroy(gameObject);
    }
}
