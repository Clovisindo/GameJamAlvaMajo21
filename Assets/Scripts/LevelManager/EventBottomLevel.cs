using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.LevelManager
{
    public class EventBottomLevel : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            TriggerBottomLevel(other);
        }
        private void OnCollisionExit2D(Collision2D other)
        {
            TriggerBottomLevel(other);
        }
        private void OnCollisionStay2D(Collision2D other)
        {
            TriggerBottomLevel(other);
        }

        private void TriggerBottomLevel(Collision2D other)
        {
            if (other.gameObject.tag == "Player" && (!other.gameObject.GetComponent<PaperPlanePlayer>().checkIsInmune()))
            {
                GameManager.instance.SceneGameEnded();

                other.gameObject.GetComponent<PaperPlanePlayer>().UpdatePassingTime();//ToDo: esto deberia implementarse en otra logica interna dentro de las acciones que puede sufrir el jugador
            }

        }
    }
}
