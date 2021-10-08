using GameLogic.Obstacles;
using UnityEngine;

namespace GameLogic.PlayerBeh.Entity
{
    public class Laser : MonoBehaviour
    {
        [SerializeField] private float liveTime;
        private float liveTimeout;
        
        private void Start()
        {
            liveTimeout = liveTime;
        }

        private void Update()
        {
            if (liveTimeout > 0)
            {
                liveTimeout -= Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var obstacleBehaviour = other.GetComponent<ObstacleBehaviour>();
            if (obstacleBehaviour != null)
            {
                obstacleBehaviour.OnHitBullet();
            }
        }
    }
}
