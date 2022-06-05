using UnityEngine;

namespace Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        private ObstacleMover mover;


        private void Update()
        {
            Move();
        }

        public void SetMover(ObstacleMover obstacleMover)
        {
            mover = obstacleMover;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private void Move()
        {
            transform.position += Vector3.left * (Time.deltaTime * mover.Speed);
        }
    }
}