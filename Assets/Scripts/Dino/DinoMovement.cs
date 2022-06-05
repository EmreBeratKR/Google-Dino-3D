using UnityEngine;

namespace Dino
{
    [RequireComponent(typeof(Rigidbody))]
    public class DinoMovement : MonoBehaviour
    {
        [SerializeField] private float gravityScale;
        [SerializeField] private float jumpForce;
        
        private Rigidbody body;


        private bool IsJump => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow);

        private void Start()
        {
            body = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            body.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration);
        }

        private void Update()
        {
            if (IsJump)
            {
                body.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            }
        }
    }
}