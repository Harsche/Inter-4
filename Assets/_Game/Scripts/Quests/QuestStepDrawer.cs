using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(QuestStep))]
public class QuestStepDrawer : PropertyDrawer
{
    bool foldout = false;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        //Propriedades a serem editadas
        SerializedProperty goal = property.FindPropertyRelative("goal");

        //Setup do editor
        //position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        foldout = EditorGUI.Foldout(position, foldout, label);

        if (foldout)
        {
            int indent = EditorGUI.indentLevel;
            indent = 0;

            Rect goalRect = new Rect(position.x + EditorGUIUtility.singleLineHeight, position.y, position.width, EditorGUIUtility.singleLineHeight);

            EditorGUI.PropertyField(goalRect, goal, new GUIContent("Goal"));

            EditorGUI.indentLevel = indent;

        }

        EditorGUI.EndProperty();
        
    }
}