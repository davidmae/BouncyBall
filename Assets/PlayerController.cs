using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    Rigidbody2D rigidbody;
    Vector3 acceleration;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        acceleration = Input.acceleration;
        acceleration.y = 0;
        acceleration.z = 0;
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(acceleration * speed);
    }
}
