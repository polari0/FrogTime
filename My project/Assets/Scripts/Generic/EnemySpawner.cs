using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogTime
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        List<GameObject> spawnpool;
        [SerializeField]
        List<GameObject> positions;
        internal void SpawFromLocation()
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

        internal IEnumerator StartSpawnCourutine()
        {
            SpawnFromLocation();
            yield return new WaitForSeconds(.1f);

        }
    } 
}
