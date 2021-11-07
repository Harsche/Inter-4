using UnityEngine;

public abstract class ObjectData : MonoBehaviour
{
    public string ID { get; private set; }

    public ObjectData()
    {
        ID = transform.position.magnitude + name;
    }
}
