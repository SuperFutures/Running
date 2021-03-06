﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour {
    //用于保存跑道prefabs
    public GameObject[] tracks;
    //用来保存跑道的初始速度
    public float initialSpeed;
    //用来保存跑道每次加速率
    public float speedRate;
    //用来保存跑过多少个跑道之后加速
    public int acceleratedNumber;
    //用来保存跑道的长度
    public float length;


    //用来保存跑过的跑道数
    [HideInInspector]
    public int count;
    //用来保存跑道当前的速度
    [HideInInspector]
    public float currentSpeed;

    private void Awake() {
        count = 0;
       
        //
        if (DataTransformer.initialSpeed == 0f)
        {
            currentSpeed = initialSpeed * Time.fixedDeltaTime;

            DataTransformer.initialSpeed = currentSpeed;
            DataTransformer.currentSpeed = currentSpeed;
       

        } else {
            currentSpeed = DataTransformer.initialSpeed;
        }
    }


    public void RunOver() {
        count++;

        if (count % acceleratedNumber == 0) {
            currentSpeed = currentSpeed * speedRate;

            DataTransformer.currentSpeed = currentSpeed;
        }
    }

    public void Stop() {
        currentSpeed = 0;
    }

    public void Continue() {
        currentSpeed = DataTransformer.currentSpeed;
    }
}
