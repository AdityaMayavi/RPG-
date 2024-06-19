using UnityEngine;
using zombieRunner.Player;

namespace ZombieRunner.Player
{
    public class PlayeraHealth : MonoBehaviour
    {
        [SerializeField] private float _hitPoints = 100f;

        [SerializeField] private PlayerDeathHandler _playerDeathHandler;

        private void start()
        {
        }

        internal void PlayerTakeDamage(float damage)
        {
            _hitPoints -= damage;

            if (_hitPoints <= 0)
            {
                _playerDeathHandler.HandleDeath();
                Debug.Log("You are Dead" + _hitPoints); 
            }
        }
    }
}