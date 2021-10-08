using GameLogic.Obstacles;
using UnityEngine;

namespace GameLogic.PlayerBeh.Entity
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float deleteZone;

        private Transform _transform;

        private void Start()
        {
            _transform = transform;
        }

        private void Update()
        {
            _transform.Translate(Vector3.up * Time.deltaTime * speed);

            if (Vector3.Distance(Vector3.zero, _transform.position) > deleteZone)
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
                Destroy(gameObject);
            }
        }
    }
}
