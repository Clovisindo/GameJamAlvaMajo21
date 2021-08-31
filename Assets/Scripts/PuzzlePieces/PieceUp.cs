
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PuzzlePieces
{
    class PieceUp : PuzzlePiece
    {
        protected override void Awake()
        {
            KeyPuzzlePiece = KeyCode.Z;
            typePP = Enums.EnumTypePuzzlePiece.pieceUp;
            awakeBehaviour();
        }

        /// <summary>
        /// Accion que aplica al jugador
        /// </summary>
        protected override void ActiveAction()
        {
            GameManager.instance.player.GetComponent<PaperPlanePlayer>().actionJumpSingle();
            ApplyScorePiecePuzzle(Score, typePP);
        }
    }
}
