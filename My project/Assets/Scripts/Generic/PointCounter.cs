using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointCounter : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;


    int score = 0;

    private void Start()
    {
        scoreText.text = score.ToString() + " Points";
    }

    internal void UpdateScore()
    {
        score += 1;
        scoreText.text = score.ToString() + " Points";
    }
}
