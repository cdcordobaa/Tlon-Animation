using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomDest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 ramdonEnd = Random.insideUnitCircle * 5;
        transform.position += ramdonEnd;

    }
}
