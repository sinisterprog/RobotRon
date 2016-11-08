using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public GameObject[] hazards;
    public int hazardCount;

    // Use this for initialization
    void Start () {
        SpawnWaves();

    }
    void SpawnWaves()
    {

 
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[UnityEngine.Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-50, 50), 0, UnityEngine.Random.Range(-50, 50));
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
            }
        
    }

}
