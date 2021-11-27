using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] bool activate;
    bool active;

    private void Awake() {
        active = false;
    }

    private void Update() {
        if(active != activate)
        {
            active = activate;
            Globals.DialogManager.story.variablesState["chickenTask"] = active;
            Debug.Log(active);
        }
    }
}
