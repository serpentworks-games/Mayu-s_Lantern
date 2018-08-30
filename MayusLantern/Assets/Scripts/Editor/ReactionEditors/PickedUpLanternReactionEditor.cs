using UnityEditor;

[CustomEditor(typeof(PickedUpLanternReaction))]
public class PickedUpLanternReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Pick Up Lantern Reaction";
    }
}
