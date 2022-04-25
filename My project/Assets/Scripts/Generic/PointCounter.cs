using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace FrogTime
{
    public class PointCounter : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI scoreText;
        [SerializeField]
        TextMeshProUGUI roundCount;

        [SerializeField]
        EnemySpawner enemySpawner_Script;

        int score = 0;

        private void Start()
        {
            scoreText.text = score.ToString() + " Points";
            roundCount.text = roundCount.ToString() + "/10 Rounds";
        }

        internal void UpdateScore()
        {
            score += 1;
            scoreText.text = score.ToString() + " Points";
        }

        internal void UpdateRoundCount()
        {
            roundCount.text = enemySpawner_Script.roundCount.ToString() + "/10 Rounds";
        }

    }

}