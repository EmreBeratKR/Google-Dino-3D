using UnityEngine;

namespace Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private float additionalSpeed;
        
        private ObstacleMover mover;


        private void Update()
        {
            if (!Game.IsPlaying) return;
            
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
            transform.position += Vector3.left * (Time.deltaTime * (mover.Speed + additionalSpeed));
        }
    }
}