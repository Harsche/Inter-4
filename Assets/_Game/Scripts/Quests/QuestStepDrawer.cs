using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(QuestStep))]
public class QuestStepDrawer : PropertyDrawer
{
    float layoutSpace = 2.5f;
    Rect goalRect;
    Rect questTypeRect;
    Rect goalNameRect;
    Rect currentNumRect;
    Rect goalNumRect;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        //Propriedades a serem editadas
        SerializedProperty goal = property.FindPropertyRelative("goal");
        SerializedProperty questType = property.FindPropertyRelative("questType");
        SerializedProperty goalName = property.FindPropertyRelative("goalName");
        SerializedProperty currentNum = property.FindPropertyRelative("currentNum");
        SerializedProperty goalNum = property.FindPropertyRelative("goalNum");

        //Setup do editor

        EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect fullRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        property.isExpanded = EditorGUI.Foldout(fullRect, property.isExpanded, GUIContent.none);

        if (property.isExpanded)
        {
            goalRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 1, position.width, EditorGUIUtility.singleLineHeight * 2);
            EditorGUI.TextField(goalRect, new GUIContent("Goal"), goal.stringValue);
            questTypeRect = new Rect(position.x, NextRectPosition(goalRect), position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(questTypeRect, questType, new GUIContent("Quest Type"));

            switch ((QuestType)questType.enumValueIndex)
            {
                case QuestType.TalkTo:
                    goalNameRect = new Rect(position.x, NextRectPosition(questTypeRect), position.width, EditorGUIUtility.singleLineHeight);
                    EditorGUI.PropertyField(goalNameRect, goalName, new GUIContent("Goal Name"));
                    break;

                case QuestType.NumberedTask:
                    currentNumRect = new Rect(position.x, NextRectPosition(questTypeRect), position.width, EditorGUIUtility.singleLineHeight);
                    EditorGUI.PropertyField(currentNumRect, currentNum, new GUIContent("Current Number"));
                    goalNumRect = new Rect(position.x, NextRectPosition(currentNumRect), position.width, EditorGUIUtility.singleLineHeight);
                    EditorGUI.PropertyField(goalNumRect, goalNum, new GUIContent("Goal Number"));
                    break;

            }
        }

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        SerializedProperty questType = property.FindPropertyRelative("questType");

        if (!property.isExpanded)
        {
            return EditorGUIUtility.singleLineHeight;
        }
        else
        {
            int spaceBetween = 0;
            float space = EditorGUIUtility.singleLineHeight;
            space += goalRect.height;
            spaceBetween++;
            space += questTypeRect.height;
            spaceBetween++;

            switch ((QuestType)questType.enumValueIndex)
            {
                case QuestType.TalkTo:
                    space += goalNameRect.height;
                    spaceBetween++;
                    break;

                case QuestType.NumberedTask:
                    space += currentNumRect.height;
                    spaceBetween++;
                    space += goalNameRect.height;
                    spaceBetween++;
                    break;
            }

            space += layoutSpace * spaceBetween;
            return space;
        }
    }

    private float NextRectPosition(Rect prevRect)
    {
        float y = prevRect.position.y + prevRect.height + layoutSpace;
        return y;
    }

}