using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneBehaviorController : MonoBehaviour {

    public bool playerInZone;
    public TriggerBehavior[] triggerBehaviors;
    public GameObject player;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            player = other.gameObject;
            DoBehavior(this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            other.GetComponent<PlayerController>().localPlayerData.isHidden = false;
            player = null;
        }
    }

    void DoBehavior(TriggerZoneBehaviorController controller)
    {
        for (int i = 0; i < triggerBehaviors.Length; i++)
        {
            triggerBehaviors[i].Behavior(controller);
        }
    }
}
