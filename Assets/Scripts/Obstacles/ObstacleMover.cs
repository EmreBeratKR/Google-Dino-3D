using UnityEngine;

namespace Obstacles
{
    public class ObstacleMover : MonoBehaviour
    {
        [SerializeField] private float speed;
        public float Speed => speed * GlobalSpeed.Scale;
    }
}