using UnityEngine;

namespace Project.Concretes.Movements
{
    public class JumpMove : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private OnGround _onGround;
        public bool JumpAction => _rigidbody.velocity != Vector2.zero;
        private void Awake()
        {
            _onGround = GetComponent<OnGround>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        public void Jumping(int jumpForce)
        {
            if (_onGround.PlayerOnGround) _rigidbody.AddForce(Vector2.up * jumpForce);
        }
    }
}