using UnityEngine;
using System.Collections.Generic;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;  // Assign bubble prefab in the inspector!!!
    public int maxBubbles = 5;       // Desired number of bubbles on screen at any time
    public float spawnY = -5f;       // Y position to spawn bubbles (bottom of the screen)
    public float spawnXMin = -8f;    // Minimum X position
    public float spawnXMax = 8f;     // Maximum X position

    private List<GameObject> activeBubbles = new List<GameObject>();

    void Start()
    {
        SpawnInitialBubbles();
    }

    void Update()
    {
        CheckAndSpawnBubbles();
    }

    void SpawnInitialBubbles()
    {
        for (int i = 0; i < maxBubbles; i++)
        {
            SpawnBubble();
        }
    }

    void CheckAndSpawnBubbles()
    {
        // Remove destroyed bubbles from the list
        activeBubbles.RemoveAll(b => b == null);

        // Spawn new bubbles if needed
        while (activeBubbles.Count < maxBubbles)
        {
            SpawnBubble();
        }
    }

    void SpawnBubble()
    {
        float randomX = Random.Range(spawnXMin, spawnXMax);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);
        GameObject newBubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);
        activeBubbles.Add(newBubble);
    }
}

