using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRigidBody : MonoBehaviour
 {
	private string MoveInputAxis = "Vertical";
	private string TurnInputAxis = "Horizontal";

    public Collider other;

    private float jumpForce = 10f; //how much force you want when jumping
    private bool onGround; //allows the functions to determine whether player is on the ground or not

    // rotation that occurs in angles per second holding down input
    public float rotationRate = 360;

    // units moved per second holding down move input
    public float moveRate = 10;


    private Rigidbody rb;

    public float Speed;
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            gameObject.GetComponent<CharacterController>().Move(input * Speed * Time.deltaTime);
            //GetComponent<Rigidbody>().AddForce(Vector2.up * Speed);
        }
    }


    private void Start() 
    {
        rb = GetComponent<Rigidbody>();

        onGround = true;
    }

    // Update is called once per frame
    private void Update()
    {
        float moveAxis = Input.GetAxis(MoveInputAxis);
        float turnAxis = Input.GetAxis(TurnInputAxis);

        ApplyInput(moveAxis, turnAxis);

        if(Input.GetButton("Jump") && onGround == true)
            {
            //adds force to player on the y axis by using the flaot set for the variable jumpForce. Causes the player to jump
            
            //says the player is no longer on the ground
            onGround = false;

        }
    }

    private void ApplyInput(float moveInput,
                            float turnInput) 
    {
		Move(moveInput);
		Turn(turnInput);
    }

    private void Move(float input) 
    {
        // Make sure to set drag high so the sliding effect is very minimal (5 drag is acceptable for now)

        // mention this trash function automatically converts to local space
        rb.AddForce(transform.forward * input * moveRate, ForceMode.Force);

        
        
    }



    private void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }
}