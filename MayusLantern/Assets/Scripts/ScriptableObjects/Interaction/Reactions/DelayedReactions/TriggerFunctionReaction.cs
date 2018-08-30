using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using Sirenix.OdinInspector;

public enum VariableTypes
{
    Float,
    Int,
    Bool,
    String,
}
public class TriggerFunctionReaction : DelayedReaction {

    public string functionName;
    public VariableTypes variableTypes;

    [ShowIf("variableTypes", VariableTypes.Float)]
    public float floatValue;
    [ShowIf("variableTypes", VariableTypes.Int)]
    public int intValue;
    [ShowIf("variableTypes", VariableTypes.Bool)]
    public bool boolValue;
    [ShowIf("variableTypes", VariableTypes.String)]
    public string stringValue;

    PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    protected override void ImmediateReaction()
    {

        MethodInfo functionToCall = player.GetType().GetMethod(functionName);
        switch (variableTypes)
        {
            case VariableTypes.Float:
                functionToCall.Invoke(player, new object[] { floatValue });
                break;
            case VariableTypes.Int:
                functionToCall.Invoke(player, new object[] { intValue });
                break;
            case VariableTypes.Bool:
                functionToCall.Invoke(player, new object[] { boolValue });
                break;
            case VariableTypes.String:
                functionToCall.Invoke(player, new object[] { stringValue });
                break;
            default:
                break;
        }
        
    }

 
}
