using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZombieRunner
{
    public class SceneLoader : MonoBehaviour
    {
        public void ReloadGame()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}