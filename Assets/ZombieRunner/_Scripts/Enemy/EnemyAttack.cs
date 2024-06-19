using UnityEngine;

namespace ZombieRunner.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private Transform _targrtTransform;
        [SerializeField] private float _damage = 40f;

        private void Start()
        {
            
        }

        internal void AttackHitEvent()
        {
            if(_targrtTransform == null)
            {
                return;
            }
            Debug.Log("Attacking Player");
        }
    }
}