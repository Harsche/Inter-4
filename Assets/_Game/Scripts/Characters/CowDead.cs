using UnityEngine;
using System.Collections;

public class CowDead : MonoBehaviour
{
    private const string deadKnot = "Seu_Joao_Day_03.Cow_Died";

    private void Awake()
    {
        bool alreadyDead = Globals.DialogManager.story.state.VisitCountAtPathString(deadKnot) > 0;
        if (alreadyDead)
            Destroy(gameObject);
        StartCoroutine(CheckIfDead());
        Animator myAnimator = GetComponent<Animator>();
        myAnimator.SetTrigger("Dead");
    }

    private IEnumerator CheckIfDead()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            bool alreadyDead = Globals.DialogManager.story.state.VisitCountAtPathString(deadKnot) > 0;
            if (alreadyDead)
                Destroy(gameObject);
        }
    }
}
