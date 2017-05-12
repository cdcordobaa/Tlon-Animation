using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingStars : MonoBehaviour {

    public float speed = 6.0f;
    // Use this for initialization
    void Start()
    {
        speed = 6.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * speed);
    }
}
