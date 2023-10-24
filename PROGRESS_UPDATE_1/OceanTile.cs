using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OceanTile : MonoBehaviour
{
    public Tilemap oceanTilemap; // Reference to the ocean Tilemap

    public bool IsOverOcean(Vector3 position)
    {
        Vector3Int cellPosition = oceanTilemap.WorldToCell(position);
        TileBase tile = oceanTilemap.GetTile(cellPosition);

        return tile != null;
    }
}