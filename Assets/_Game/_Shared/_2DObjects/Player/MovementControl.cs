
using System.Collections;
using Unity.VisualScripting;
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

    [SerializeField] private Transform floorLevel;

    //=========================================================================================================//

    //=========================================================================================================//
    [Header("Private Components")]
    private float checkSphere = 0.05f;

    private bool isGrounded;
    private Animator playerAnimator;
    private Rigidbody2D playerRB;
    private bool canRoll = true;
    private bool canJump = true;
    private float rollCoolDown = 1f;
    private float jumpCoolDown = 1f;
    


    //=========================================================================================================//

    //=========================================================================================================//
    [Header("Character Stats")] [SerializeField] [Range(1, 15)]
    float jumpForce = 10f;
    //=========================================================================================================//
    
    
    //Unity Engine
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
                
                Vector3 newPosition = Camera.main.ScreenToWorldPoint(touch.position);
                newPosition.z = 0;
                newPosition.y = floorLevel.position.y; 
                if(touch.deltaTime > 0.25)
                {
                    Move(newPosition);
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

    void OnEnable()
    {
        canRoll = true;
        canJump = true;
    }
    
    //exec movement
    //=========================================================================================================//

    private void Jump()
    {
        if (!canJump)
        {
            return;
        }
        
        playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        StartCoroutine(JumpCoolDown());
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

    private void Move(Vector3 xPosition)
    {
        Debug.Log(xPosition);
        transform.position = xPosition;
    }




    //Adjust Functions
    //=========================================================================================================//

    private IEnumerator RollCoolDown()
    {
        canRoll = false;
        yield return new WaitForSeconds(rollCoolDown);
        canRoll = true;
    }
    private IEnumerator JumpCoolDown()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpCoolDown);
        canJump = true;
    }
}
