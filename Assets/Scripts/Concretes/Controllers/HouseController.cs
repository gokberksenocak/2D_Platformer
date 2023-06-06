using UnityEngine;

namespace Project.Concretes.Controllers
{
    public class HouseController : MonoBehaviour
    {
        public event System.Action OnReachToHouse;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                OnReachToHouse?.Invoke();
            }
        }
    }
}