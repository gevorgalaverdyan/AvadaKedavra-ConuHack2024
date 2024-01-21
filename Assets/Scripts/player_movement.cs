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
        // Get input from the vertical axis (default is arrow keys or 'W' and 'S').
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the amount to move this frame.
        // Time.deltaTime converts moveSpeed to units per second instead of units per frame.
        float movementAmount = verticalInput * moveSpeed * Time.deltaTime;

        // Move the player's transform.
        transform.Translate(0, movementAmount, 0);
    }

    private void HandleGesturesInputs() {
        // Down
        int direction = 0;
        float movementAmount = 0;
        if (inputRecieverComponent.gestureMovementArr[0].Equals("Close")){
            direction = -1;
            movementAmount = direction * moveSpeed * Time.deltaTime;
        }
        else if (inputRecieverComponent.gestureMovementArr[0].Equals("Open"))
        {
            direction = 1;
            movementAmount = direction * moveSpeed * Time.deltaTime;
        }
        else
        {
           
        }
        transform.Translate(0, movementAmount, 0);
    }

    public bool canAttack()
    {
        return verticalInput == 0;
    }
}
