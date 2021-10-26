using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(QuestStep))]
public class QuestStepDrawer : PropertyDrawer
{
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        
        EditorGUI.BeginProperty(position, label, property);

        //Propriedades a serem editadas
        SerializedProperty goal = property.FindPropertyRelative("goal");

        //Setup do editor
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);


        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect goalRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight);

        EditorGUI.PropertyField(goalRect, goal, new GUIContent("Goal"));

        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
        

    }
    
}