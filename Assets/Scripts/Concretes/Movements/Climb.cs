using UnityEngine;

namespace Project.Concretes.Movements
{
    public class Climb : MonoBehaviour
    {
        [SerializeField] private float _climbSpeed = 3f;
        private Rigidbody2D _rigidbody;
        private bool _isClimbing;
        public Rigidbody2D Rigidbody 
        {
            get { return _rigidbody; }
            set { _rigidbody = value; }
        }
        public bool IsClimbing
        {
            get { return _isClimbing; }
            set { _isClimbing = value; }
        }
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();   
        }
        public void Climbing(float direction)
        {
            if (_isClimbing)
            {
                transform.Translate(_climbSpeed * direction * Time.fixedDeltaTime * Vector3.up);
                _rigidbody.velocity = Vector2.zero;
            }
        }
    }
}