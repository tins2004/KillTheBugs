using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] spawnPoint;

    int intEnemy;
    int intSpawnPoint;
    int ss = 1;
    int enemySpawn = 0;
    float timeSpawn = 0;
    float timet;

    float timeAudio = 0;
    AudioSource audioSource;
    int soundNumber;
    public AudioClip[] soundError;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        timet = Random.Range(3, 11);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSpawn < timet)
        {
            timeSpawn += Time.deltaTime;   
        }
        else
        {
            intSpawnPoint = Random.Range(0, 12);

            if (ss == 1)
            {
                Instantiate(enemy[0], spawnPoint[intSpawnPoint].position, Quaternion.identity);
                enemySpawn += 1;
                if (enemySpawn == 5) ss = 2;
            }
            else if (ss == 2)
            {
                intEnemy = Random.Range(0, 3);
                Instantiate(enemy[intEnemy], spawnPoint[intSpawnPoint].position, Quaternion.identity);
                enemySpawn += 1;
                if (enemySpawn == 10) ss = 3;
            }
            else if (ss == 3)
            {
                intEnemy = Random.Range(0, 4);
                Instantiate(enemy[intEnemy], spawnPoint[intSpawnPoint].position, Quaternion.identity);
                enemySpawn += 1;
                if (enemySpawn == 15) ss = 4;
            }
            else if (ss == 4)
            {
                intEnemy = Random.Range(0, 5);
                Instantiate(enemy[intEnemy], spawnPoint[intSpawnPoint].position, Quaternion.identity);
                enemySpawn += 1;
                if (enemySpawn == 20) ss = 4;
            }
            else
            {
                intEnemy = Random.Range(0, 6);
                Instantiate(enemy[intEnemy], spawnPoint[intSpawnPoint].position, Quaternion.identity);
                enemySpawn += 1;
                if (enemySpawn == 100) 
                {
                    SceneManager.LoadScene(2);
                }
            }

            timeSpawn = 0;
            timet = Random.Range(3, 11);
        }

        if (timeAudio < 5)
        {
            timeAudio += Time.deltaTime;   
        }
        else
        {
            soundNumber = Random.Range(0, 13);
            audioSource.PlayOneShot(soundError[soundNumber], 1f);
            timeAudio = 0;
        }
    }
}
