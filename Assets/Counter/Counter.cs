using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text sphereCounterText;
    public Text cubeCounterText;

    private int sphereCount = 0;
    private int cubeCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Cube":
                Count(ref cubeCount, cubeCounterText, "Cube");
                break;

            case "Sphere":
                Count(ref sphereCount, sphereCounterText, "Sphere");
                break;
        }
    }

    private void Count(ref int count, Text counterText, string objName)
    {
        count++;
        counterText.text = objName + " Count : " + count;
    }
}
