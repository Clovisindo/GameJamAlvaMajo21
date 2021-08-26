﻿using Assets.Scripts;
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
    private int totalPieces = 50;
    [SerializeField]
    private GameObject PieceUpPrefab;
    [SerializeField]
    private GameObject PieceDownPrefab;
    [SerializeField]
    private GameObject RespawnPieces;
    [SerializeField]
    private Canvas canvasLevel;


    LevelPiece[] laneLevelPieces ;
    int iteratorPieces = 0;

    private void Awake()
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
        return 0;
    }
}
