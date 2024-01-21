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

    public LogicManager logic;

    // Start is called before the first frame update
    void Start()
    {
        SpawnDementor();
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(logic.level < 5){
            spawnRate = 2 - logic.level * 0.3f;
        }

        if(timer < spawnRate){
            timer += Time.deltaTime;
        }
        else{
            if(logic.activeGame){
                SpawnDementor();
            }
            timer = 0;
        }
    }

    void SpawnDementor(){
        dementorCounter++;
        float lowestPoint = transform.position.y - heighOffset - 1f;
        float highestPoint = transform.position.y + heighOffset;

        Instantiate(dementor, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
