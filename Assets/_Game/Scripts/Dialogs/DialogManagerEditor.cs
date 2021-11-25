#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using Ink.UnityIntegration;
using Ink.Runtime;

[CustomEditor(typeof(DialogManager))]
[InitializeOnLoad]
public class DialogManagerEditor : Editor
{
    static DialogManagerEditor () {
        DialogManager.OnCreateStory += OnCreateStory;
    }
    static void OnCreateStory (Story story) {
        InkPlayerWindow window = InkPlayerWindow.GetWindow(true);
        if(window != null) InkPlayerWindow.Attach(story);
    }
    public override void OnInspectorGUI () {
		Repaint();
		base.OnInspectorGUI ();
		var realTarget = target as DialogManager;
		var story = realTarget.story;
		InkPlayerWindow.DrawStoryPropertyField(story, new GUIContent("Story"));
	}
}
#endif