using UnityEngine;

namespace Dino
{
    public class DinoGroundChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayers;
        [SerializeField] private Vector3 boxSize;
        [SerializeField] private Color boxColor;
        [SerializeField] private bool showBox;


        public bool IsGrounded
        {
            get
            {
                var overlaps =
                    Physics.OverlapBox(transform.position, boxSize * 0.5f, Quaternion.identity, groundLayers);

                return overlaps.Length != 0;
            }
        }
        
        private void OnDrawGizmos()
        {
            if (!showBox) return;

            Gizmos.color = boxColor;
            Gizmos.DrawWireCube(transform.position, boxSize);
        }
    }
}