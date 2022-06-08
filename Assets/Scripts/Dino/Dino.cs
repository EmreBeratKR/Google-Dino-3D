using UnityEngine;

namespace Dino
{
    public class Dino : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosion;
        [SerializeField] private GameObject model;
        
        private bool isDead;
        
        
        public void Die()
        {
            if (isDead) return;

            isDead = true;
            
            Destroy(model);
            explosion.Play();
        }
        
        public enum State
        {
            Idle,
            Run,
            Jump,
            Crouch
        }
    }
}
