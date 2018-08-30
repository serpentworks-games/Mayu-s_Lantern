using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour
{
    //States
    [HideInInspector] public int movementState;
    [HideInInspector] public int dyingState;

    //Ints
    [HideInInspector] public int idleIndexInt;

    //Floats
    [HideInInspector] public int speedFloat;

    //Bools
    [HideInInspector] public int playerInSightBool;
    [HideInInspector] public int openBool;
    [HideInInspector] public int sneakingBool;
    [HideInInspector] public int hasLanternBool;
    [HideInInspector] public int deadBool;

    //Triggers

    private void Awake()
    {
        //States
        dyingState = Animator.StringToHash("Base Layer.Death");
        movementState = Animator.StringToHash("Base Layer.Movement");

        //Ints
        idleIndexInt = Animator.StringToHash("idleIndex");

        //Floats
        speedFloat = Animator.StringToHash("speed");

        //Bools
        playerInSightBool = Animator.StringToHash("playerInSight");
        openBool = Animator.StringToHash("open");
        sneakingBool = Animator.StringToHash("sneaking");
        hasLanternBool = Animator.StringToHash("hasLantern");
        deadBool = Animator.StringToHash("isDead");

    }
}
