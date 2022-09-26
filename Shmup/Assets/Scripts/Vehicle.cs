using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vehicle : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;

    Vector3 position = Vector3.zero;
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;
    float height;
    float width;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        Debug.Log(height);
    }

    // Update is called once per frame
    void Update()
    {
        //set velocity
        velocity = direction * speed * Time.deltaTime;

        //add velocity to position
        position += velocity;

        if (position.y > height)
        {
            position.y = -height;
        }
        else if (position.y < -height)
        {
            position.y = height;
        }
        else if (position.x > width )
        {
            position.x = -width;
        }
        else if (position.x < -width)
        {
            position.x = width;
        }

        //place vehicle at updated position
        transform.position = position;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }
}
