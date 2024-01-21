using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class levels : MonoBehaviour
{
    public int level;
    public DementorSpawnScript dementorSpawn;
    public GameObject dementorSpawner;
    public GameObject ui;
    public TextMeshProUGUI text;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        dementorSpawner = GameObject.Find("DementorSpawner");
        dementorSpawn = dementorSpawner.GetComponent<DementorSpawnScript>();
        ui = GameObject.Find("level");
        text = ui.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer = 0f;
        }
        else
        {
            level = 1 +  dementorSpawn.dementorCounter / 10;
        }
        text.SetText("Level: " + level);
    }
}
