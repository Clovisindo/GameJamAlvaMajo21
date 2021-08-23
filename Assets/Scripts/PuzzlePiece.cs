using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public float pieceTempo;

    public bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        pieceTempo = pieceTempo / 60f;
    }

    // Update is called once per frame
    void Update()
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
    }

    public void Active()
    {
        ActiveAction();
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

    private void ActiveAction()
    {
        GameManager.instance.player.GetComponent<PaperPlanePlayer>().actionJumpSingle();
    }
}
