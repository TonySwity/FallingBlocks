using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    [SerializeField] private float _speedMin = 7f;
    [SerializeField] private float _speedMax = 15f;

    private float _visibleHeightThreshold;
    
    private float _speed;

    private void Start()
    {
        _speed = Mathf.Lerp(_speedMin, _speedMax, Difficulty.GetDifficultyPercent());

        _visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * (_speed * Time.deltaTime));

        if (transform.position.y < _visibleHeightThreshold)
        {
            Destroy(gameObject);
        }
    }
}
