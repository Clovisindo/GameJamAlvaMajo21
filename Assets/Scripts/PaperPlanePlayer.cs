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

    [SerializeField]
    private int levelHazards = 0;//maximo 3 
    private float hazardSlow = 0;
    public float rotationControl;
    private bool playerDeath = false;


    public AudioClip landingEarthClip;

    float movY, movX = 1;

    public bool PlayerDeath { get => playerDeath; set => playerDeath = value; }

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
        Vector2 vel = transform.up * (200f);
        rb.AddForce(vel);
    }

    public void actionFallSingle()
    {
        Vector2 vel = transform.up * (-1) * (100f);
        rb.AddForce(vel);
    }

    public void actionFallingFree()
    {
        Vector2 velFalling = transform.up * (-1) * (rb.velocity.y);
        rb.AddForce(velFalling);
        Vector2 vel = transform.up * (-1) * (100f);
        rb.AddForce(vel);
        
    }

    public void actionInverseAcelerationc()
    {
        float prevAccel = rb.velocity.y;
        if (prevAccel <= -1)
        {
            Vector2 velRising = transform.up * (prevAccel);
            rb.AddForce(velRising);
        }
        else
        {
            Vector2 velRising = transform.up * 150F;
            rb.AddForce(velRising);
        }

        if (levelHazards > 0)
        {
            levelHazards--;
        }
        ApplyHazards(levelHazards);

    }
    public void actionCleanHazards()
    {
        if (levelHazards > 0)
        {
            levelHazards--;
        }
        ApplyHazards(levelHazards);
    }

    public void actionApplyHazards()
    {
        if (levelHazards >= 0 && levelHazards < 3)
        {
            levelHazards++;
        }
        ApplyHazards(levelHazards);
    }

    public void actionSlowBalloon()
    {
        Vector2 velSlow = transform.forward * -20f;
        rb.AddForce(velSlow);
        if (levelHazards >= 0 && levelHazards < 3)
        {
            levelHazards++;
        }
        ApplyHazards(levelHazards);
    }

    private void FixedUpdate()
    {
        if (!playerDeath)
        {
            FlyingBehaviour();
            InmuneBehaviour();
        }
    }
    /// <summary>
    /// Comportamiento de fisicas de vuelo
    /// </summary>
    protected void FlyingBehaviour()
    {
        if (hazardSlow != 0)
        {
            //aplica slow hasta la velocidad definida
            rb.velocity = Vector2.Lerp(new Vector2(hazardSlow, rb.velocity.y), transform.right * (movX * acceleration), Time.deltaTime/30);
        }
        else
        {
            //velocidad constante hacia adelante
            Vector2 vel = transform.right * (movX * acceleration);
            rb.AddForce(vel);
        }
       
        
        if (rb.velocity.x > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;

        //if (rb.velocity.y <= 0.01f)
        //{

        //}
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
    protected void ApplyHazards(int levelHazards)
    {
        switch (levelHazards)
        {
            default:
                hazardSlow = 0;
                break;
            case 1:
                hazardSlow = 4f;
                break;
            case 2:
                hazardSlow = 3f;
                break;
            case 3:
                hazardSlow =2f;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckCurrentPPColl(other);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        CheckCurrentPPColl(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckCurrentPPColl(other);
    }

    private void CheckCurrentPPColl(Collider2D other)
    {
        PuzzlePiece currentPP = other.gameObject.GetComponent<PuzzlePiece>();
        if (other.gameObject.tag == "PieceLevel" && (!currentPP.checkIsInmune()))
        {
            GameObject puzzlePieceColl = other.gameObject;
            //other.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            currentPP.Active();
            Debug.Log("efecto pieza activado");
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

    public void ResetPlayer()
    {
        transform.position = new Vector2(0, 0);
        rb.velocity = new Vector2(0, 0);
    }

    public void StopPlayer()
    {
        SoundManager.instance.PlaySingle(landingEarthClip);
        rb.velocity = new Vector2(0, 0);
        playerDeath = true;
    }
}
