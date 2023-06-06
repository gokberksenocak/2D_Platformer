using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Concretes.Managers
{
    public class GameManager : MonoBehaviour
    {
        /*private static GameManager _gameManager;
        public static GameManager Instance
        {
            get { return _gameManager; }
            private set { _gameManager = value; }
        }*/
        public static GameManager Instance { get; private set; }
        void Awake()
        {
            Singleton();
        }
        private void Singleton()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
        public void LoadLevel()
        {
            Time.timeScale = 1;
            //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(0);
        }
    }
}