using UnityEngine;

namespace Dino
{
    public class Dino : MonoBehaviour
    {
        public void Die()
        {
            Destroy(gameObject);
        }
    }
}
