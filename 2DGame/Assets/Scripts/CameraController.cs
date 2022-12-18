using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; //Getting the transform of the player.
    private void Update()
    {
        //Setting the new transform of the camera to the player's x and position.
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
