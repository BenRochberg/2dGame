using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;             //Player's Rigidbody2D variable.
    private BoxCollider2D coll;         //Player's BoxCollider2D variable.
    private SpriteRenderer sprite;      //Player's SpriteRenderer variable.
    private Animator anim;              //Player's Animator variable.

    [SerializeField] private LayerMask jumpableGround;              //Establishing a layer the player is allowed to jump on.
    private enum MovementState { idle, running, jumping, falling }  //Enumeration for different movement states.

    [SerializeField] private float playerVelocity;      //Player's Jump Force, how high can the player jump.
    [SerializeField] private float playerSpeed;         //Player's Speed, how fast the player to run.
    [SerializeField] private float dirX;                //Player's directional X value..


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();               //Setting the Player's Rigidbody2D component equal to the Rigidbody2D variable.
        coll = GetComponent<BoxCollider2D>();           //Setting the Player's BoxCollider2D component equal to the BoxCollider2D variable.
        anim = GetComponent<Animator>();                //Setting the Player's Animator component equal to the Animator variable.
        sprite = GetComponent<SpriteRenderer>();        //Setting the Player's SpriteRenderer component equal to the SpriteRenderer variable.
    }

    private void Update()
    {
        //Movement
        dirX = Input.GetAxisRaw("Horizontal");                              //Setting the Directional X value to Horizonal Axis Input.
        rb.velocity = new Vector2(dirX * playerSpeed, rb.velocity.y);       //When left/right movement is detected, multiply the Directional X value by the player's speed.



        //Jump
        if (Input.GetButtonDown("Jump") && IsGrounded())                    //Checking if the Player is pressing the Space Bar while on the ground.
        {
            rb.velocity = new Vector2(rb.velocity.x, playerVelocity);       //If Space is pressed, change the Player's Velocity.
        }



        UpdateAnimations();                                                 //Calling the UpdateAnimations Method.
    }


    private void UpdateAnimations()
    {
        MovementState state;                    //Establishing a local MovementState variable.

        //Running animation
        if (dirX > 0f)                          //If the player is going right.
        {
            state = MovementState.running;      //Set local Movement State variable to Running.
            sprite.flipX = false;               //Used to flip the player's sprite on the X-axis once the player moves left.
        }
        else if (dirX < 0f)                     //If the player is going left.
        {
            state = MovementState.running;      //Set local Movement State variable to Running.
            sprite.flipX = true;                //Flip the player's sprite on the X-axis.
        }
        else                                    //If the player is Idle.
        {
            state = MovementState.idle;         //Set local Movement State variable to Idle.
        }

        //Jumping animation
        if (rb.velocity.y > .1f)                //If the player is above 0.1 on the Y-axis.
        {
            state = MovementState.jumping;      //Set local Movement State variable to Jumping.
        }
        else if (rb.velocity.y < -.1f)          //If the player is below -0.1 on the Y-axis.
        {
            state = MovementState.falling;      //Set local Movement State variable to Falling.
        }

        anim.SetInteger("state", (int)state);   //Setting the "state" int condition and converting the Movement State enum into an int.
    }

    private bool IsGrounded()                   //A boolean to check if the player is on the ground or not.
    {
        //Finding the boxcast of the player and the terrain, if they overlap by .01, the player can jump on that terrain.
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .01f, jumpableGround);
    }

}
