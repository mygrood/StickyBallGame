using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundSegment : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPrefabs;
    [SerializeField] private int[] objectWeights;
    [SerializeField] private int objectCount = 3;
    [SerializeField] private float spawnDistance = 3f;
    
    private List<GameObject> spawnedObjects = new List<GameObject>();
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SpawnObjects();
    }

    public void RespawnObjects()
    {
        ClearObjects();
        SpawnObjects();
    }

    private void ClearObjects()
    {
        for (int i = spawnedObjects.Count - 1; i >= 0; i--) 
        {
            if (spawnedObjects[i]) 
                Destroy(spawnedObjects[i]);
        }
        spawnedObjects.Clear();
    }

    private void SpawnObjects()
    {
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 position = GetRandomPosition();
            
            position = GetFreePosition(position);
            
            int index = GetRandomIndex(objectWeights);
            GameObject obj = Instantiate(objectPrefabs[index], position, Quaternion.identity);
            
            spawnedObjects.Add(obj);
        }
    }
    
    private int GetRandomIndex(int[] weights)
    {
        int totalWeight = 0;
        foreach (var weight in weights)
        {
            totalWeight += weight;
        }

        int randomValue = Random.Range(0, totalWeight);
        int runningTotal = 0;

        for (int i = 0; i < weights.Length; i++)
        {
            runningTotal += weights[i];
            if (randomValue < runningTotal)
            {
                return i;
            }
        }
        return weights.Length - 1;
    }
    
    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(spriteRenderer.bounds.min.x, spriteRenderer.bounds.max.x);
        float randomY = Random.Range(spriteRenderer.bounds.min.y, spriteRenderer.bounds.max.y);
        return new Vector3(randomX, randomY, 0);
    }

    private Vector3 GetFreePosition(Vector3 position)
    {
        int maxAttempts = 50; 
        int attempts = 0;

        while (Physics2D.OverlapCircle(position, spawnDistance) != null)
        {
            position = GetRandomPosition();
            attempts++;
            if (attempts >= maxAttempts)
            {
                Debug.LogWarning("Не удалось найти свободное место для объекта!");
                break;
            }
        }
        return position;
    }
    
}