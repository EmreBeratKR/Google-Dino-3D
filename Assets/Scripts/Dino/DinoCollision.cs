using Obstacles;
using UnityEngine;

namespace Dino
{
    [RequireComponent(typeof(Dino))]
    public class DinoCollision : MonoBehaviour
    {
        private Dino dino;


        private void Start()
        {
            dino = GetComponent<Dino>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Obstacle obstacle))
            {
                Game.GameOver();
            }
        }
    }
}
