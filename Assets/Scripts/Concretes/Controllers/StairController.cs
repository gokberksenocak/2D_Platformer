using Project.Concretes.Movements;
using UnityEngine;

namespace Project.Concretes.Controllers
{
    public class StairController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            ClimbingUpOrDown(collision, 0f, true);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            ClimbingUpOrDown(collision, 1f, false);
        }

        void ClimbingUpOrDown(Collider2D collision,float gravityForce,bool isClimb)
        {
            Climb climbPlayer = collision.gameObject.GetComponent<Climb>();
            if (climbPlayer != null)
            {
                climbPlayer.Rigidbody.gravityScale = gravityForce;
                climbPlayer.IsClimbing = isClimb;
            }
        }
    }
}