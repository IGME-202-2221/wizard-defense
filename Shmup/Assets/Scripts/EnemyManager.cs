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

    [SerializeField]
    float spikeThreshold;

    float nextSpike;

    float spikeHealthBump = 1f;

    //helper so they spawn at this rate
    float nextSpawn = 0.0f;

    public static float castleIntegrity = 100f;

    public static List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        nextSpike = spikeThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        if (!HUDManager.gameOver)
        {
            Spawn();
            CheckCastleDamage();
            RampUpDifficulty();
        }

    }

    //spawn a random enemy
    public GameObject RandomEnemy()
    {
        return enemiesToSpawn[Random.Range(0, enemiesToSpawn.Count)];
    }

    public void Spawn()
    {
        //spawn one in based on spawn rate
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            GameObject enem = Instantiate(RandomEnemy(), new Vector3((Camera.main.orthographicSize * Camera.main.aspect) + 1, Random.Range(-Camera.main.orthographicSize + .7f, Camera.main.orthographicSize - 1.7f)), Quaternion.identity, transform);
            enem.GetComponent<Enemy>().timeCreated = Time.time;
            enem.GetComponent<Enemy>().health *= spikeHealthBump;
            enemies.Add(enem);
        }
    }
    public void CheckCastleDamage()
    {
        //destroy and deal its health in castle integrity damage if left to go offscreen
        foreach (GameObject enemy in enemies)
        {
            if (enemy.transform.position.x < -Camera.main.aspect * Camera.main.orthographicSize)
            {
                Destroy(enemy);
                castleIntegrity -= enemy.GetComponent<Enemy>().health;
                enemies.Remove(enemy);
                break;
            }
        }
    }

    public void RampUpDifficulty()
    {
        //make it harder after a certain amt of points are gained
        if (CollisionHandler.score >= nextSpike)
        {
            nextSpike += spikeThreshold;
            spawnRate *= 0.95f;
            spikeHealthBump += 0.1f;
        }
    }
}
