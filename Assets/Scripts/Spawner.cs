using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _fallingBlockPrefab;
    [SerializeField] private float _secondsBetweenSpawnsMin = 0.1f;
    [SerializeField] private float _secondsBetweenSpawnsMax = 1f;
    [SerializeField] private float _spawnAngleMax;
    [SerializeField] private float _spawnSizeMin = 0.3f;
    [SerializeField] private float _spawnSizeMax = 2.3f;

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
            float secondsBetweenSpawns = Mathf.Lerp(_secondsBetweenSpawnsMax, _secondsBetweenSpawnsMin,
                Difficulty.GetDifficultyPercent());
            _nextSpawnTime = Time.time + secondsBetweenSpawns;

            float spawnAngle = Random.Range(-_spawnAngleMax, _spawnAngleMax);
            float spawnSize = Random.Range(_spawnSizeMin, _spawnSizeMax);
            Vector2 spawnPosition = new Vector2(Random.Range(-_screenHalfSizeWorldUnits.x, _screenHalfSizeWorldUnits.x),
                _screenHalfSizeWorldUnits.y + spawnSize);
            
            GameObject newFallingBlock = Instantiate(_fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newFallingBlock.transform.localScale = Vector2.one * spawnSize;
            newFallingBlock.transform.parent = transform;
        }
    }
}