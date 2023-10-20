using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class IslandPrefab
{
    public GameObject prefab;
    public bool generateOnlyOnce;
}

public class MapGen : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject oceanPrefab; // Prefab with SpriteRenderer component for ocean
    public IslandPrefab[] islandPrefabs; // Array of island prefabs
    public int mapWidth = 100; // Increase map width and height for a larger ocean
    public int mapHeight = 100;
    public int islandCount = 10; // Number of islands
    public int islandPadding = 10; // Minimum distance between islands and map boundary

    private List<Vector3Int> usedPositions = new List<Vector3Int>(); // Keep track of used island positions

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
            Vector3Int islandPosition;
            IslandPrefab selectedIslandPrefab = GetRandomIslandPrefab();

            if (selectedIslandPrefab.generateOnlyOnce)
            {
                islandPosition = GetUniqueRandomPosition(selectedIslandPrefab.prefab.transform);
            }
            else
            {
                islandPosition = GetRandomPosition(selectedIslandPrefab.prefab.transform);
            }

            // Create the island by instantiating the selected prefab
            Instantiate(selectedIslandPrefab.prefab, tilemap.GetCellCenterWorld(islandPosition), Quaternion.identity, tilemap.transform);
        }
    }

    Vector3Int GetUniqueRandomPosition(Transform islandPrefab)
    {
        Vector3Int randomPosition;
        Bounds islandBounds = islandPrefab.GetComponent<SpriteRenderer>().bounds;

        do
        {
            randomPosition = new Vector3Int(
                Random.Range(islandPadding, mapWidth - islandPadding),
                Random.Range(islandPadding, mapHeight - islandPadding),
                0
            );
        } while (usedPositions.Contains(randomPosition) || IsOverlapWithIsland(randomPosition, islandBounds));

        usedPositions.Add(randomPosition);
        return randomPosition;
    }

    Vector3Int GetRandomPosition(Transform islandPrefab)
    {
        Bounds islandBounds = islandPrefab.GetComponent<SpriteRenderer>().bounds;
        Vector3Int randomPosition;

        do
        {
            randomPosition = new Vector3Int(
                Random.Range(islandPadding, mapWidth - islandPadding),
                Random.Range(islandPadding, mapHeight - islandPadding),
                0
            );
        } while (IsOverlapWithIsland(randomPosition, islandBounds));

        return randomPosition;
    }

    bool IsOverlapWithIsland(Vector3Int position, Bounds islandBounds)
    {
        foreach (Vector3Int usedPosition in usedPositions)
        {
            if (islandBounds.Contains(tilemap.GetCellCenterWorld(usedPosition) - tilemap.cellSize * 0.5f))
            {
                return true;
            }
        }
        return false;
    }

    IslandPrefab GetRandomIslandPrefab()
    {
        List<IslandPrefab> availableIslandPrefabs = new List<IslandPrefab>();

        foreach (var islandPrefab in islandPrefabs)
        {
            if (!islandPrefab.generateOnlyOnce || !usedPositions.Exists(p => p == islandPrefab.prefab.transform.position))
            {
                availableIslandPrefabs.Add(islandPrefab);
            }
        }

        if (availableIslandPrefabs.Count == 0)
        {
            // All generate-only-once islands have been used, so allow random generation
            return islandPrefabs[Random.Range(0, islandPrefabs.Length)];
        }

        return availableIslandPrefabs[Random.Range(0, availableIslandPrefabs.Count)];
    }
}
