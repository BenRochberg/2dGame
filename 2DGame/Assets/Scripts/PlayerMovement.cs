using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;    //Player's Rigidbody2D variable.
    public float playerVelocity; //Player's Jump Force, how high can the player jump.
    public float playerSpeed;
    public int playerGravity;  //Player's Gravity, how strong is the player being pulled down.
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Getting the Player's Rigidbody2D component and equalling it to the Rigidbody2D variable.
        rb.gravityScale = playerGravity;  //Setting the Player's rigidbody gravity scale equal to the playerGravity Int variable to edit in Inspector.
    }

    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * playerSpeed, rb.velocity.y);



        //Jump Command
        if (Input.GetButtonDown("Jump")) //Checking if the Player is pressing the Space Bar.
        {
            //Setting the Player's rigidbody velocity equal to the playerVelocity Int variable to edit in Inspector.
            rb.velocity = new Vector2(rb.velocity.x, playerVelocity); //If Space is pressed, change the Player's Velocity.
        }


    }

}
