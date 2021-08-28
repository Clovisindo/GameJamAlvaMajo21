using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class measureToolLevel : MonoBehaviour
    {

       

        /// <summary>
        /// devuelve la diferencia de altura
        /// </summary>
        /// <param name="playerPosition"></param>
        /// <returns></returns>
        public double MeasureHigh(Vector2 playerPosition, Vector2 initialHeightPosition)
        {
            return Math.Round(playerPosition.y- initialHeightPosition.y);
        }

        /// <summary>
        /// devuelve la diferencia de longitud
        /// </summary>
        /// <param name="playerPosition"></param>
        /// <returns></returns>
        public float MeasureLenght(Vector2 playerPosition, Vector2 EndingLevelPosition)
        {
            return EndingLevelPosition.x - playerPosition.x;
        }
    }
}
