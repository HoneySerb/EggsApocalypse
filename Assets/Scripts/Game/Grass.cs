using System.Collections;
using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField] private float _downDistance;
    [SerializeField] private float _dispersion;

    private Vector2 _minVector, _maxVector;


    void Start()
    {
        _minVector = transform.position;
        _maxVector = transform.position;

        _downDistance = Random.Range(_downDistance - _dispersion, _downDistance + _dispersion);
        
        _minVector = new Vector2(_minVector.x, _minVector.y - _downDistance);
        _maxVector = new Vector2(_maxVector.x, _maxVector.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            StopAllCoroutines();

            StartCoroutine(Movement(false));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            StopAllCoroutines();

            StartCoroutine(Movement(true));
        }
    }

    private IEnumerator Movement(bool isUp)
    {
        Vector2 targetVector = isUp ? _maxVector : _minVector;
        while ((Vector2)transform.position != targetVector)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetVector, Time.deltaTime);

            yield return null;
        }
    }
}
