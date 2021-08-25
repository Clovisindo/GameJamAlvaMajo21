using Assets.Scripts.Enums;
using Assets.Scripts.PuzzlePieces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    [SerializeField]
    private float spawnRatePerMinute = 30;//spawnRate
    private int currentCount = 0;// Current spawn count
    [SerializeField]
    private GameObject PieceUpPrefab;
    [SerializeField]
    private GameObject PieceDownPrefab;
    [SerializeField]
    private GameObject RespawnPieces;
    [SerializeField]
    private Canvas canvasLevel;




    /// <summary>
    /// Unity's method called every frame
    /// </summary>
    private void Update()
    {
        var targetCount = Time.time * (spawnRatePerMinute / 60);
        while (targetCount > currentCount)
        {
            // leer de un array que pieza toda spawnear

            //pendiente control cuales se han generado y cuales no

            // aqui decidimos que factory invocamos
            var inst = GetFactoryRespawnByType(EnumTypePuzzlePiece.pieceUp);
            Vector2 positionRespawn = RespawnPieces.transform.position;
            inst.transform.position = new Vector3(positionRespawn.x, positionRespawn.y, 0);
            var gameObject = Instantiate(inst);
            gameObject.transform.SetParent(canvasLevel.transform,false);
            //gameObject.GetComponent<RectTransform>().position = inst.transform.position;
            currentCount++;
        }
    }

    private GameObject GetFactoryRespawnByType(EnumTypePuzzlePiece typePiece)
    {
        if (typePiece == EnumTypePuzzlePiece.pieceUp)
        {
            return PieceUpPrefab;
        }
        if (typePiece == EnumTypePuzzlePiece.PieceDown)
        {
            return PieceDownPrefab;
        }
        return null;
    }
}
