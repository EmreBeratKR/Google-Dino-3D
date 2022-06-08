using UnityEngine;

namespace Dino
{
    [RequireComponent(typeof(Animator))]
    public class DinoAnimator : MonoBehaviour
    {
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Run = Animator.StringToHash("Run");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int Crouch = Animator.StringToHash("Crouch");


        [SerializeField] private DinoMovement movement;

        private Animator animator;


        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            animator.SetBool(Idle, movement.State == Dino.State.Idle);
            animator.SetBool(Run, movement.State == Dino.State.Run);
            animator.SetBool(Jump, movement.State == Dino.State.Jump);
            animator.SetBool(Crouch, movement.State == Dino.State.Crouch);
        }
    }
}
