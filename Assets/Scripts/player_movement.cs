using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;

    private bool isUsingKeyboard;

    [SerializeField] GameObject inputReceiver;

    private UDPReceive inputRecieverComponent;

    [SerializeField] private float moveSpeed = 3f; // Speed at which the player moves.
    Rigidbody2D body;
    private float verticalInput;
    private Animator anim;

    private void Awake()
    {
       
        Console.WriteLine(inputReceiver);
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = 0;
        inputRecieverComponent = inputReceiver.GetComponent<UDPReceive>();
        isUsingKeyboard = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

        //body.velocity = new Vector2(body.velocity.x, Input.GetAxis("Vertical") * speed);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isUsingKeyboard = !isUsingKeyboard;
        }
        if (isUsingKeyboard)
        {
            // Handle keyboard events
            HandleKeyboardInputs();
        }
        else
        {
            // Handle hand gestures 
            HandleGesturesInputs();
        }

        anim.SetBool("run", verticalInput != 0);
    }

    private void HandleKeyboardInputs()
    {

        // 'moveSpeed' should be defined elsewhere in the class.
        float verticalInput = Input.GetAxis("Vertical");

        // Get the current position.
        Vector3 currentPosition = transform.position;

        // Check if we're moving upwards and if we are below the upper limit.
        if (verticalInput > 0 && currentPosition.y < 6)
        {
            // Calculate the amount to move this frame.
            float movementAmount = verticalInput * moveSpeed * Time.deltaTime;
            // Move the player's transform.
            currentPosition.y += movementAmount;
        }
        // Check if we're moving downwards and if we are above the lower limit.
        else if (verticalInput < 0 && currentPosition.y > -6)
        {
            // Calculate the amount to move this frame.
            float movementAmount = verticalInput * moveSpeed * Time.deltaTime;
            // Move the player's transform.
            currentPosition.y += movementAmount;
        }

        // Apply the position change.
        transform.position = currentPosition;

    }

    private void HandleGesturesInputs() {
        float verticalInput = Input.GetAxis("Vertical");
        // Down
        int direction = 0;
        float movementAmount = 0;
        Vector3 currentPosition = transform.position;
        if (inputRecieverComponent.gestureMovementArr.Length>0 && inputRecieverComponent.gestureMovementArr[0].Equals("Close") && currentPosition.y > -6)
        {
            direction = -1;
            movementAmount = direction * moveSpeed * Time.deltaTime;
            currentPosition.y += movementAmount;
        }
        else if (inputRecieverComponent.gestureMovementArr.Length > 0 && inputRecieverComponent.gestureMovementArr[0].Equals("Open") && currentPosition.y < 6)
        {
            direction = 1;
            movementAmount = direction * moveSpeed * Time.deltaTime;
            currentPosition.y += movementAmount;
        }
        else
        {
           
        }
        transform.position = currentPosition;
    }

    public bool canAttack()
    {
        return verticalInput == 0;
    }
}
