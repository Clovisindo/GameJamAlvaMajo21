using Assets.Scripts.ScoreManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{

    public GameObject gameManager;
    public GameObject soundManager;
    public GameObject scoreManager;



    // Start is called before the first frame update
    void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
        if (SoundManager.instance == null)
        {
            Instantiate(soundManager);
        }
        if (ScoreManager.instance == null)
        {
            Instantiate(scoreManager);
        }
    }
}
