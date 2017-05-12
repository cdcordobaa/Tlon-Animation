using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralParticle : MonoBehaviour {

    public ParticleSystem ps; //= GetComponent<ParticleSystem>();

    void Start()
    {
        //ParticleSystem ps = GetComponent<ParticleSystem>();
        var vel = ps.velocityOverLifetime;
        vel.enabled = true;
        vel.space = ParticleSystemSimulationSpace.Local;

        AnimationCurve curveY = new AnimationCurve();
        AnimationCurve curveX = new AnimationCurve();


        float step = 0.05f;
        float time;
        float imagen;
        float alfa = 0.8f;
        float beta = 0.3f;


        for ( time = 0.0f; time <= 1.02f; time += step){

            imagen = time * Mathf.Sin(time * Mathf.PI*2);      
            //imagen =  Mathf.Sin(time * Mathf.PI * 3) * Mathf.Exp(beta * time) * alfa;
            curveX.AddKey(time,imagen);

            imagen = time * Mathf.Cos(time * Mathf.PI * 2);
            //imagen = Mathf.Cos(time * Mathf.PI * 3) * Mathf.Exp(beta * time) * alfa;
            curveY.AddKey(time, imagen);


        }
        
        vel.x = new ParticleSystem.MinMaxCurve(1.0f, curveX);
        vel.y = new ParticleSystem.MinMaxCurve(1.0f, curveY);
    }
}
