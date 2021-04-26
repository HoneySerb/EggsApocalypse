using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-0.15f, 0.15f), 0), ForceMode2D.Impulse);

        float randomScaleX = Random.Range(transform.localScale.x - (transform.localScale.x * 0.1f), transform.localScale.x + (transform.localScale.x * 0.1f));
        float randomScaleY = Random.Range(transform.localScale.y - (transform.localScale.y * 0.1f), transform.localScale.y + (transform.localScale.y * 0.1f));

        transform.localScale = new Vector3(randomScaleX, randomScaleY, 1);
        if (!GameObject.Find("Player").GetComponent<Player>().isAlive)
        {
            var collisionObj = GetComponentInChildren<ParticleSystem>().collision;
            collisionObj.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "destroyPlatform")
        {
            Destroy(gameObject);
        }
        else if (collision.name == "Player")
        {
            collision.gameObject.GetComponent<Player>().Die();
        }
    }
}