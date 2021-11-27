using UnityEngine;

public class CowDead : MonoBehaviour
{
    private void Awake() {
        Animator myAnimator = GetComponent<Animator>();
        myAnimator.SetTrigger("Dead");
    }
}
