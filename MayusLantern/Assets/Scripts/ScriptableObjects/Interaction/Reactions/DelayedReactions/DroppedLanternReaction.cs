using UnityEngine;

public class DroppedLanternReaction : DelayedReaction
{
    public GameObject placementLocation;

    PlayerController pMovmement;

    protected override void SpecificInit()
    {
        pMovmement = FindObjectOfType<PlayerController>();
    }


    protected override void ImmediateReaction()
    {
        pMovmement.DropLantern(placementLocation);
    }
}
