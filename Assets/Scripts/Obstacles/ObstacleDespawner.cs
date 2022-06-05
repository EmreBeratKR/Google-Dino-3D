using UnityEngine;

namespace Obstacles
{
    public class ObstacleDespawner : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Obstacle obstacle))
            {
                obstacle.Destroy();
            }
        }
    }
}
