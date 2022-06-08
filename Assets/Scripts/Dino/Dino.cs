using UnityEngine;

namespace Dino
{
    public class Dino : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosion;
        [SerializeField] private GameObject model;
        
        
        public void Die()
        {
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
