using UnityEngine;
using ZombieRunner.Player;

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
            FindObjectOfType<WeaponSwitcher>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}