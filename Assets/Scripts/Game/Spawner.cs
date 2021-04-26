using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _leftBorder, _rightBorder;
    [Header("Grass settings")]
    [SerializeField] private GameObject _grass;
    [SerializeField] private byte _grassQuantity;
    [SerializeField] private float _yGrass;
    [Header("Flowers settings")]
    [SerializeField] private GameObject _flowers;
    [SerializeField] private byte _flowersQuantity;
    [SerializeField] private float _yFlowers;
    [Header("Asteroids settings")]
    [SerializeField] private List<GameObject> _asteroidsList;
    [SerializeField] private byte _asteroidsMinQuantity, _asteroidsMaxQuantity;
    [SerializeField] private float _yAsteroidsMin, _yAsteroidsMax;
    [SerializeField] private float _xOffsetAsteroids;
    [Header("Eggs settings")]
    [SerializeField] private List<GameObject> _eggsList;
    [SerializeField] private float _xOffsetEggs;
    [SerializeField] private float _yMinEggs, _yMaxEggs;
    [Header("Platform settings")]
    [SerializeField] private GameObject _platform;
    [SerializeField] private float _xPlatform;   //max distance from egg
    [SerializeField] private float _yMinPlatform, _yMaxPlatform;

    private float _asteroidsTimer = 0;


    public void SpawnEgg()
    {
        int eggType = Random.Range(0, _eggsList.Count);
        Instantiate(_eggsList[eggType], GetEggSpawnPosition(), Quaternion.identity);
    }

    public void SpawnPlatform()
    {
        Instantiate(_platform, GetPlatformSpawnPosition(), Quaternion.identity);
    }

    private float GetLeftBorder()
    {
        return _leftBorder.transform.position.x;
    }

    private float GetRightBorder()
    {
        return _rightBorder.transform.position.x;
    }

    private void Start()
    {
        SpawnGrass();
        SpawnFlowers();
        SpawnEgg();
        SpawnPlatform();
    }

    private void Update()
    {
        _asteroidsTimer += Time.deltaTime;
    }

    private void LateUpdate()
    {
        if (_asteroidsTimer >= 1f)
        {
            SpawnAsteroids();
            _asteroidsTimer = 0;
        }
    }

    private void SpawnGrass()
    {
        float totalLength = Mathf.Abs(GetLeftBorder()) + GetRightBorder();

        float grassDivider = totalLength / _grassQuantity;

        Vector2 spawnPosition = new Vector2(GetLeftBorder(), _yGrass);

        GameObject grassCollection = new GameObject { name = "grassCollection" };
        for (int i = 0; i < _grassQuantity; i++)
        {
            Instantiate(_grass, spawnPosition, Quaternion.identity).transform.parent = grassCollection.transform;
            spawnPosition.x += grassDivider + Random.Range(0, 0.1f);
        }
    }

    private void SpawnFlowers()
    {
        float totalLength = Mathf.Abs(GetLeftBorder()) + GetRightBorder();

        float flowersDivider = totalLength / _flowersQuantity;

        Vector2 spawnPosition = new Vector2(GetLeftBorder(), _yFlowers);

        GameObject flowersCollection = new GameObject() { name = "flowersCollection" };
        for (int i = 0; i < _flowersQuantity; i++)
        {
            Instantiate(_flowers, spawnPosition, Quaternion.identity).transform.parent = flowersCollection.transform;
            spawnPosition.x += flowersDivider + Random.Range(-1f, 1f);
        }
    }

    private void SpawnAsteroids()
    {
        int randomQuantity = Random.Range(_asteroidsMinQuantity, _asteroidsMaxQuantity);
        for (int i = 0; i < randomQuantity; i++)
        {
            int asteroidType = Random.Range(0, _asteroidsList.Count);

            float spawnPositionX = Random.Range(GetLeftBorder() + _xOffsetAsteroids, GetRightBorder() - _xOffsetAsteroids);
            float spawnPositionY = Random.Range(_yAsteroidsMin, _yAsteroidsMax);

            Vector2 spawnPosition = new Vector2(spawnPositionX, spawnPositionY);

            Instantiate(_asteroidsList[asteroidType], spawnPosition, Quaternion.identity);
        }
    }

    private Vector2 GetEggSpawnPosition()
    {
        float xPosition = Random.Range(GetLeftBorder() + _xOffsetEggs, GetRightBorder() - _xOffsetEggs);
        float yPosition = Random.Range(_yMinEggs, _yMaxEggs);

        return new Vector2(xPosition, yPosition);
    }

    private Vector2 GetPlatformSpawnPosition()
    {
        float eggPosition = GameObject.FindGameObjectWithTag("Egg").transform.position.x;

        float xPosition = Random.Range(eggPosition - _xPlatform, eggPosition + _xPlatform);
        float yPosition = Random.Range(_yMinPlatform, _yMaxPlatform);

        xPosition = xPosition < GetLeftBorder() ? GetLeftBorder() + 2f : xPosition;
        xPosition = xPosition > GetRightBorder() ? GetRightBorder() - 2f : xPosition;

        return new Vector2(xPosition, yPosition);
    }
}
