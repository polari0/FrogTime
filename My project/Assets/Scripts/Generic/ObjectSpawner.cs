using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamSpaceTaxi
{
    public class ObjectSpawner : MonoBehaviour
    {
        public int numberToSpawn;

        public List<GameObject> spawnpool;
        [SerializeField]
        List<GameObject> positions;
        //These lists store what to spawn and position to spawn. 
        public GameObject spawnLocation;
        public int collect = 0;
        private Vector2 screenBounds;


        public void Start()
        {
            //StartCoroutine(StartSpawnCourutine());
            SpanwObjects();
        }

        private void Update()
        {
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        }

        //Spawns from random location
        public void SpanwObjects()
        {
            int randomItem = 0;
            GameObject toSpawn;
            MeshCollider c = spawnLocation.GetComponent<MeshCollider>();

            float screenX, screenY;
            Vector2 pos;

            for (int i = 0; i < numberToSpawn; i++)
            {
                randomItem = Random.Range(0, spawnpool.Count);
                toSpawn = spawnpool[randomItem];

                screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
                screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
                //Setting boundaries where tears can spawn
                pos = new Vector2(screenX, screenY);
                Instantiate(toSpawn, pos, toSpawn.transform.rotation);
                //Instantiate spawns
                //This script spawns opbjects on the quad on top 
            } 
        }

        internal void ScreenBoundSpawner()
        {
            int randomItem = 0;
            GameObject toSpawn;


            randomItem = Random.Range(0, spawnpool.Count);
            toSpawn = spawnpool[randomItem];

            GameObject asteroid = Instantiate(toSpawn) as GameObject;
            asteroid.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y));
        }



        //Spawns from specific location
        internal void SpawFromLocation()
        {
            int tear;
            GameObject tearToSapwn;
            int angelPos = Random.Range(0, positions.Count);
            //Chooses random postion from the 4 available angel positions. 

            tear = Random.Range(0, spawnpool.Count);
            tearToSapwn = spawnpool[tear];
            //These 2 line are here just because i made a the original code before thinking this far ahead and im too lazy to change it.
            //But basically they just take random item from spawnpool which has only one item. 

            Instantiate(tearToSapwn, positions[angelPos].transform.position, transform.rotation);
            //This function spawn the tears at Angel positions. Angel positions are stored in list and i take random index of that list to choose the position to spawn the tear. 
        }


        //Comented version is currently not in use
        IEnumerator StartSpawnCourutine()
        {
            while (collect < 10)
            {
                yield return new WaitForSeconds(.1f);
                //SpanwObjects();
                //SpawFromLocation();
                //ScreenBoundSpawner();
            }
        }
    }
}