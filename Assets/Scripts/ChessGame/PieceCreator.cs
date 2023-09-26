using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] piecesPrefabs;
    [SerializeField] private Material blackMaterial;
    [SerializeField] private Material whiteMaterial;

    private Dictionary<string, GameObject> nameToPieceDict = new Dictionary<string, GameObject>();

    private void Awake()
    {
        foreach (var piece in piecesPrefabs)
        {
            nameToPieceDict.Add(piece.GetComponent<Piece>().GetType().ToString(), piece); //Gets type from prefab's Piece.cs component, eg. Piece:Rook Piece:Bishop and adds to dictionary
        }
    }
    public GameObject CreatePiece(Type type) //Called by ChessGameController to instantiate pieces 
    {
        GameObject prefab = nameToPieceDict[type.ToString()]; //Checks dictionary to see if this piece exists in piecesPrefabs array
        if(prefab)
        {
            GameObject newPiece = Instantiate(prefab);
            return prefab;
        }
        return null;
    }
    public Material GetTeamMaterial(TeamColor team)
    {
        return team == TeamColor.White ? whiteMaterial : blackMaterial;
    }
}
