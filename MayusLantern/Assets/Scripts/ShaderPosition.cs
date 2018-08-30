using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderPosition: MonoBehaviour {

    public float radius;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Shader.SetGlobalVector("_Position", transform.position);
        Shader.SetGlobalFloat("_Radius", radius);
        
	}
}
