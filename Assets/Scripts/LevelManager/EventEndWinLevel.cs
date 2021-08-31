using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.LevelManager
{
    class EventEndWinLevel : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            TriggerEndWinLevel(other);
        }
        private void OnCollisionExit2D(Collision2D other)
        {
            TriggerEndWinLevel(other);
        }
        private void OnCollisionStay2D(Collision2D other)
        {
            TriggerEndWinLevel(other);
        }

        private void TriggerEndWinLevel(Collision2D other)
        {
            if (other.gameObject.tag == "Player" && (!other.gameObject.GetComponent<PaperPlanePlayer>().checkIsInmune()))
            {
                GameManager.instance.SceneGameWin();
                //other.gameObject.GetComponent<PaperPlanePlayer>().actionFallingFree();//ToDO:Crear accion caida, no usar la de la pieza
                other.gameObject.GetComponent<PaperPlanePlayer>().UpdatePassingTime();//ToDo: esto deberia implementarse en otra logica interna dentro de las acciones que puede sufrir el jugador
                Debug.Log("Partida terminada");//ToDo: crear final de partida
            }

        }
    }
}