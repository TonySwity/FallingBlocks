using System;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    [SerializeField] private float _speedMin = 7f;
    [SerializeField] private float _speedMax = 15f;
    
    private float _speed;

    private void Start()
    {
        _speed = Mathf.Lerp(_speedMin, _speedMax, Difficulty.GetDifficultyPercent());
    }

    private void Update()
    {
        transform.Translate(Vector2.down * (_speed * Time.deltaTime));
    }
}
