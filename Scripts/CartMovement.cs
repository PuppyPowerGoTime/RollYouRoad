using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMovement : MonoBehaviour
{
    [Header("RigidBody")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] private float forwardMaxSpeed;
    [SerializeField] private float forwardAcceleration;
    [SerializeField] private float deacceleration;
    [SerializeField] private float backwardMaxSpeed;
    [SerializeField] private float backwardAcceleration;

    [Header("Cart Options")]
    [SerializeField] private float jumpVelocity;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float maxJumpLength = 9;
    [SerializeField] private float airDeaccleation = 0.2f;

    [Header("Wheels")]
    [SerializeField] private Animator leftWheelAnimator;
    [SerializeField] private Animator rightWheelAnimator;

    [Header("Animation")]
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator headAnimator;

    [Header("Audio")]
    public AudioSource jumpAudio;
    public AudioSource landAudio;

    float currentSpeed = 0.11f;

    bool isJumping = true;

    private void Update()
    {
        SpinWheels();
        Move();
        Jump();
        MoveEyes();
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = Vector2.up * jumpVelocity;
            playerAnimator.SetTrigger("Squish");
            jumpAudio.Play();
            isJumping = true;
        }
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow) && IsGrounded())
        {
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, 0);
            Accelerate(1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && IsGrounded())
        {
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, 0);
            Accelerate(-1);
        }
        else if(IsGrounded())
        {
            Deaccelerate();
        }

        if (!IsGrounded())
        {
            if (rb.velocity.x > maxJumpLength)
            {
                rb.velocity = new Vector2(rb.velocity.x - airDeaccleation, rb.velocity.y);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-rb.velocity.x * 0.3f, rb.velocity.y);
            }
        }
    }

    public void Accelerate(int direction)
    {
        if(direction > 0)
        {
            currentSpeed += forwardAcceleration;

            if (currentSpeed > forwardMaxSpeed)
            {
                currentSpeed = forwardMaxSpeed;
            }

            rb.velocity = new Vector2(currentSpeed * direction, rb.velocity.y);
        }
        else
        {
            currentSpeed += backwardAcceleration;

            if (currentSpeed > backwardMaxSpeed)
            {
                currentSpeed = backwardMaxSpeed;
            }

            rb.velocity = new Vector2(currentSpeed * direction, rb.velocity.y);
        }
    }

    public void Deaccelerate()
    {
        currentSpeed -= deacceleration;

        if (currentSpeed < 0)
        {
            currentSpeed = 0;
        }

        rb.velocity = new Vector2(currentSpeed * Mathf.Sign(rb.velocity.x), rb.velocity.y);
    }

    public bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(GetComponent<BoxCollider2D>().bounds.center, GetComponent<BoxCollider2D>().bounds.size, 0f, Vector2.down, 1f, ground);
        return raycastHit2D.collider != null;
    }

    public void SpinWheels()
    {
        leftWheelAnimator.speed = currentSpeed/10;
        rightWheelAnimator.speed = currentSpeed/10;

        leftWheelAnimator.SetFloat("Speed", currentSpeed);
        rightWheelAnimator.SetFloat("Speed", currentSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            if (isJumping)
            {
                playerAnimator.SetTrigger("Squash");
                landAudio.Play();
                isJumping = false;
                rb.velocity = Vector2.zero;
            }
        }
    }

    public void MoveEyes()
    {
        headAnimator.SetFloat("Speed", currentSpeed);
    }
}
