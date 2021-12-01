using UnityEngine;
using System.Linq;

public class Tutorials : MonoBehaviour
{
    [SerializeField] private Tutorial[] tutorials;
    public static Tutorials Instance { get; private set; }
    private Canvas myCanvas;
    public bool showingTutorial { get; private set; }

    private void Awake() {
        if(Instance != null)
            return;
        Instance = this;
        myCanvas = GetComponent<Canvas>();
    }

    public void ShowTutorial(TutorialType type)
    {
        Tutorial tutorial = tutorials.First(tutorial => tutorial.tutorialType == type);
        GameObject tutorialObject = tutorial.tutorial;
        tutorialObject.SetActive(true);
        myCanvas.enabled = true;
        showingTutorial = true;
    }

    public void CloseTutorials()
    {
        myCanvas.enabled = false;
        foreach(Tutorial tutorial in tutorials)
        {
            tutorial.tutorial.SetActive(false);
        }
        showingTutorial = false;
    }
}

[System.Serializable]
public class Tutorial
{
    public TutorialType tutorialType;
    public GameObject tutorial;
}

[System.Serializable]
public enum TutorialType
{
    Milk,
    Wood,
    Well,
    Chicken
}