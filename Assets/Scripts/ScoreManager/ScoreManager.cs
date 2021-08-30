using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ScoreManager
{
    public class ScoreManager:MonoBehaviour
    {
        private int multiplier = 1;
        private int currentScore = 0;
        public static ScoreManager instance = null;
        List<EnumTypePuzzlePiece> arrayPieces = new List<EnumTypePuzzlePiece>();

        [SerializeField]
        private Text currentScoreUI;
        [SerializeField]
        private Text currentMultiScoreUI;

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != null)
                Destroy(gameObject);


            currentScoreUI = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
            currentMultiScoreUI = GameObject.FindGameObjectWithTag("MultiplierText").GetComponent<Text>();
            DontDestroyOnLoad(gameObject);
        }
            public void AddScore(int ppScore)
        {
            currentScore += ppScore * multiplier;
            UpdateCurrentScore();
            Debug.Log("Sumas " + ppScore * multiplier + " puntos.");
        }

        public void UpdateCurrentScore()
        {
            currentScoreUI.text = "Puntos :" +  currentScore.ToString();
        }

        public void ApplyMultiplier(EnumTypePuzzlePiece currentTypePP)
        {
            if (arrayPieces.LastOrDefault() != currentTypePP)//no aplica multiplicador
            {
                arrayPieces = new List<EnumTypePuzzlePiece>();
                var count = arrayPieces.Count();
                UpdateMultiplier(count);
            }
            else
            {
                arrayPieces.Add(currentTypePP);
                var count = arrayPieces.Count();
                UpdateMultiplier(count);
            }
        }
        public void UpdateMultiplier(int newMultiplier)
        {
            if (newMultiplier > 5) { newMultiplier = 5; }
            if (newMultiplier == 0) { newMultiplier = 1; }
            multiplier = newMultiplier;
            currentMultiScoreUI.text = "Combo :" + multiplier.ToString();
        }
    }
}
