﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light the_light;

    public float MinTime;
    public float MaxTime;
    public float Timer;

    // Start is called before the first frame update
    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        FlickerLight();
    }

    void FlickerLight(){
        if(Timer > 0)
            Timer -= Time.deltaTime;
        
        if(Timer <= 0){
            the_light.enabled = !the_light.enabled;
            Timer = Random.Range(MinTime, MaxTime);
        }
    }
}
