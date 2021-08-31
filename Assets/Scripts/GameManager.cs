using Assets.Scripts.ScoreManager;
using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public GameObject gameCamera;
    public GameObject player;
    public measureToolLevel mTool;

    private LaneManager laneManager;
    private Text textRestartGame;

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
        laneManager = this.GetComponent<LaneManager>();
        textRestartGame = GameObject.FindGameObjectWithTag("RestartGame").GetComponent<Text>();
        mTool = new measureToolLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            reGame();
        }
    }

    public void ResetGame()
    {
        player.GetComponent<PaperPlanePlayer>().ResetPlayer();
        player.GetComponent<PaperPlanePlayer>().PlayerDeath = false;
        DisableTestReset();
    }
    public void EnableTestReset()
    {
        textRestartGame.enabled = true;
    }
    public void DisableTestReset()
    {
        textRestartGame.enabled = false;
    }

    public void SceneGameEnded()
    {
        player.GetComponent<PaperPlanePlayer>().StopPlayer();
        EnableTestReset();
    }
    public void reGame()
    {
        //SceneManager.LoadScene("gameScene");
        ScoreManager.instance.ResetScore();
        ResetGame();
        laneManager.InitializeLaneManager();
        laneManager.DestroyAllPieces();

    }
}
