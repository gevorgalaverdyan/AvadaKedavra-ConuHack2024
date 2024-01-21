using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dementorMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;

    public float deadZone = -45;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
      animator = GetComponent<Animator>();  
    }
    // Update is called once per frame
    void Update()
    {
      transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

      if(transform.position.x < deadZone){
        Destroy(gameObject);
      }
    }

    void OnTriggerEnter2D(Collider2D other){
      moveSpeed = 0;
      animator.SetTrigger("Rotate");

      StartCoroutine(DestroyGameObjectAfterDelay(1f));
    }

    IEnumerator DestroyGameObjectAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Destroy the GameObject this script is attached to
        Destroy(gameObject);
    }

}
