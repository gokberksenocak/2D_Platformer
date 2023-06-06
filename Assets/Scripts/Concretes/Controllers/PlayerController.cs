using Project.Abstracts.Inputs;
using Project.Concretes.Animations;
using Project.Concretes.Combats;
using Project.Concretes.ExtensionMethods;
using Project.Concretes.Inputs;
using Project.Concretes.Movements;
using UnityEngine;

namespace Project.Concretes.Controllers 
{
    public class PlayerController : MonoBehaviour
    {
        private float _horizontal;
        private float _vertical;
        private bool _isJumpPressed;
        private Health _health;
        private JumpMove _jumpMove;
        private OnGround _onGround;
        private HorizontalMove _horizontalMove;
        private Climb _climb;
        private Rigidbody2D _rigidbody;
        [SerializeField] private CharacterAnimation _characterAnimation;
        [SerializeField] private Flip _flip;
        [SerializeField] private int _layerMaskOfCherry;
        private IPlayerInput _input;
        private Vector3 _firstPos;
        public Vector3 FirstPos => _firstPos;
        public event System.Action OnPickCherry;
        public event System.Action OnTapEnemy;
        void Awake()
        {
            _input = new PcInput();
            _health = GetComponent<Health>();
            _climb = GetComponent<Climb>();
            _onGround = GetComponent<OnGround>();
            _jumpMove = GetComponent<JumpMove>();
            _horizontalMove = GetComponent<HorizontalMove>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            _firstPos = transform.position;
        }
        void Update()
        {
            _horizontal = _input.Horizontal;
            _vertical = _input.Vertical;

            if (_input.IsJumpPressed)
            {
                _isJumpPressed = true;
            }

        }
        private void FixedUpdate()
        {
            _horizontalMove.Mover(_horizontal);
            _climb.Climbing(_vertical);
            _characterAnimation.RunAnimation(Mathf.Abs(_horizontal));
            _characterAnimation.JumpAnimation(!_onGround.PlayerOnGround && _jumpMove.JumpAction && !_climb.IsClimbing);
            _characterAnimation.ClimbAnimation(_climb.IsClimbing);

            if (_horizontal != 0)
            {
                _flip.FlipToCharacter(_horizontal);
            }

            if (_isJumpPressed)
            {
                _jumpMove.Jumping(400);
                _isJumpPressed = false;
            }           
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Damage damage = collision.gameObject.GetComponent<Damage>();
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();

            if (damage != null && !collision.HasItEnemy())
            {
                _health.TakeHit(damage.DamageValue);
            }
            else if (collision.HasItEnemy() && collision.HasHitTopSide())
            {
                OnTapEnemy?.Invoke();
                _rigidbody.AddForce(Vector2.up * 200);
                StartCoroutine(enemyController.EnemyDeath());
            }
            else if (collision.HasItEnemy() && collision.HasHitLeftOrRightSide())
            {
                _health.TakeHit(damage.DamageValue);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _layerMaskOfCherry)
            {
                collision.gameObject.SetActive(false);
                OnPickCherry?.Invoke();
            }
        }
    }
}