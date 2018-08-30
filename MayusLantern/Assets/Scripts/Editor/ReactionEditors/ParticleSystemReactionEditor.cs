using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ParticleSystemReaction))]
public class ParticleSystemReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Particle System Reaction";
    }
}