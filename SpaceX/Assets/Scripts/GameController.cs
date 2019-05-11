using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startwait;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

   IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startwait);
        for (int i=0; i<hazardCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Instantiate(hazard, spawnPosition, Quaternion.identity);
        }
        
    }

   
}
