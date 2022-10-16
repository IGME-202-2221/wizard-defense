using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> enemiesToSpawn = new List<GameObject>();

    //rate at which they spawn
    [SerializeField]
    float spawnRate = 5f;

    //helper so they spawn at this rate
    float nextSpawn = 0.0f;

    public static List<GameObject> enemies = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        //spawn one in based on spawn rate
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            GameObject enem = Instantiate(RandomEnemy(), new Vector3((Camera.main.orthographicSize * Camera.main.aspect) + 1, Random.Range(-Camera.main.orthographicSize + .7f, Camera.main.orthographicSize - .7f)), Quaternion.identity, transform);
            enem.GetComponent<Enemy>().timeCreated = Time.time;
            enemies.Add(enem);
        }
        foreach (GameObject enemy in enemies)
        {
            if(enemy.transform.position.x < -Camera.main.aspect * Camera.main.orthographicSize)
            {
                Destroy(enemy);
                enemies.Remove(enemy);
                break;
            }
        }
    }

    public GameObject RandomEnemy()
    {
        return enemiesToSpawn[Random.Range(0, enemiesToSpawn.Count)];
    }
}
