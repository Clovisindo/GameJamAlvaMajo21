using Assets.Scripts;
using Assets.Scripts.Enums;
using Assets.Scripts.PuzzlePieces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    [SerializeField]
    private float spawnRatePerMinute = 30;//spawnRate
    private int currentCount = 0;// Current spawn count
    private int totalPieces = 200;
    [SerializeField]
    private GameObject PieceUpPrefab;
    [SerializeField]
    private GameObject PieceDownPrefab;
    [SerializeField]
    private GameObject PieceInverseAirPrefab;
    [SerializeField]
    private GameObject PieceBalloonSlowPrefab;
    [SerializeField]
    private GameObject RespawnPieces;
    private GameObject canvasLevel;


    LevelPiece[] laneLevelPieces ;
    int iteratorPieces = 0;

    private void Start()
    {
        canvasLevel = GameObject.FindGameObjectWithTag("CanvasLevel");
        InitializeLaneManager();
    }

    /// <summary>
    /// Unity's method called every frame
    /// </summary>
    private void Update()
    {
        var targetCount = Time.time * (spawnRatePerMinute / 60);
        while (targetCount > currentCount)
        {
            if (laneLevelPieces[iteratorPieces].PieceGenerated == false)
            {
                EnumTypePuzzlePiece newPiece = laneLevelPieces[iteratorPieces].TypePiece;
                
                var instancePrefabPiece = GetFactoryRespawnByType(newPiece);
                Vector2 positionRespawn = RespawnPieces.transform.position;
                instancePrefabPiece.transform.position = new Vector3(positionRespawn.x, positionRespawn.y, 0);
                var gameObject = Instantiate(instancePrefabPiece);
                gameObject.transform.SetParent(canvasLevel.transform, false);

                laneLevelPieces[iteratorPieces].PieceGenerated = true;
                currentCount++;
                iteratorPieces++;
            }
            
        }
    }
    public void InitializeLaneManager()
    {
        laneLevelPieces = new LevelPiece[totalPieces];
        int randTypeIndex = 0;
        for (int i = 0; i < totalPieces; i++)
        {
            randTypeIndex = UnityEngine.Random.Range(1, Enum.GetNames(typeof(EnumTypePuzzlePiece)).Length + 1);//modificar si se meten mas tipos piezas
            EnumTypePuzzlePiece newTypeRandom = GetTypePieceByRandom(randTypeIndex);
            laneLevelPieces[i] = new LevelPiece(newTypeRandom, false);
        }
    }

    public void DestroyAllPieces()
    {
        var destroyPPs = GameObject.FindGameObjectsWithTag("PuzzlePiece");
        foreach (var destroyPP in destroyPPs)
        {
            Destroy(destroyPP);
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
        if (typePiece == EnumTypePuzzlePiece.PieceBalloonSlow)
        {
            return PieceBalloonSlowPrefab;
        }
        if (typePiece == EnumTypePuzzlePiece.PieceInverseAir)
        {
            return PieceInverseAirPrefab;
        }
        return null;
    }

    private EnumTypePuzzlePiece GetTypePieceByRandom(int randTypeIndex)
    {
        if (randTypeIndex == 1)
        {
            return EnumTypePuzzlePiece.pieceUp;
        }
        if (randTypeIndex == 2)
        {
            return EnumTypePuzzlePiece.PieceDown;
        }
        if (randTypeIndex == 3)
        {
            return EnumTypePuzzlePiece.PieceBalloonSlow;
        }
        if (randTypeIndex == 4)
        {
            return EnumTypePuzzlePiece.PieceInverseAir;
        }
        return 0;
    }
}
