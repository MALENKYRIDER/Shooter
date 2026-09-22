using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Transform _bulletSpawnPoint;
    
    private void Awake()
    {
        _bulletPool.Initialize();
        var bullet = _bulletPool.GetBullet(_bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
        if (bullet != null)
            _bulletPool.ReturnBullet(bullet);
    }
}
