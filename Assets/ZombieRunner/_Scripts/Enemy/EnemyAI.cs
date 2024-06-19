using System;
using UnityEngine;
using UnityEngine.AI;

namespace ZombieRunner.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        [Header("Targt Ref")]
        [SerializeField] private Transform _target;
        [SerializeField] private float _chaseRange = 5f;

        [Header("NavMesh Agent")]
        private NavMeshAgent _navMeshAgent;
        private float _distanceToTarget = Mathf.Infinity;

        private bool _isProvoked = false;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            _distanceToTarget = Vector3.Distance(_target.position,transform.position);

            if (_isProvoked)
            {
                EngageTarget();
            }

            else  if (_distanceToTarget <=  _chaseRange)
            {
                _isProvoked = true;
            }
        }

        private void EngageTarget()
        {
            if(_distanceToTarget >= _navMeshAgent.stoppingDistance)
            {
                Chasetarget();
            }

            if (_distanceToTarget <= _navMeshAgent.stoppingDistance)
            {
                AttackTarget();
            }
        }

        private void Chasetarget()
        {
            _navMeshAgent.SetDestination(_target.position);
        }

        private void AttackTarget()
        {
            Debug.Log(name + "Seeked and Destroyed" + _target.name);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _chaseRange);
        }
    }
}