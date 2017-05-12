using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComsMove : MonoBehaviour {


    public Transform emitter;
    public Transform receiver;
    public float comsTime = 6.0F;
    private float startTime;
    Vector3 randomEnd;
    float randCenit;


    void Start () {
        startTime = Time.time;
        randomEnd = Random.insideUnitCircle * 5;
        randCenit = Random.Range(-5f, 5f);
    }

    void Update()
    {
                 
            Vector3 center = (emitter.position + receiver.position) * 0.5F;
            center -= new Vector3(randCenit, 10, 0);
            //center -= new Vector3(Random.Range(-0.2f,0.2f), 10, 0);
            Vector3 riseRelCenter = emitter.position - center;
            Vector3 setRelCenter = receiver.position - center;
            float fracComplete = (Time.time - startTime) / comsTime;
            transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
            transform.position += center;          

    }
}
