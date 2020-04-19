using UnityEngine;

public class GuyMover : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rigidbody2D.AddForce(new Vector2(RandomDirection(), RandomDirection()), ForceMode2D.Impulse);
    }

    public void IncreaseVelocity()
    {
        _rigidbody2D.velocity = _rigidbody2D.velocity * 1.1f;
    }

    private float RandomDirection()
    {
        float number = Random.Range(1.01f, 1.3f);

        if (Random.Range(0f, 1f) > 0.5f)
        {
            number *= -1;
        }

        return number;
    }

    public void Stop()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }
}
