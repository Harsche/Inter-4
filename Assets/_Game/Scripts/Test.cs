using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject obj;

    void Start()
    {
        Debug.Log(prefab == obj);
    }
}
