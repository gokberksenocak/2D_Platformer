using Project.Concretes.Combats;
using Project.Concretes.Controllers;
using UnityEngine;

namespace Project.Concretes.Managers
{
    public class SoundManager : MonoBehaviour
    {
        private AudioSource _audioSource;
        [SerializeField] private Health _health;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private AudioClip _damageVoice;
        [SerializeField] private AudioClip _deathVoice;
        [SerializeField] private AudioClip _enemyKillVoice;
        [SerializeField] private AudioClip _pickCherryVoice;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        private void OnEnable()
        {
            _playerController.OnPickCherry += PickSound;
            _playerController.OnTapEnemy += EnemyKillSound;
            _health.OnDeath += DeathSound;
            _health.OnHealtChanged += GetDamageSound;
        }
        private void OnDisable()
        {
            _playerController.OnPickCherry -= PickSound;
            _playerController.OnTapEnemy -= EnemyKillSound;
            _health.OnDeath += DeathSound;
            _health.OnHealtChanged -= GetDamageSound;
        }
        private void GetDamageSound()
        {
            _audioSource.PlayOneShot(_damageVoice);
        }
        private void DeathSound()
        {
            _audioSource.PlayOneShot(_deathVoice);
        }
        private void PickSound()
        {
            _audioSource.PlayOneShot(_pickCherryVoice);
        }
        private void EnemyKillSound()
        {
            _audioSource.PlayOneShot(_enemyKillVoice);
        }
    }
}