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

   public UDPReceive udpReceive;

   public GameObject fullBridge;

   public GameObject crackedBridge;

   public GameObject collapsingBridge;

   public GameObject player;

   public int health = 3;

   public int level = 1;

   public bool activeGame = true;

   private float timer = 0f;

   void Start()
   {
      dementorSpawn = GameObject.Find("DementorSpawner").GetComponent<DementorSpawnScript>();
      udpReceive = GameObject.Find("InputReceiver").GetComponent<UDPReceive>();
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
         level = 1 + dementorSpawn.dementorCounter / 10;
      }
      levelText.text = "Level: " + level.ToString();
      UpdateBridgeState();
   }

   [ContextMenu("Remove Health")]
   public void RemoveHealth()
   {
      health--;
      if (health <= 0)
      {
         GameOver();
      }

      healthText.text = "Health: " + health.ToString();
   }

   [ContextMenu("Restart Game")]
   public void RestartGame()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      activeGame = true;
      health = 3;
      healthText.text = "Health: " + health.ToString();
   }

   public void GameOver()
   {
      SoundManager.PlaySound("gameOver");
      udpReceive.startRecieving = false;
      player.SetActive(false);
      gameOverScreen.SetActive(true);
      activeGame = false;
   }

   private void UpdateBridgeState()
   {
      if (health == 1)
      {
         healthText.color = Color.red;
         fullBridge.SetActive(false);
         crackedBridge.SetActive(false);
         collapsingBridge.SetActive(true);
      }
      else if (health == 2)
      {
         healthText.color = Color.yellow;
         fullBridge.SetActive(false);
         crackedBridge.SetActive(true);
         collapsingBridge.SetActive(false);
      }
      else if (health == 3)
      {
         healthText.color = Color.green;
         fullBridge.SetActive(true);
         crackedBridge.SetActive(false);
         collapsingBridge.SetActive(false);
      }
      else
      {
         fullBridge.SetActive(false);
         crackedBridge.SetActive(false);
         collapsingBridge.SetActive(false);
      }
   }
}
