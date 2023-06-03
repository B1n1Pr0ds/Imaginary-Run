using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpControll : MonoBehaviour
{
    [SerializeField]
    private GameObject playerModel;

    private Animator playerAnimator;
    private Rigidbody2D playerRB;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform playerFeet;
    private float checkSphere = 0.05f;
    private bool isGrounded;
    [SerializeField] float jumpForce = 1f;
    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = playerModel.GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(playerFeet.position, checkSphere, whatIsGround);
        if (isGrounded)
        {
            playerAnimator.SetBool("IsGoingUp", false);
            playerAnimator.SetBool("IsGoingDown", false);
            if (Input.touchCount > 0)
            {
                Jump();
                Debug.Log("Jump");
            }
        }

        if (!isGrounded)
        {
            if (playerRB.velocity.y > 0)
            {
                playerAnimator.SetBool("IsGoingUp", true);
            }

            if (playerRB.velocity.y < 0)
            {
                playerAnimator.SetBool("IsGoingDown", true);
            }
        }

    }
    public void Jump()
    {
        playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
