using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public PlayerScript movement;
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("We hit something!" + collision.gameObject.name);

        if(collision.gameObject.name == "Obstacle")
        {
            Debug.Log("We hit an obstacle");
            movement.enabled = false;
        }
    }
}
