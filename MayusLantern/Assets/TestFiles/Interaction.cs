using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interaction : MonoBehaviour {

 	NavMeshAgent playerAgent;
    Animator playerAnim;
	bool hasInteracted;

	public virtual void MoveToInteract(NavMeshAgent _playerAgent){
		this.playerAgent = _playerAgent;
		playerAgent.destination = this.transform.position;
		hasInteracted = false;
        playerAnim = playerAgent.GetComponentInChildren<Animator>();
	}

	void Update(){
		if (playerAgent != null && !playerAgent.pathPending && !hasInteracted) {
            if (playerAgent.remainingDistance >= playerAgent.stoppingDistance && playerAgent.remainingDistance <= playerAgent.stoppingDistance + 2f)
            {
                playerAnim.SetFloat("Speed", 0.75f);
            }
			if (playerAgent.remainingDistance <= playerAgent.stoppingDistance) {
				Interact ();
				hasInteracted = true;
                StartCoroutine(WaitForTime());
			}
		}
	}

	public virtual void Interact(){

		Debug.Log ("You interacted with the base class");
	}

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(0.5f);
        playerAnim.SetBool("isMoving", false);
    }
}
