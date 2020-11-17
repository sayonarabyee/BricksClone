using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    [SerializeField] Brick brickPrefab;
    private int playWidth = 8;
    private float distanceBetweenBlocks = .9f;
    private int rowsSpawned;

    private List<Brick> bricksSpawned = new List<Brick>();

    private void OnEnable()
    {
        for (int i = 0; i < 1; i++)
        {
            SpawnBlocks();
        }
    }
    public void SpawnBlocks()
    {
        foreach (var brick in bricksSpawned)
        {
            if (brick != null)
            {
                brick.transform.position += Vector3.down * distanceBetweenBlocks;
            }
        }

        for (int i = 0; i < playWidth; i++)
        {
            if (Random.Range(0, 60) <= (30))
            {
                var brick = Instantiate(brickPrefab, GetPosition(i), Quaternion.identity);
                int hits = Random.Range(1, 3) + rowsSpawned;

                brick.SetHits(hits);

                bricksSpawned.Add(brick);
            }
        }
        rowsSpawned++;
    }

    private Vector3 GetPosition(int i)
    {
        Vector3 position = transform.position;
        position += Vector3.right * i * distanceBetweenBlocks;
        return position;
    }
}
