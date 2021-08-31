using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PuzzlePieces
{
    class PieceDown:PuzzlePiece
    {
        protected override void Awake()
        {
            KeyPuzzlePiece = KeyCode.X;
            typePP = Enums.EnumTypePuzzlePiece.PieceDown;
            awakeBehaviour();
        }
        /// <summary>
        /// Accion que aplica al jugador
        /// </summary>
        protected override void ActiveAction()
        {
            GameManager.instance.player.GetComponent<PaperPlanePlayer>().actionFallSingle();
            ApplyScorePiecePuzzle(Score, typePP);
        }
    }
}
