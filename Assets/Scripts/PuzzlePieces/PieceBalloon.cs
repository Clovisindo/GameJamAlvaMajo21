using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PuzzlePieces
{
    class PieceBalloon:PuzzlePiece
    {
        protected override void Awake()
        {
            KeyPuzzlePiece = KeyCode.V;
            typePP = Enums.EnumTypePuzzlePiece.PieceBalloonSlow;
            awakeBehaviour();
        }

        /// <summary>
        /// Accion que aplica al jugador
        /// </summary>
        protected override void ActiveAction()
        {
            GameManager.instance.player.GetComponent<PaperPlanePlayer>().actionSlowBalloon();
            ApplyScorePiecePuzzle(Score, typePP);
        }
    }
}
