using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSphere : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;

    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10f, maxAirAcceleration = 1f;

    [SerializeField, Range(0f, 10f)]
    float jumpHeight = 2f;

    [SerializeField, Range(0, 5)]
    float maxAirJump = 0;


    Vector3 velocity, desiredVelocity;
    Rigidbody body;
    int jumpPhase;

    bool desiredJump;
    bool onGround;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);

        
        desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;

        desiredJump |= Input.GetButtonDown("Jump");

    }

    private void FixedUpdate()
    {
        UpdateState();

        float acceleration = onGround ? maxAcceleration : maxAirAcceleration;
        float maxSpeedChange = acceleration * Time.deltaTime;

        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

        

        if (desiredJump)
        {
            desiredJump = false;
            Jump();

        }

        body.velocity = velocity;

        onGround = false;
    }

    private void UpdateState()
    {
        velocity = body.velocity;

        if (onGround)
        {
            jumpPhase = 0;
        }
    }

    private void Jump()
    {
        if (onGround || jumpPhase < maxAirJump)
        {
            jumpPhase += 1;
            float jumpSpeed = Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight);
            if (velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max( jumpSpeed - velocity.y, 0f);
            }
            velocity.y += jumpSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        onGround = true;
    }

}
