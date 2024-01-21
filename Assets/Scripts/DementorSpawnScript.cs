using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DementorSpawnScript : MonoBehaviour
{
    public GameObject dementor;
    public int dementorCounter = 0;

    // seconds between each spawn
    public float spawnRate = 2;
    public float timer = 0;

    public float heighOffset = 6.5f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnDementor();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate){
            timer += Time.deltaTime;
        }
        else{
            SpawnDementor();
            timer = 0;
        }
    }

    void SpawnDementor(){
        dementorCounter++;
        float lowestPoint = transform.position.y - heighOffset - 0.5f;
        float highestPoint = transform.position.y + heighOffset;

        Instantiate(dementor, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
