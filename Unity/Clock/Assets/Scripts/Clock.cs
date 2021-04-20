﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    Transform hoursPivot, minutePivot, secondPivot;

    const float hoursToDegrees = -30f,
        minutesToDegrees = -6f, 
        secondsToDegrees = -6f;

    private void Awake()
    {
        DateTime time = DateTime.Now;

        hoursPivot.localRotation = Quaternion.Euler (0f, 0f, hoursToDegrees * time.Hour);
        minutePivot.localRotation = Quaternion.Euler (0f, 0f, minutesToDegrees * time.Minute);
        secondPivot.localRotation = Quaternion.Euler (0f, 0f, secondsToDegrees * time.Second);
    }

   

    // Update is called once per frame
    void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;

        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, hoursToDegrees * (float) time.TotalHours);
        minutePivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * (float)time.TotalMinutes);
        secondPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * (float)time.TotalSeconds);
    }
}