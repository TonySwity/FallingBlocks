using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;

    private float _screenHalfWidthInWorldUnits;

    public event UnityAction Died; 

    private void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2;
        
        if (Camera.main)
        {
            _screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
        }
        
    }

    private void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        float velocity = input * _speed;
        transform.Translate(Vector2.right * (velocity * Time.deltaTime) );

        if (transform.position.x < -_screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(_screenHalfWidthInWorldUnits, transform.position.y);
        }
        
        if (transform.position.x > _screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-_screenHalfWidthInWorldUnits, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.TryGetComponent(out FallingBlock fallingBlock))
        {
            Died?.Invoke();
            Destroy(gameObject);
        }
    }
}
