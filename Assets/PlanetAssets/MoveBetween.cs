using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetween : MonoBehaviour {

    public Transform emitter;
    public Transform receiver;    
    public GameObject comsDot;
    Vector3 randSurface;
    Vector3 randEnd;
    public float radius = 2f;
    public float errorRate = 0.8f;


    void Start()
    {
        //emitter.transform.position = transform.position;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            emit();
        }

        
            
    }

    public void emit()
    {
        print("key pressed");       

        GameObject temporary_com;
        temporary_com = Instantiate(comsDot, emitter.transform.position, emitter.transform.rotation) as GameObject;
        GameObject randTransformation = getframeEmitValue();

        //Instantiate(receiver, randEnd, Quaternion.identity, transform.parent) as GameObject;

        ComsMove cm = temporary_com.transform.gameObject.AddComponent<ComsMove>() as ComsMove;
        cm.emitter = emitter;
        cm.receiver = randTransformation.transform;

        //temporary_com.GetComponent<ComsMove>().emitter = emitter;
        //temporary_com.GetComponent<ComsMove>().receiver = randTransformation.transform; //Instantiate(receiver, randEnd, Quaternion.identity, transform.parent) ;         

        Destroy(temporary_com, 15.0f);
        Destroy(randTransformation, 15.0f);
    }

    GameObject getframeEmitValue()
    {

        randSurface = new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius));

        if (Random.value <= errorRate)
            randEnd = receiver.transform.position + randSurface;
        else
            randEnd = receiver.transform.position;

        GameObject randTransformation = new GameObject();
        randTransformation.transform.position = randEnd;

        randTransformation.transform.parent = transform.parent;

        return randTransformation;

    }



}
