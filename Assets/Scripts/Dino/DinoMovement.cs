using UnityEngine;

namespace Dino
{
    [RequireComponent(typeof(Rigidbody))]
    public class DinoMovement : MonoBehaviour
    {
        [SerializeField] private DinoGroundChecker groundChecker;
        [SerializeField] private BoxCollider tallCollider;
        [SerializeField] private float gravityScale;
        [SerializeField] private float jumpForce;
        
        private Rigidbody body;

        public Dino.State State { get; private set; }


        private bool IsJump
        {
            get
            {
                if (!groundChecker.IsGrounded) return false;
                
                return Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow);
            }
        }

        private bool IsCrouch
        {
            get
            {
                if (!groundChecker.IsGrounded) return false;

                return Input.GetKey(KeyCode.DownArrow);
            }
        }

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
            UpdateState();
            
            if (State == Dino.State.Idle) return;
            
            Jump();
            Crouch();
        }

        private void UpdateState()
        {
            if (!Game.IsPlaying)
            {
                State = Dino.State.Idle;
                return;
            }
            
            if (!groundChecker.IsGrounded)
            {
                State = Dino.State.Jump;
                return;
            }

            if (IsCrouch)
            {
                State = Dino.State.Crouch;
                return;
            }

            State = Dino.State.Run;
        }

        private void Jump()
        {
            if (!IsJump) return;
            
            body.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }

        private void Crouch()
        {
            var isCrouching = State == Dino.State.Crouch;

            tallCollider.enabled = !isCrouching;
        }
    }
}
