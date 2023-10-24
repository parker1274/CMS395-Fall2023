using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGen : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject islandPrefab; // Prefab with SpriteRenderer component for islands
    public GameObject oceanPrefab; // Prefab with SpriteRenderer component for ocean
    public int mapWidth = 100; // Increase map width and height for larger ocean
    public int mapHeight = 100;
    public int islandCount = 10; // Number of islands
    public int minIslandSize = 5;
    public int maxIslandSize = 20;

    void Start()
    {
        GenerateIslands();
    }

    void GenerateIslands()
    {
        // Create the ocean by instantiating oceanPrefabs across the entire map
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                Instantiate(oceanPrefab, tilemap.GetCellCenterWorld(tilePosition), Quaternion.identity, tilemap.transform);
            }
        }

        // Generate random islands
        for (int i = 0; i < islandCount; i++)
        {
            int islandSize = Random.Range(minIslandSize, maxIslandSize + 1);
            Vector3Int islandPosition = new Vector3Int(Random.Range(0, mapWidth), Random.Range(0, mapHeight), 0);

            // Create the island by instantiating islandPrefabs in a square shape
            for (int x = -islandSize; x <= islandSize; x++)
            {
                for (int y = -islandSize; y <= islandSize; y++)
                {
                    Vector3Int tilePosition = islandPosition + new Vector3Int(x, y, 0);
                    if (tilemap.GetTile(tilePosition) == null) // Check if it's not an existing island
                    {
                        Instantiate(islandPrefab, tilemap.GetCellCenterWorld(tilePosition), Quaternion.identity, tilemap.transform);
                    }
                }
            }
        }
    }
}
