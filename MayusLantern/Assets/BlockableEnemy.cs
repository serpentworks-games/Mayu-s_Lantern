using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockableEnemy : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BlockingObject")
        {
            GetComponent<LurkerController>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BlockingObject")
        {
            GetComponent<LurkerController>().enabled = true;
        }
    }
}
