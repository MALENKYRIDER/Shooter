using UnityEngine;

public class BulletView : MonoBehaviour
{
    private Vector3 _direction;
    private float _speed;
    private float _remainingLifetime;

    public Vector3 Direction => _direction;
    public float Speed => _speed;
    public bool IsExpired => _remainingLifetime <= 0;

    public void Initialize(Vector3 direction, float speed, float remainingLifetime)
    {
        _direction = direction.normalized;
        _speed = speed;
        _remainingLifetime = remainingLifetime;
    }

    public void LifeTimeTick(float deltaTime)
    {
        _remainingLifetime -= deltaTime;
    }
}
