using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;

[CustomEditor(typeof(TriggerFunctionReaction))]
public class TriggerFunctionReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Trigger Function On Player";
    }
}