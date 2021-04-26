using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private float _money;
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private float _timeToBlinking;
    [SerializeField] private float _blinkingTime;

    private Spawner _spawner;
    private Player _player;

    private float _timer = 0;


    private void Start()
    {
        _spawner = GameObject.Find("spawner").GetComponent<Spawner>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        Blinking();
    }

    private void LateUpdate()
    {
        if (_timer >= _timeToDestroy) { DestroyEgg(); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetFloat("Balance", PlayerPrefs.GetFloat("Balance") + _money);
            _player.SetScore(_player.Score + 1);
            DestroyEgg();
        }
    }

    private void DestroyEgg()
    {
        _spawner.SpawnEgg();
        Destroy(gameObject);
    }

    private void Blinking()
    {
        if (_timer >= _timeToBlinking) { GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, Mathf.PingPong(Time.time * _blinkingTime, 1f)); }  
    }
}
