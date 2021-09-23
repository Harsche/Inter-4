using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueGameObject : MonoBehaviour
{
    public static GameObject player;
    public static GameObject mainCamera;

    void Awake()
    {
        if (gameObject.CompareTag("Player"))
        {
            if (player == null)
            {
                player = gameObject;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.CompareTag("MainCamera"))
        {
            if (mainCamera == null)
            {
                mainCamera = gameObject;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
