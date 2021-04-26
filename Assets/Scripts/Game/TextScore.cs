using UnityEngine.UI;
using UnityEngine;

public class TextScore : MonoBehaviour
{
    [SerializeField] private Shadow _shadow;
    
    private Transform _player;


    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        float xEffect = _player.position.x * -1f;
        float yEffect = 11f - _player.position.y;

        _shadow.effectDistance = new Vector2(xEffect, yEffect);
    }
}
