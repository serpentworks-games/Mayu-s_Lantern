using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableUIPrompt : MonoBehaviour {


    private void Update()
    {
        Camera camToLookAt = Camera.main;

        Vector3 v = camToLookAt.transform.position - transform.position;

        v.x = v.z = 0.0f;
        transform.LookAt(camToLookAt.transform.position - v);
        transform.Rotate(0, 180, 0);
    }
}
