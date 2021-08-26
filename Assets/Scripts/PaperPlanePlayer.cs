using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPlanePlayer : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public float maxSpeed;

    Rigidbody2D rb;
    BoxCollider2D bc;

    private bool playerInmune;
    protected const float inmuneTime = 2.0f;
    protected float passingTime = inmuneTime;
    protected bool enemyInmune = false;

    public float rotationControl;

    float movY, movX = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        passingTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //pruebas de fisicas de empuje hacia arriba
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    Vector2 vel = transform.up * (5f);
        //    rb.AddForce(vel);
        //}
    }

    public void actionJumpSingle()
    {
        Vector2 vel = transform.up * (100f);
        rb.AddForce(vel);
    }

    public void actionFallSingle()
    {
        Vector2 vel = transform.up * (-1) * (100f);
        rb.AddForce(vel);
    }

    private void FixedUpdate()
    {
        //velocidad constante hacia adelante
        Vector2 vel = transform.right * (movX * acceleration);
        rb.AddForce(vel);
        if (rb.velocity.x > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;
        
        
        InmuneBehaviour();

    }
    /// <summary>
    /// Comportamiento de fisicas de vuelo
    /// </summary>
    protected void FlyingBehaviour()
    {
        if (rb.velocity.y <= 0.01f)
        {

        }
    }
    protected void InmuneBehaviour()
    {
        if (passingTime < inmuneTime)
        {
            passingTime += Time.deltaTime;
            playerInmune = true;
            bc.enabled = false;
        }
        else
        {
            bc.enabled = true;
            playerInmune = false;
        }
    }
    public void UpdatePassingTime()
    {
        passingTime = 0;
    }

    public bool checkIsInmune()
    {
        if (playerInmune)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
