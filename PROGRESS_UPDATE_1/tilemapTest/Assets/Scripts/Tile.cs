using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Sprite Tile", menuName = "Tiles/Sprite Tile")]
public class Tile : TileBase
{
    public Sprite sprite;

    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        tileData.sprite = sprite;
    }
}
