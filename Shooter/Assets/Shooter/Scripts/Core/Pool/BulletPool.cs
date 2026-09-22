using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private int _startBulletCount;

    private Queue<GameObject> _bullets = new Queue<GameObject>();

    private bool _isInitialized;
    private HashSet<GameObject> _activeBullets = new HashSet<GameObject>();

    public void Initialize()
    {
        if (_isInitialized)
            return;

        for (int i = 0; i < _startBulletCount; i++)
        {
            var prefab = Instantiate(_bulletPrefab);
            prefab.transform.SetParent(_firePoint);
            prefab.transform.localPosition = Vector3.zero;
            prefab.transform.localRotation = Quaternion.identity;
            _bullets.Enqueue(prefab);
            prefab.SetActive(false);
        }

        _isInitialized = true;
    }

    public GameObject GetBullet(Vector3 pos, Quaternion rot)
    {
        if (_bullets.Count == 0)
            return null;

        var bullet = _bullets.Dequeue();
        _activeBullets.Add(bullet);
        bullet.transform.position = pos;
        bullet.transform.rotation = rot;
        bullet.SetActive(true);

        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        if (bullet == null)
            return;

        if (_activeBullets.Remove(bullet) == false)
            return;

        bullet.SetActive(false);
        _bullets.Enqueue(bullet);
    }
}