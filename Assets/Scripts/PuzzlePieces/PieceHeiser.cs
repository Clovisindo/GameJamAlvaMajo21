using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PuzzlePieces
{
    class PieceHeiser:PuzzlePiece
    {
        protected override void Awake()
        {
            KeyPuzzlePiece = KeyCode.C;
            typePP = Enums.EnumTypePuzzlePiece.PieceInverseAir;
            awakeBehaviour();
        }

        /// <summary>
        /// Accion que aplica al jugador
        /// </summary>
        protected override void ActiveAction()
        {
            GameManager.instance.player.GetComponent<PaperPlanePlayer>().actionInverseAcelerationc();
            ApplyScorePiecePuzzle(Score, typePP);
        }
    }
}
