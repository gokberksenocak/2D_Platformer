using UnityEngine;

namespace Project.Concretes.Animations
{
    public class CharacterAnimation : MonoBehaviour
    {
        private Animator _animator;
        void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void JumpAnimation(bool isJump)
        {
            if (isJump == _animator.GetBool("isJump")) return;
            _animator.SetBool("isJump", isJump);
        }
        public void RunAnimation(float horizontal)
        {
            if (Mathf.Abs(horizontal) == _animator.GetFloat("speed")) return;
            _animator.SetFloat("speed", Mathf.Abs(horizontal));
        }
        public void ClimbAnimation(bool isClimb)
        {
            if (isClimb == _animator.GetBool("isClimb")) return;
            _animator.SetBool("isClimb", isClimb);
        }
    }
}