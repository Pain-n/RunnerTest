using System;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public GameObject WaterSpotPrefab, WaterFallPrefab, Fire;

    public List<WayRow> WayPartsInRows;
    private void Start()
    {
        GenerateEnvironment();
    }

    private void GenerateEnvironment()
    {
        int randomValue = 0;
        GameObject spawnedObject = null;
        foreach (var row in WayPartsInRows)
        {
            bool isAllTraps = true;
            for (int i = 0; i < row.WayParts.Count; i++)
            {
                if (i == row.WayParts.Count-1 && isAllTraps) break;

                randomValue = UnityEngine.Random.Range(0, 4);
                switch (randomValue) 
                { 
                    case 0:
                        isAllTraps = false;
                        break;
                    case 1:
                        spawnedObject = Instantiate(WaterSpotPrefab, transform);
                        spawnedObject.transform.position = row.WayParts[i].position;
                        break;
                    case 2:
                        spawnedObject = Instantiate(WaterFallPrefab, transform);
                        spawnedObject.transform.position = new Vector3(row.WayParts[i].position.x, row.WayParts[i].position.y + 3, row.WayParts[i].position.z);
                        break;
                    case 3:
                        spawnedObject = Instantiate(Fire, transform);
                        spawnedObject.transform.position = row.WayParts[i].position;
                        break;
                }
            }
        }
    }
}

[Serializable]
public class WayRow
{
    public List<Transform> WayParts;
}
