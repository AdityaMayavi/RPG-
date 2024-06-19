using UnityEngine;
using ZombieRunner.Player;

namespace ZombieRunner.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private PlayeraHealth _targrtTransform;
        [SerializeField] private float _damage = 40f;

        [SerializeField] private PlayeraHealth _playerHealth;

        private void Start()
        {
        }
        public void OnDamageTaken()
        {
            Debug.Log("We also know we took damage");
        }

        private void AttackHitEvent()
        {
            if(_targrtTransform == null)
            {
                return;
            }
            _playerHealth.PlayerTakeDamage(_damage);
            Debug.Log("Attacking Player");
        }
    }
}