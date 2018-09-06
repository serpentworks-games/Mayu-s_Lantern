using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableBlock : MonoBehaviour {

    //Manages moving blocks
    //Locks block to one axis at a time for movement

    bool switched = false; //used by switches
    bool initialMov = false; //control variable, set to true after first input

    float startX, startZ;
    public float blockLength = 1f; //size of the block, and distance to move

    public Rigidbody rbBlock;

    // Use this for initialization
    void Awake () {
        rbBlock = GetComponent<Rigidbody>();
        startX = transform.position.x;
        startZ = transform.position.z;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        MoveBlock();
	}

    void MoveBlock()
    {
        //if (!switched)
       // {
            if (transform.position.x >= startX + blockLength)
            {
                rbBlock.isKinematic = true;
                transform.position = new Vector3(startX + blockLength, transform.position.y, transform.position.z);
                switched = true;
            } else if (transform.position.x <= startX - blockLength)
            {
                rbBlock.isKinematic = true;
                transform.position = new Vector3(startX - blockLength, transform.position.y, transform.position.z);
                switched = true;
            } else if (transform.position.z >= startZ + blockLength)
            {
                rbBlock.isKinematic = true;
                transform.position = new Vector3(transform.position.x, transform.position.y, startZ + blockLength);
                switched = true;
            } else if (transform.position.z <= startZ - blockLength)
            {
                rbBlock.isKinematic = true;
                transform.position = new Vector3(transform.position.x, transform.position.y, startZ - blockLength);
                switched = true;
            }
        //}
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody body = collision.gameObject.GetComponent<Rigidbody>();

            if (!initialMov)
            {
                if (body.velocity.x < 0)
                {
                    rbBlock.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                }
                else if (body.velocity.x > 0)
                {
                    rbBlock.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                }
                else if (body.velocity.z < 0)
                {
                    rbBlock.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
                }
                else if (body.velocity.z > 0)
                {
                    rbBlock.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
                }
                initialMov = true;
            }
        }
    }
}
