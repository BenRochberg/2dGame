using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;             //Player's Rigidbody2D variable.
    private SpriteRenderer sprite;      //Player's SpriteRenderer variable.
    private Animator anim;              //Player's Animator variable.

    [SerializeField] private float playerVelocity;      //Player's Jump Force, how high can the player jump.
    [SerializeField] private float playerSpeed;         //Player's Speed, how fast the player to run.
    [SerializeField] private int playerGravity;         //Player's Gravity, how strong is the player being pulled down.
    [SerializeField] private float dirX;                //Player's directional X value..



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();               //Setting the Player's Rigidbody2D component equal to the Rigidbody2D variable.
        anim = GetComponent<Animator>();                //Setting the Player's Rigidbody2D component equal to the Animator variable.
        sprite = GetComponent<SpriteRenderer>();        //Setting the Player's Rigidbody2D component equal to the SpriteRenderer variable.
        rb.gravityScale = playerGravity;                //Setting the Player's rigidbody gravity scale equal to the playerGravity Int variable.
    }

    private void Update()
    {
        //Movement
        dirX = Input.GetAxisRaw("Horizontal");                              //Setting the Directional X value to Horizonal Axis Input.
        rb.velocity = new Vector2(dirX * playerSpeed, rb.velocity.y);       //When left/right movement is detected, multiply the Directional X value by the player's speed.



        //Jump
        if (Input.GetButtonDown("Jump"))                                    //Checking if the Player is pressing the Space Bar.
        {
            rb.velocity = new Vector2(rb.velocity.x, playerVelocity);       //If Space is pressed, change the Player's Velocity.
        }



        UpdateAnimations();                                                 //Calling the UpdateAnimations Method.
    }


    private void UpdateAnimations()
    {
        if (dirX > 0f)                          //If the player is going right.
        {
            anim.SetBool("Running", true);      //Set Running to True.
            sprite.flipX = false;               //Used to flip the player's sprite on the X-axis once the player moves left.
        }
        else if (dirX < 0f)                     //If the player is going left.
        {
            anim.SetBool("Running", true);      //Set Running to True.
            sprite.flipX = true;                //Flip the player's sprite on the X-axis.
        }
        else                                    //If the player is Idle.
        {
            anim.SetBool("Running", false);     //Set Running to False.
        }
    }

}
