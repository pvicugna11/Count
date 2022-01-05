using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    private int score;
    public int cubePoint = 3;
    public int spherePoint = 2;
    public TextMeshProUGUI scoreText;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Cube":
                AddScore(cubePoint);
                break;
            
            case "Sphere":
                AddScore(spherePoint);
                break;

            default:
                break;
        }
    }

    private void AddScore(int point)
    {
        score += point;
        scoreText.text = "Score: " + score;
    }
}
