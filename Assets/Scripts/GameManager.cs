using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public GameObject gameCamera;
    public GameObject player;
    public measureToolLevel mTool;

    int layer_mask_wall;

    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 60;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
       
        gameCamera = GameObject.FindGameObjectWithTag("MainCamera");
        layer_mask_wall = LayerMask.GetMask("ColliderRoomDetector");
        player = GameObject.FindGameObjectWithTag("Player");
        mTool = new measureToolLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
