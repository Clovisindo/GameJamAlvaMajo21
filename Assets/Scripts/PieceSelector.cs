using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceSelector : MonoBehaviour
{
    private RawImage sr;
    public Texture2D defaultImage;
    public Texture2D pressedImage;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            sr.texture = pressedImage;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            sr.texture = defaultImage;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Input.GetKeyDown(keyToPress) && other.gameObject.tag == "PuzzlePiece")
        {
             GameObject puzzlePieceColl = other.gameObject;
            //other.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            puzzlePieceColl.GetComponent<PuzzlePiece>().Active();
            //animator.SetTrigger("Hurt");
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (Input.GetKeyDown(keyToPress) && other.gameObject.tag == "PuzzlePiece")
        {
            GameObject puzzlePieceColl = other.gameObject;
            //other.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            puzzlePieceColl.GetComponent<PuzzlePiece>().Active();
            //animator.SetTrigger("Hurt");
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (Input.GetKeyDown(keyToPress) && other.gameObject.tag == "PuzzlePiece")
        {
             GameObject puzzlePieceColl = other.gameObject;
            //other.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            puzzlePieceColl.GetComponent<PuzzlePiece>().Active();
            //animator.SetTrigger("Hurt");
        }
        
    }
}
