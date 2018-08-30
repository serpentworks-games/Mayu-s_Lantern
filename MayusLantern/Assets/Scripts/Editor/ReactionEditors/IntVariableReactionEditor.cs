using UnityEditor;

[CustomEditor(typeof(IntVariableReaction))]
public class IntVariableReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Add To Int Variable Reaction";
    }
}
