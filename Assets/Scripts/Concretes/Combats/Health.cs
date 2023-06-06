using UnityEngine;

namespace Project.Concretes.Combats
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _currentHealth;
        public event System.Action OnHealtChanged;
        public event System.Action OnDeath;
        private void Awake()
        {
            _currentHealth = _maxHealth;
        }
        public void TakeHit(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0) OnDeath?.Invoke();
            else {OnHealtChanged?.Invoke(); }
        }
    }
}