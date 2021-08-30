using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.ScoreManager;

namespace Assets.Scripts.PuzzlePieces
{
    class PieceLevelCloud:PuzzlePiece
    {
        protected override void Awake()
        {
            typePP = Enums.EnumTypePuzzlePiece.PieceLevelCloud;
            awakeBehaviour();
        }
        /// <summary>
        /// Accion que aplica al jugador
        /// </summary>
        protected override void ActiveAction()
        {
            GameManager.instance.player.GetComponent<PaperPlanePlayer>().actionApplyHazards();
            //ApplyScorePiecePuzzle(Score, typePP);
        }
    }
}
