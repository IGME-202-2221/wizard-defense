using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 15f;

    [SerializeField]
    public float damage = 5f;

    [SerializeField]
    Vector3 direction;

    Vector3 position = Vector3.zero;
    Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;
        position += velocity;
        transform.position = position;
    }
}
