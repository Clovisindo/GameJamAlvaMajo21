using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceSelector : MonoBehaviour
{
    private RawImage sr;
    public Texture2D defaultImage;
    public Texture2D pressedImage;

    public AudioClip pieceActiveClip;

    public KeyCode keyToPressZ = KeyCode.Z;
    public KeyCode keyToPressX = KeyCode.X;
    public KeyCode keyToPressC = KeyCode.C;
    public KeyCode keyToPressV = KeyCode.V;



    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPressZ) || Input.GetKeyDown(keyToPressX) || Input.GetKeyDown(keyToPressC) || Input.GetKeyDown(keyToPressV))
        {
            sr.texture = pressedImage;
        }

        if (Input.GetKeyUp(keyToPressZ) || Input.GetKeyUp(keyToPressX) || Input.GetKeyUp(keyToPressC) || Input.GetKeyUp(keyToPressV))
        {
            sr.texture = defaultImage;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Input.GetKeyDown(other.gameObject.GetComponent<PuzzlePiece>().KeyPuzzlePiece))
        {
            CheckCurrentPPColl(other);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (Input.GetKeyDown(other.gameObject.GetComponent<PuzzlePiece>().KeyPuzzlePiece))
        {
            CheckCurrentPPColl(other);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (Input.GetKeyDown(other.gameObject.GetComponent<PuzzlePiece>().KeyPuzzlePiece))
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
            SoundManager.instance.PlaySingle(pieceActiveClip);
            Debug.Log("efecto pieza activado");
        }
    }
}
