using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;

    private float screenHalfWidthInWorldUnits = 9.5f;

    private void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        float velocity = input * _speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime );

        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
        
        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }
}
