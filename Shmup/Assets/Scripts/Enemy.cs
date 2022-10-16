using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;

    [SerializeField]
    GameObject projectile;

    public static List<GameObject> enemyProjectiles = new List<GameObject>();

    [SerializeField]
    float fireRate = 1.7f;

    float nextFire = 0f;

    Vector3 position = Vector3.zero;
    Vector3 direction = new Vector3(-1, 0);
    Vector3 velocity = Vector3.zero;
    public float timeCreated;
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime = Time.time - timeCreated;
        if (lifetime > nextFire)
        {
            nextFire = lifetime + fireRate;
            enemyProjectiles.Add(Instantiate(projectile, position, Quaternion.identity, transform));
        }
        foreach (GameObject projectile in enemyProjectiles)
        {
            if (projectile != null && projectile.transform.position.x < -Camera.main.aspect * Camera.main.orthographicSize - 1)
            {
                Destroy(projectile);
                enemyProjectiles.Remove(projectile);
                break;
            }
        }
        velocity = direction * speed * Time.deltaTime;
        position += velocity;
        transform.position = position;
    }
}
