using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void RunAnimation(bool Run)
        {
            animator.SetBool("Run", Run);
        }

        public void JumpAnimation()
        {
            animator.SetTrigger("Jump");
        }

        public void GroundedAnimation(bool isGrounded)
        {
            animator.SetBool("Grounded", isGrounded);
        }
    }
