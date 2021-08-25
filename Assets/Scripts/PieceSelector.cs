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
        if (Input.GetKeyDown(keyToPress))//añadir aqui todas las teclas disponibles para todas las piezas
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
        if (Input.anyKeyDown)
        {
            CheckCurrentPPColl(other);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (Input.anyKeyDown)
        {
            CheckCurrentPPColl(other);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (Input.anyKeyDown)
        {
            CheckCurrentPPColl(other);
        }

    }

    private void CheckCurrentPPColl(Collision2D other)
    {
        PuzzlePiece currentPP = other.gameObject.GetComponent<PuzzlePiece>();
        if (Input.GetKeyDown(currentPP.KeyPuzzlePiece) && other.gameObject.tag == "PuzzlePiece" && (!currentPP.checkIsInmune()))
        {
            GameObject puzzlePieceColl = other.gameObject;
            //other.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            currentPP.Active();
            Debug.Log("efecto pieza activado");
        }
    }
}
