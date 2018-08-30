using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntVariableReaction : DelayedReaction
{
    public string variableName;
    public int amountToAdd;
    PlayerController pController;

    private void Awake()
    {
        pController = FindObjectOfType<PlayerController>();
    }
    protected override void ImmediateReaction()
    {
        int variableToChange = (int)pController.GetType().GetField(variableName).GetValue(pController);
        variableToChange += amountToAdd;
    }
}
