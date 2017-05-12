using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComsEmitterController : MonoBehaviour {


    public GameObject comsDot;
    public int nodesNumber = 4;
    public float[] comsProbabilities ;
    public float frameEmitProbability = 0.8f;
    public float errorRate = 0.99f;

    // Use this for initialization
    void Start () {

        //comsProbabilities = new float[nodesNumber];
        setChildEmitters();

    }
	
	// Update is called once per frame
	void Update ()
    {
        int children = nodesNumber;
        for (int i = 0; i < children; i++)
        {
            GameObject node = transform.GetChild(i).gameObject;
            float rand = Random.value;
            if (rand <= comsProbabilities[i])
            {
                MoveBetween[] canals = node.GetComponents<MoveBetween>();
                Debug.Log(canals);
                for (int j=0; j < canals.Length; j++)
                {
                    if (Random.value <= frameEmitProbability)
                        canals[j].emit();
                }
                   


            }
                
        }

    }


    void setChildEmitters()
    {
        int children = nodesNumber;
        for (int i = 0; i < children; i++)
        {
            GameObject node = transform.GetChild(i).gameObject;
            
            for (int j = 0; j < children; j++)
            {
                if (i != j)
                {
                    MoveBetween cm = node.AddComponent<MoveBetween>() as MoveBetween;
                    cm.emitter = node.transform;
                    cm.receiver = transform.GetChild(j);
                    cm.comsDot = comsDot;
                    cm.errorRate = errorRate;
                }
                
            }


        }
            
    }
}
