using GameLogic.Input;
using GameLogic.PlayerBeh.Entity;
using UnityEngine;

namespace GameLogic.PlayerBeh
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private float gunReloadTime;
        [SerializeField] private float laserReloadTime;
        [SerializeField] private int maxLaserShots;
        [SerializeField] private Transform shotPoint;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Laser laserPrefab;

        public float LaserTimeout => laserTimeout;
        public float LaserShots => laserShots;
        public float MaxLaserShots => maxLaserShots;
        
        private IPlayerInput playerInput;
        private Transform _transform;
        private float gunTimeout;
        private float laserTimeout;
        private int laserShots;
        
        public void Init(IPlayerInput playerInput)
        {
            this.playerInput = playerInput;
            laserShots = maxLaserShots;

            _transform = transform;
        }

        public void Update()
        {
            if (gunTimeout > 0)
                gunTimeout -= Time.deltaTime;

            if (laserShots != maxLaserShots)
            {
                if (laserTimeout <= 0)
                {
                    laserShots++;
                    if (laserShots != maxLaserShots)
                    {
                        laserTimeout = laserReloadTime;
                    }
                    else
                    {
                        laserTimeout = 0;
                    }
                }
            }

            if (laserTimeout > 0)
            {
                laserTimeout -= Time.deltaTime;
            }
            
            if (playerInput.IsShoot())
            {
                if (gunTimeout <= 0)
                {
                    Shot();
                    gunTimeout = gunReloadTime;
                }
            }
            
            if (playerInput.IsLaserShoot())
            {
                LaserShot();
            }
        }

        private void Shot()
        {
            Instantiate(bulletPrefab, shotPoint.position, _transform.rotation);
        }
        
        private void LaserShot()
        {
            if(laserShots == 0) return;
            laserShots--;
            laserTimeout = laserReloadTime;
            
            Instantiate(laserPrefab, shotPoint.position, _transform.rotation, _transform);
        }
    }
}