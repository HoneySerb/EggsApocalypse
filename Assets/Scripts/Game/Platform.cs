using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _destroyTime;
    [SerializeField] private float _timeToBlinking;
    [SerializeField] private float _blinkingTime;

    private Spawner _spawner;

    private float _timer = 0f;


    private void Start()
    {
        _spawner = GameObject.Find("spawner").GetComponent<Spawner>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        Blinking();
    }

    private void LateUpdate()
    {
        if (_timer >= _destroyTime) { DestroyPlatform(); }
    }

    private void DestroyPlatform()
    {
        _spawner.SpawnPlatform();
        Destroy(gameObject);
    }

    private void Blinking()
    {
        if (_timer >= _timeToBlinking) { GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, Mathf.PingPong(Time.time * _blinkingTime, 1f)); }
    }
}
