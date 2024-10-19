using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum SpawnType
{
    Ground,
    Ground2,
    Sky,
    Sky2
}

[Serializable]
public struct SpawnData
{
    public GameObject Object;
    public SpawnType Type;
}

public class GameManager : MonoBehaviour
{
    public List<SpawnData> SpawnDatas;
    public float GameScrollSpeed = 7;
    public float SpawnDelay = 3;

    public float ColorChangePeriod = 5;
    public float ColorTime = 0;

    public Camera cameraRef;

    private float spawnCooldown;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ColorTime < ColorChangePeriod)
        {
            ColorTime += Time.deltaTime;
        }
        else
        {
            ColorTime = 0;
            cameraRef.backgroundColor = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f)); //new Color(UnityEngine.Random.Range(0, 255), UnityEngine.Random.Range(0, 255), UnityEngine.Random.Range(0, 255), 1)
        }

        if (spawnCooldown < SpawnDelay)
        {
            spawnCooldown += Time.deltaTime;
        }
        else
        {
            spawnCooldown = UnityEngine.Random.Range(0, 2f);
            var spawnData = SpawnDatas[UnityEngine.Random.Range(0, SpawnDatas.Count)];
            var newObject = Instantiate(spawnData.Object);
            newObject.transform.position = new Vector2(10, GetYBySpawnType(spawnData.Type));
            newObject.GetComponent<ObstacleController>().Speed = GameScrollSpeed;
        }
    }

    float GetYBySpawnType(SpawnType st)
    {
        switch (st)
        {
            case SpawnType.Ground:
                return -2.1f;
            case SpawnType.Ground2:
                return -1.91f;
            case SpawnType.Sky:
                return -1.5f;
            case SpawnType.Sky2:
                return 0f;
            default:
                return 0;
        }
    }
}
