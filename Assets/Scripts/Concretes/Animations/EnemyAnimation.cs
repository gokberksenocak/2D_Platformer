using UnityEngine;

namespace Project.Concretes.Animations
{
    public class EnemyAnimation : MonoBehaviour
    {
        private Animator _animator;
        void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void DeathAnimation()
        {
            _animator.SetTrigger("isDeath");
        }
    }
}
