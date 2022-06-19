using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    [SerializeField]private float _speed = 7f;

    private void Update()
    {
        transform.Translate(Vector2.down * (_speed * Time.deltaTime));
    }
}
