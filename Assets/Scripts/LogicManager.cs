using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
   public Text healthText;

   public GameObject gameOverScreen;

   public int health = 3;

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
      health = 3;
      healthText.text = health.ToString();
   }

   public void GameOver(){
      gameOverScreen.SetActive(true);
   }
}
