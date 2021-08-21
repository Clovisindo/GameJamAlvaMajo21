using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPlanePlayer : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public float maxSpeed;

    Rigidbody2D rb;

    public float rotationControl;

    float movY, movX = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //pruebas de fisicas de empuje hacia arriba
        if (Input.GetKey(KeyCode.Space))
        {
            Vector2 vel = transform.up * (5f);
            rb.AddForce(vel);
        }
    }

    private void FixedUpdate()
    {
        //velocidad constante hacia adelante
        Vector2 vel = transform.right * (movX * acceleration);
        rb.AddForce(vel);
        if (rb.velocity.x > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;
    }
}
