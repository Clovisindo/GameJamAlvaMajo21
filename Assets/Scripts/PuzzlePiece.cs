﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzlePiece : MonoBehaviour
{
    public float pieceTempo;
    public float lifeTime;

    public bool hasStarted = false;
    private bool puzzlePieceInmune;
    private CircleCollider2D colliderPP;
    private KeyCode keyPuzzlePiece = KeyCode.Space;

    protected const float inmuneTime = 2.0f;
    protected float passingTime = inmuneTime;
    protected bool enemyInmune = false;

    public KeyCode KeyPuzzlePiece { get => keyPuzzlePiece; set => keyPuzzlePiece = value; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        pieceTempo = pieceTempo / 60f;
        colliderPP = this.GetComponent<CircleCollider2D>();
        Invoke(nameof(DestroyPuzzlePiece), lifeTime);
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        if (!hasStarted)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                hasStarted = true;
            }
            else
            {
                transform.position -= new Vector3(pieceTempo * Time.deltaTime, 0f, 0f);
            }
        }
        InmuneBehaviour();
    }

    public virtual void Active()
    {
        ActiveAction();
        passingTime = 0;
    }
    protected abstract void ActiveAction();

    protected void InmuneBehaviour()
    {
        if (passingTime < inmuneTime)
        {
            passingTime += Time.deltaTime;
            puzzlePieceInmune = true;
            colliderPP.enabled = false;
        }
        else
        {
            colliderPP.enabled = true;
            puzzlePieceInmune = false;
        }
    }
    public bool checkIsInmune()
    {
        if (puzzlePieceInmune)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected virtual void DestroyPuzzlePiece()
    {
        Debug.Log("Pieza destruida");
        Destroy(gameObject);
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Activator")
    //    {
    //        GameObject puzzlePieceColl = other.gameObject;
    //        other.gameObject.GetComponent<CircleCollider2D>().enabled = false;
    //        Active();
    //        //animator.SetTrigger("Hurt");
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Activator")
    //    {
    //        GameObject puzzlePieceColl = other.gameObject;
    //        other.gameObject.GetComponent<CircleCollider2D>().enabled = false;
    //        Active();
    //        //animator.SetTrigger("Hurt");
    //    }
    //}

    //private void OnCollisionStay2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Activator")
    //    {
    //        GameObject puzzlePieceColl = other.gameObject;
    //        other.gameObject.GetComponent<CircleCollider2D>().enabled = false;
    //        Active();
    //        //animator.SetTrigger("Hurt");
    //    }
    //}


}
