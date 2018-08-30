using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TextReaction))]
public class TextReactionEditor : ReactionEditor
{

    private SerializedProperty isNPCProperty;
    private SerializedProperty npcNameProperty;
    private SerializedProperty messageProperty;


    private const string isNPCPropertyName = "isNPC";
    private const string npcNamePropertyName = "npcName";
    private const string textReactionPropMessageName = "interactableText";



    protected override void Init()
    {
        isNPCProperty = serializedObject.FindProperty(isNPCPropertyName);
        npcNameProperty = serializedObject.FindProperty(npcNamePropertyName);
        messageProperty = serializedObject.FindProperty(textReactionPropMessageName);

    }


    protected override void DrawReaction()
    {
        EditorGUILayout.PropertyField(isNPCProperty, new GUIContent("Is NPC?"));

        EditorGUILayout.PropertyField(npcNameProperty, new GUIContent("NPC Name"));

        EditorGUILayout.PropertyField(messageProperty, new GUIContent("Dialogue/Text"));
        EditorStyles.textField.wordWrap = true;

    }


    protected override string GetFoldoutLabel()
    {
        return "Dialogue Reaction";
    }
}