using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vehicle : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;

    [SerializeField]
    bool stopEdges;

    [SerializeField]
    GameObject projectile;

    public float health;
    public float maxHealth;

    public static float healthBarValue = 1f;

    public static List<GameObject> playerProjectiles = new List<GameObject>();

    Vector3 position = Vector3.zero;
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;
    float height;
    float width;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        position = transform.position;
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        healthBarValue = health / maxHealth;
        //set velocity
        velocity = direction * speed * Time.deltaTime;

        //add velocity to position
        position += velocity;

        if (stopEdges)
        {
            if (position.y > height - 1.7)
            {
                position.y = height - 1.7f;
            }
            if (position.y < -height + .7)
            {
                position.y = -height + .7f;
            }
            if (position.x > width - .7)
            {
                position.x = width - .7f;
            }
            if (position.x < -width + .7)
            {
                position.x = -width + .7f;
            }
        }

        foreach(GameObject projectile in playerProjectiles)
        {
            if (projectile != null && projectile.transform.position.x > Camera.main.aspect * Camera.main.orthographicSize + 1)
            {
                Destroy(projectile);
                playerProjectiles.Remove(projectile);
                break;
            }
        }

        //place vehicle at updated position
        transform.position = position;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerProjectiles.Add(Instantiate(projectile, position, Quaternion.identity, transform));
        }
    }
}
