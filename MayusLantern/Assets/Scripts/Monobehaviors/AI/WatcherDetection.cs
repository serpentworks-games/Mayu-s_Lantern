using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;

public class WatcherDetection : MonoBehaviour {

    public bool isSeen;

    BehaviorTree behaviorTree;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
        behaviorTree = GetComponentInParent<BehaviorTree>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            Vector3 relPlayerPos = player.transform.position - transform.position;
            RaycastHit hit;

              if(Physics.Raycast(transform.position, relPlayerPos, out hit))
            {
                if (hit.collider.gameObject == player)
                {
                    var lastPlayerSighting = player.transform.position;
                    behaviorTree.SetVariable("lastPlayer", (SharedVector3)lastPlayerSighting);
                    isSeen = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            isSeen = false;
        }
    }
}
