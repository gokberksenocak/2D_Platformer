using UnityEngine;

namespace Project.Concretes.Movements
{
    public class OnEdge : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        RaycastHit2D _hit;
        private bool _hasTurn = false;
        private bool _isFlip = false;
        private float _direction = 1f;
        public float Direction =>_direction;
        public bool IsFlip => _isFlip;

        public void CheckHit()
        {
            _hit = Physics2D.Raycast(transform.position, Vector2.down, 5f, _layerMask);
            if (_hit.collider == null && !_hasTurn)
            {
                _direction *= -1;
                _isFlip = !_isFlip;
                _hasTurn = true;
            }
            else if (_hit.collider != null)
            {
                _hasTurn = false;
            }
        }
    }
}

