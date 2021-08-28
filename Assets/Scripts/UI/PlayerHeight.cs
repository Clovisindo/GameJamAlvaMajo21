using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class PlayerHeight : MonoBehaviour
    {
        [SerializeField]
        private Text currentPlayerHeight;
        [SerializeField]
        private GameObject initialHeightPosition;
        [SerializeField]
        private GameObject EndingLevelPosition;

        private void Awake()
        {
            
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            UpdateCurrentHeight();
        }

        public void UpdateCurrentHeight()
        {
            currentPlayerHeight.text = GameManager.instance.mTool.MeasureHigh(GameManager.instance.player.transform.position,
                initialHeightPosition.transform.position).ToString();
        }
    }
}
