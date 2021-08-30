using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PuzzlePieces
{
    class PieceLevelSun:PuzzlePiece
    {
        protected override void Awake()
        {
            typePP = Enums.EnumTypePuzzlePiece.PieceLevelSun;
            awakeBehaviour();
        }
        /// <summary>
        /// Accion que aplica al jugador
        /// </summary>
        protected override void ActiveAction()
        {
            GameManager.instance.player.GetComponent<PaperPlanePlayer>().actionCleanHazards();
            //ApplyScorePiecePuzzle(Score, typePP);
        }
    }
}
