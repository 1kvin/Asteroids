using UnityEngine;

namespace GameLogic.Obstacles
{
    public class Obstacle
    {
        public int Gold { get; set; }
        public float Size { get; set; }
        public float Rotation { get; set; }

        public float Speed { get; set; }
        public Vector3 Position { get; set; }

        public Obstacle(Vector3 position, float size, float speed, float rotation, int gold)
        {
            this.Position = position;
            this.Size = size;
            this.Rotation = rotation;
            this.Speed = speed;
            this.Gold = gold;
        }

        public void Advance(float elapsedTime)
        {
            Position += elapsedTime * Speed * new Vector3(
                -Mathf.Sin(Rotation * Mathf.PI / 180),
                Mathf.Cos(Rotation * Mathf.PI / 180)
            );
        }
    }
}