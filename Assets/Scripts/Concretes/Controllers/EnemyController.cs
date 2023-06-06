using Project.Concretes.Animations;
using Project.Concretes.Managers;
using Project.Concretes.Movements;
using System.Collections;
using UnityEngine;

namespace Project.Concretes.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private SoundManager _soundManager;
        private HorizontalMove _horizontalMove;
        private EnemyAnimation _enemyAnimation;
        private OnEdge _onEdge;
        private SpriteRenderer _spriteRenderer;
        private float _direction = 1f;
        private bool _isDead = false;
        private bool _isFlipActive = false;
        public float Direction => _direction;
        public bool IsFlipActive => _isFlipActive;

        void Awake()
        {
            _horizontalMove = GetComponent<HorizontalMove>();
            _onEdge = GetComponent<OnEdge>();
            _enemyAnimation = GetComponent<EnemyAnimation>();
            _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        }

        void FixedUpdate()
        {
            if (!_isDead) _horizontalMove.Mover(_onEdge.Direction);

            _spriteRenderer.flipX = _onEdge.IsFlip;
        }
        private void LateUpdate()
        {
            _onEdge.CheckHit();
        }
        public IEnumerator EnemyDeath()
        {
            _isDead = true;
            _enemyAnimation.DeathAnimation();
            yield return new WaitForSeconds(.5f);
            gameObject.SetActive(false);
        }
    }
}