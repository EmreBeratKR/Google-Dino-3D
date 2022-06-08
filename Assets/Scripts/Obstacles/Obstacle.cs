using UnityEngine;

namespace Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private float additionalSpeed;
        
        private ObstacleMover mover;
        private float speed;


        private void Update()
        {
            speed = Game.IsPlaying ? mover.Speed + additionalSpeed : additionalSpeed;
            
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
            transform.position += Vector3.left * (Time.deltaTime * speed);
        }
    }
}