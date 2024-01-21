using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dementorMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;

    public float deadZone = -45;

    public LogicManager logic; 

    private Animator animator;

    private bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {
      animator = GetComponent<Animator>();  
      logic = GameObject.FindWithTag("Logic").GetComponent<LogicManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
      transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

      if(transform.position.x < deadZone || !logic.activeGame){
        Destroy(gameObject);
      }

      moveSpeed = 5 + logic.level * 0.4f;
   }

    void OnTriggerEnter2D(Collider2D other){
        
        if(other.gameObject.tag == "Bridge"){
            SoundManager.PlaySound("crucioSpell");
            if (!hasCollided){
                logic.RemoveHealth();
                hasCollided = !hasCollided;
            }
            moveSpeed = 0;
            animator.SetTrigger("Rotate");

            StartCoroutine(DestroyGameObjectAfterDelay(1f));
        }
        else if(other.gameObject.tag == "projectile")
        {
            SoundManager.PlaySound("death");
        }

        Destroy(gameObject);
    }

    IEnumerator DestroyGameObjectAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Destroy the GameObject this script is attached to
        Destroy(gameObject);
    }

}
