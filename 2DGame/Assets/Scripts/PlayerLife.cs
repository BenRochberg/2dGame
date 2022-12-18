using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;                                             //Getting Player's RigidBody2D
    private Animator anim;                                              //Getting Player's Animator

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();                               //Setting the Player's RigidBody2D component equal to the rb variable.
        anim= GetComponent<Animator>();                                 //Setting the Player's Animator component equal to the anim variable.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))                    //If the player collides with a game object with the "Trap" Tag.
        {
            Die();                                                      //Calling the Die Method.
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;                           //Setting the Player's RigidBody2D bodytype to static.
        anim.SetTrigger("death");                                       //Triggering the player's "death" animation.
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);     //Called an animation event in the "death" animation, the scene will completely reset upon death.
    }

}
