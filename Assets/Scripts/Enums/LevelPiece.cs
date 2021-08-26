using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Enums
{
    public class LevelPiece
    {
        EnumTypePuzzlePiece typePiece;
        bool pieceGenerated;

        public EnumTypePuzzlePiece TypePiece { get => typePiece; set => typePiece = value; }
        public bool PieceGenerated { get => pieceGenerated; set => pieceGenerated = value; }

        public LevelPiece(EnumTypePuzzlePiece TypePiece, bool PieceGenerated)
        {
            typePiece = TypePiece;
            pieceGenerated = PieceGenerated;
        }
    }
}
