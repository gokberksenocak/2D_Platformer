using Project.Concretes.Combats;
using Project.Concretes.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Concretes.Managers
{
    public class UIManager : MonoBehaviour
    {
        private int _lifes = 3;
        private int _collectibleCount;
        [SerializeField] private Health _health;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private HouseController _houseController;
        [SerializeField] private Image[] _lifesImage;
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _loosePanel;
        [SerializeField] private TextMeshProUGUI _collectibleText;

        private void OnEnable()
        {
            _houseController.OnReachToHouse += Win;
            _health.OnDeath += GameOver;
            _health.OnHealtChanged += LifeSpriteControl;
            _playerController.OnPickCherry += PickCollectible;
        }
        private void OnDisable()
        {
            _houseController.OnReachToHouse -= Win;
            _health.OnDeath -= GameOver;
            _health.OnHealtChanged -= LifeSpriteControl;
            _playerController.OnPickCherry -= PickCollectible;
        }
        void Win()
        {
            _winPanel.SetActive(true);
            Time.timeScale = 0;
        }

        void GameOver()
        {
            _loosePanel.SetActive(true);
            Time.timeScale = 0;
        }

        void PickCollectible()
        {
            _collectibleCount++;
            _collectibleText.text = _collectibleCount.ToString();
        }

        void LifeSpriteControl()
        {
            _lifes--;
            _lifesImage[_lifes].gameObject.SetActive(false);
        }
        public void LoadLevelAgain()
        {
            GameManager.Instance.LoadLevel();
        }
    }
}