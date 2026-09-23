using System.Collections.Generic;

public class ProjectileSystem
{
    private List<BulletView> _activeBullets = new List<BulletView>();
    private BulletPool _bulletPool;

    public ProjectileSystem(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public void Register(BulletView bullet)
    {
        if (bullet == null || _activeBullets.Contains(bullet))
            return;

        _activeBullets.Add(bullet);
    }

    public void Tick(float deltaTime)
    {
        for (int i = _activeBullets.Count - 1; i >= 0; i--)
        {
            var bullet = _activeBullets[i];
            if (bullet != null)
            {
                bullet.LifeTimeTick(deltaTime);

                if (bullet.IsExpired)
                {
                    _activeBullets.Remove(bullet);
                    _bulletPool.ReturnBullet(bullet.gameObject);
                }
            }
        }
    }
}