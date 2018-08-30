using UnityEngine;

public class PickedUpLanternReaction : DelayedReaction
{
    public GameObject lantern;

    PlayerController pMovmement;


    protected override void SpecificInit()
    {
        pMovmement = FindObjectOfType<PlayerController>();
    }


    protected override void ImmediateReaction()
    {
        pMovmement.PickUpLantern(lantern);
    }
}
