
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MovementControl : MonoBehaviour
{
    //=========================================================================================================//
    [Header("Associated Components")]
    //Associate with the player model to guarantee access to the animator
    [SerializeField]
    private GameObject playerModel;

    //Called in the inspector to tell what is ground
    [SerializeField] private LayerMask whatIsGround;

    //Select in the inspector to tell the distance between the ground and the character
    [SerializeField] private Transform playerFeet;

    [SerializeField]
    //=========================================================================================================//

    //=========================================================================================================//
    [Header("Private Components")]
    private float checkSphere = 0.05f;

    private bool isGrounded;
    private Animator playerAnimator;
    private Rigidbody2D playerRB;
    private bool canRoll = true;
    private float rollCoolDown = 1f;


    //=========================================================================================================//

    //=========================================================================================================//
    [Header("Character Stats")] [SerializeField] [Range(1, 15)]
    float jumpForce = 10f;

    //=========================================================================================================//
    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = playerModel.GetComponent<Animator>();
    }

    private void Update()
    {
        //Follow the playerModel
        transform.position = playerModel.transform.position;
        //check the distance between the ground and the player "feet" and change the isGrounded variable
        isGrounded = Physics2D.OverlapCircle(playerFeet.position, checkSphere, whatIsGround);

        if (isGrounded)
        {
            playerAnimator.SetBool("IsGoingUp", false);
            playerAnimator.SetBool("IsGoingDown", false);
            playerAnimator.SetBool("IsRunning", true);

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.deltaPosition.y > 0)
                {
                    Jump();
                }

                if (touch.deltaPosition.y < 0)
                {
                    Roll();
                }

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
    //exec movement
    //=========================================================================================================//

    private void Jump()
    {
        playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Roll()
    {
        if(!canRoll)
        {
            return;
        }
        
        
        playerAnimator.SetTrigger("Roll");
        canRoll = false;
        Debug.Log("Rolled"); 
        StartCoroutine(RollCoolDown());
    }

    private IEnumerator RollCoolDown()
    {
        canRoll = false;
        yield return new WaitForSeconds(rollCoolDown);
        canRoll = true;
    }
}
