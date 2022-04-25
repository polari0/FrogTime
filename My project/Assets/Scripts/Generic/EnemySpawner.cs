using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polarith.AI.Move;

namespace FrogTime
{
    public class EnemySpawner : MonoBehaviour
    { 
        [SerializeField]
        List<GameObject> spawnpool;
        [SerializeField]
        List<GameObject> positions;

        public float spawnTimer = 3f;
        private float EnemyCount = 3;

        [SerializeField]
        AIMEnvironment AIM_Script;
        [SerializeField]
        PointCounter pointCounter_Script;

        internal int roundCount = 0;
        [SerializeField]
        int maxRounds = 10;

        private void Awake()
        {
            StartCoroutine(StartSpawning());
        }

        private void Update()
        {
            if (roundCount == maxRounds + 1)
            {
                StopCoroutine(StartSpawning());
            }

        }

        internal void SpawnFromLocation()
        {
            int randomEnemy;
            GameObject EnemyToSpawn;
            int SpawnPos = Random.Range(0, positions.Count);
            //Chooses random postion from the 4 available angel positions. 

            randomEnemy = Random.Range(0, spawnpool.Count);
            EnemyToSpawn = spawnpool[randomEnemy];
            //These 2 line are here just because i made a the original code before thinking this far ahead and im too lazy to change it.
            //But basically they just take random item from spawnpool which has only one item. 

            Instantiate(EnemyToSpawn, positions[SpawnPos].transform.position, transform.rotation);
            //This function spawn the tears at Angel positions. Angel positions are stored in list and i take random index of that list to choose the position to spawn the tear. 
        }
        private IEnumerator StartSpawning()
        {
            while (roundCount <= maxRounds)
            {
                for (int i = 0; i < EnemyCount; i++)
                {
                    SpawnFromLocation();
                    AIM_Script.UpdateLayerGameObjects();
                    pointCounter_Script.UpdateRoundCount();
                    yield return new WaitForSeconds(spawnTimer); 
                }
                spawnTimer -= 0.2f;
                roundCount++;
                EnemyCount++; 
                yield return new WaitForSeconds(5f);
            }
            
        }
    } 
}
