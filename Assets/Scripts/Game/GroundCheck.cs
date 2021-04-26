using UnityEngine.Events;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private UnityEvent _fallEvent;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") && !collision.CompareTag("Platform")) { _fallEvent.Invoke(); }
            
        if (collision.CompareTag("Ground") || collision.CompareTag("Platform")) { GetComponentInParent<Player>().isGround = true; }
            
        if (collision.CompareTag("Platform")) { GetComponentInParent<Player>().isPlatform = true; }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Platform")) { GetComponentInParent<Player>().isGround = false; }
            
        if (collision.CompareTag("Platform")) { GetComponentInParent<Player>().isPlatform = false; }
    }
}
