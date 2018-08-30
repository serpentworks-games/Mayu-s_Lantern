using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour {

    private float maxLength = 100f;
    LineRenderer lightBeamLine;
    

	// Use this for initialization
	void Start () {
        lightBeamLine = GetComponent<LineRenderer>();
        lightBeamLine.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (this.enabled)
        {
            StartCoroutine(TurnOnBeam());

        }
        
    }

    IEnumerator TurnOnBeam()
    {
        lightBeamLine.enabled = true;
   
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        lightBeamLine.SetPosition(0, ray.origin);
        if (Physics.Raycast(ray, out hit, maxLength))
        {
            lightBeamLine.SetPosition(1, hit.point);
            if (hit.collider.name == "LightTrigger")
            {
                Debug.Log("LightTrigger activated!");
            }
            else if (hit.collider.name == "Mirror")
            {
                hit.collider.gameObject.GetComponentInChildren<LightBeam>().enabled = true;

            }

        } else {

            lightBeamLine.SetPosition(1, ray.GetPoint(100));
        }
            yield return null;
    }

}
