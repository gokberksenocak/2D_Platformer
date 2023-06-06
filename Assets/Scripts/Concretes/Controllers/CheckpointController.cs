using UnityEngine;

namespace Project.Concretes.Controllers
{
    public class CheckpointController : MonoBehaviour
    {
        private bool _isPassed;
        public bool IsPassed => _isPassed;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                _isPassed = true;
            }
        }
    }
}