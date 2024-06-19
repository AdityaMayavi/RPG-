using UnityEngine;

namespace zombieRunner.Player
{
    public class PlayerDeathHandler : MonoBehaviour
    {
        [SerializeField] private Canvas _gameOverCanvas;

        private void Start()
        {
            _gameOverCanvas.enabled = false;
        }
        internal void HandleDeath()
        {
            _gameOverCanvas.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}