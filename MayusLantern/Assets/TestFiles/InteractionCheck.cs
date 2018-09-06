using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractionCheck : MonoBehaviour {
    //A raycaster that checks what's in front of Mayu and does interactions based on that check. 

    RaycastHit hit;
    public float raycastRange;
    public LayerMask interactableLayer;
    public Vector3 offset;
   

    void Update()
    {
        Raycast();
    }
 	
    void Raycast()
    {
        var raycastOffset = transform.position + offset;
        if (Physics.Raycast(raycastOffset, Vector3.forward, out hit, raycastRange, interactableLayer))
        {
            Debug.DrawRay(raycastOffset, Vector3.forward * raycastRange, Color.cyan);

            if (hit.collider.gameObject.CompareTag("movableObject"))
            {
               
                Debug.Log("Hit something moveable!");
            }
            else
            {
                Debug.Log("Did not hit something moveable!");
            }
        } 
    }
}
