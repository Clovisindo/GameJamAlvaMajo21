using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PuzzlePieces
{
    class PiecelLevelCoin : PuzzlePiece
    {
        protected override void Awake()
        {
            typePP = Enums.EnumTypePuzzlePiece.PiecelLevelCoin;
            awakeBehaviour();
        }
        /// <summary>
        /// Accion que aplica al jugador
        /// </summary>
        protected override void ActiveAction()
        {
            ScoreManager.ScoreManager.instance.AddScore(500);
            Destroy(gameObject);
            //GameManager.instance.player.GetComponent<PaperPlanePlayer>().actionCleanHazards();
            //ApplyScorePiecePuzzle(Score, typePP);
        }
    }
}
