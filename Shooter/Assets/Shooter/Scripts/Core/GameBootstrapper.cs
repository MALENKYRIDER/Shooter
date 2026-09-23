using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _poolRoot;
    [SerializeField] private int _startBulletsCount;

    private BulletPool _bulletPool;
    private ProjectileSystem _projectileSystem;

    private void Awake()
    {
        _bulletPool = new BulletPool();
        _bulletPool.Initialize(_bulletPrefab, _poolRoot, _startBulletsCount);
        _projectileSystem = new ProjectileSystem(_bulletPool);
    }

    private void Update()
    {
        float dt = Time.deltaTime;
        _projectileSystem.Tick(dt);
    }
}