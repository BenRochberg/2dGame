using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;                               //Cherries count is set to 0.
    [SerializeField] private TextMeshProUGUI cherryText;    //Getting the CherryCount Text

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))      //If the player collides with a game object that has the "Cherry" Tag.
        {
            Destroy(collision.gameObject);                  //Remove that game object.
            cherries++;                                     //Increase the Cherries count by 1.
            cherryText.text = "Cherries: " + cherries;      //Update the CherryCount Text to display the Cherries count.
            Debug.Log("Cherries: " + cherries);
        }
    }


}
