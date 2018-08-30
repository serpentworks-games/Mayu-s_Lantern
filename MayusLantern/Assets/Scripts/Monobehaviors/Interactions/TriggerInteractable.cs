using UnityEngine;
using System.Collections;

public class TriggerInteractable : Interactable
{
    public override void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Interact();
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //do nothing
        }
    }
}
