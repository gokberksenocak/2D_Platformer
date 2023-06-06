using UnityEngine;

namespace Project.Concretes.Movements
{
    public class OnGround : MonoBehaviour
    {
        private bool _onGround;
        public bool PlayerOnGround
        {
            get { return _onGround; }
            set { _onGround = value; }
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground")) _onGround = true;
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground")) _onGround = false;
        }
    }
}