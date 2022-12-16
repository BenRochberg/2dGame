using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerVelocity; //Player's Jump Force, how high can the player jump.
    public int playerGravity;  //Player's Gravity, how strong is the player being pulled down.
    
    void Start()
    {
        //Getting the Player's Gravity from the Rigidbody2D Component to change in the Inspector.
        GetComponent<Rigidbody2D>().gravityScale = playerGravity; 
    }

    void Update()
    {
        //Jump Command
        if (Input.GetKeyDown(KeyCode.Space)) //Checking if the Player is pressing the Space Bar.
        {
            //Getting the Player's Velocity from the Rigidbody2D Component to change in the Inspector.
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, playerVelocity); //If Space is pressed, change the Player's Velocity.
        }


    }

}
