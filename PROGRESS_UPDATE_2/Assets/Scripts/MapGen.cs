using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGen : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tile;
    public int width = 1000;
    public int height = 1000;

    void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }
}
