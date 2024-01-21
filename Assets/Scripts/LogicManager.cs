using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class LogicManager : MonoBehaviour
{
   public Text healthText;

   public Text levelText;

   public GameObject gameOverScreen;

   public DementorSpawnScript dementorSpawn;

   public int health = 3;

   public int level = 1;

   public bool activeGame = true;
   
   private float timer = 0f;

   void Start()
    {
        dementorSpawn = GameObject.Find("DementorSpawner").GetComponent<DementorSpawnScript>();
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
        levelText.text = "Level: " + level.ToString();
    }
   
   [ContextMenu("Remove Health")]
   public void RemoveHealth(){
      health--; 
      if(health <= 0){
         GameOver();
      } 
      healthText.text = health.ToString(); 
   }

   [ContextMenu("Restart Game")]
   public void RestartGame(){
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      activeGame = true;
      health = 3;
      healthText.text = "Remaining Health: " + health.ToString();
   }

   public void GameOver(){
      gameOverScreen.SetActive(true);
      activeGame = false;
   }
}
