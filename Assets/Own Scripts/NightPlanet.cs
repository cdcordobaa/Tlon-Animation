using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightPlanet : MonoBehaviour {


    Transform tfLight;
    // Use this for initialization
    void Start () {

        var goLight = GameObject.Find("RevealingLight");
       
        tfLight = goLight.transform;
        

    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().material.SetVector("_LightPos", tfLight.position);
        GetComponent<Renderer>().material.SetVector("_LightDir", tfLight.forward);
    }
}
