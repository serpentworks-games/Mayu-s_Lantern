using UnityEngine;
using System.Collections;

public class ParticleSystemReaction : DelayedReaction
{
    public ParticleSystem particleSystem;

    protected override void ImmediateReaction()
    {
        PlayParticleSystem();
    }

    void PlayParticleSystem()
    {
        if (!particleSystem.isPlaying)
        {
            particleSystem.Play();
        }
        
    }
}
