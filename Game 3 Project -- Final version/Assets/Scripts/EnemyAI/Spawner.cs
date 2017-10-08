using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //spawn code originated from https://www.youtube.com/watch?v=WGn1zvLSndk
    //slight modifications to fit my game's purpose
    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    ////public int maxNumberOfEnemies;
    public bool stop;

    //plane heights
    public float planeheighta;
    public float planeheightb;
    int randEnemy;
    int spawning;
    private int numOfEnemies;
    public GameObject warningobject;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(waitSpawner());
        //dir = new float[2];
        //dir[0] = -spawnValues.z;
        //dir[1] = spawnValues.z;
        //xdir = new float[2];
        //xdir[0] = -spawnValues.x;
        //xdir[1] = -spawnValues.x;
        //numOfEnemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }
    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (!stop)/*&& numOfEnemies <= maxNumberOfEnemies*/
        {

            randEnemy = Random.Range(0, enemies.Length);
            //Debug.Log("randEnemy: " + randEnemy);
            Vector3 spawnPosition;
            if (enemies[randEnemy].name == "enemy plane")    // for spawning planes
            {
                //spawnPosition =new Vector3 (xdir[Random.Range(0,dir.Length)], Random.Range(planeheighta, planeheightb), dir[Random.Range(0, dir.Length)]);
                spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x), Random.Range(planeheighta, planeheightb), Random.Range(spawnValues.z,-spawnValues.z));

            }
            else //if (enemies[randEnemy].name == "Enemy Tank (prototype v2)")
            {
                //spawnPosition = new Vector3(xdir[Random.Range(0, dir.Length)], 0.9f, dir[Random.Range(0, dir.Length)]);
                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0.9f, Random.Range(spawnValues.z, -spawnValues.z));
            }

            //if (randEnemy == 3)    // for spawning planes
            //{
            //    spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 6, spawnValues.z);
            //}
            //else
            //{
            //    spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0.9f, spawnValues.z);
            //}

            Vector3 warning = new Vector3 (spawnPosition.x, 2, spawnPosition.z); // 20
            warningobject.transform.rotation = Quaternion.Euler(-180,0, 90);

            var value = Instantiate (warningobject,  warning, gameObject.transform.rotation);
            yield return new WaitForSeconds(0.20f);
            Destroy (value, .20f);

            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            //++numOfEnemies;
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
