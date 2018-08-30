using UnityEditor;

[CustomEditor(typeof(DroppedLanternReaction))]
public class DroppedLanternReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel ()
    {
        return "Drop Lantern Reaction";
    }
}
