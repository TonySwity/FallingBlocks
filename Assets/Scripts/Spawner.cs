using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _fallingBlockPrefab;
    [SerializeField] private float _secondsBetweenSpawns = 1f;
    [SerializeField] private Vector2 _spawnSizeMinMax;
    [SerializeField] private float _spawnAngleMax;

    private float _nextSpawnTime;
    private Vector2 _screenHalfSizeWorldUnits;

    private void Start()
    {
        _screenHalfSizeWorldUnits =
            new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    private void Update()
    {
        if (Time.time > _nextSpawnTime)
        {
            _nextSpawnTime = Time.time + _secondsBetweenSpawns;

            float spawnAngle = Random.Range(-_spawnAngleMax, _spawnAngleMax);
            float spawnSize = Random.Range(_spawnSizeMinMax.x, _spawnSizeMinMax.y);
            Vector2 spawnPosition = new Vector2(Random.Range(-_screenHalfSizeWorldUnits.x, _screenHalfSizeWorldUnits.x),
                _screenHalfSizeWorldUnits.y + spawnSize);
            
            GameObject newFallingBlock = Instantiate(_fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newFallingBlock.transform.localScale = Vector2.one * spawnSize;
            newFallingBlock.transform.parent = transform;
        }
    }
}