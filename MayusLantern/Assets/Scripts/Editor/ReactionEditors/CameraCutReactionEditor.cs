using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraCutReaction))]
public class CameraCutReactionEditor : ReactionEditor
{
     protected override string GetFoldoutLabel()
    {
        return "Cutscene Reaction";
    }
}