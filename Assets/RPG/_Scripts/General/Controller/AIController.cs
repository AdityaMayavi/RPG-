using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using System;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private float _chaseDistance = 5f;
        [SerializeField] private float _suspitionTime = 3f;

        [Range(0,1)] [SerializeField] private float _patrolSpeedFraction = 0.2f;

        [SerializeField] private PatrolPath _patrolPath;
        [SerializeField] private float _wayPointTolerance = 1f;
        [SerializeField] private float _wayPointDwellTime = 3f;

        private Fighter _fighter;
        private GameObject _player;
        private Health _health;
        private Mover _mover;

        private Vector3 _guardPosition;
        private float _timeSinceLastSawPlayer = Mathf.Infinity;
        private float _timeSinceArrivedAtWayPoint = Mathf.Infinity;
        private int _currentWayPointIndex = 0;

        private void Start()
        {
            _fighter = GetComponent<Fighter>();
            _player = GameObject.FindWithTag("Player");
            _health = GetComponent<Health>();
            _mover = GetComponent<Mover>();

            _guardPosition = transform.position;
        }

        private void Update()
        {
            if (_health.IsDead())
            {
                return;
            }

            if (InAttackRangeOfPlayer() && _fighter.CanAttack(_player))
            {
                AttackBehaviour();
            }
            else if (_timeSinceLastSawPlayer < _suspitionTime)
            {
                SuspicionBehaviour();
            }

            else
            {
                PatrolBehaviour();
            }
            UpdateTimers();
        }

        private void UpdateTimers()
        {
            _timeSinceLastSawPlayer += Time.deltaTime;
            _timeSinceArrivedAtWayPoint += Time.deltaTime;
        }

        private void PatrolBehaviour()
        {
            Vector3 nextPosition = _guardPosition;

            if(_patrolPath != null)
            {
                if(AtWayPoint())
                {
                    _timeSinceArrivedAtWayPoint = 0;
                    CycleWayPoint();
                }
                nextPosition = GetCurrentWayPoint();
            }
            if(_timeSinceArrivedAtWayPoint > _wayPointDwellTime)
            {
                _mover.StartMoveAction(nextPosition, _patrolSpeedFraction);
            }
        }

        private Vector3 GetCurrentWayPoint()
        {
           return _patrolPath.GetWayPoint(_currentWayPointIndex);
        }

        private void CycleWayPoint()
        {
            _currentWayPointIndex = _patrolPath.GetNextIndex(_currentWayPointIndex);
        }

        private bool AtWayPoint()
        {
            float distanceToWayPoints = Vector3.Distance(transform.position,GetCurrentWayPoint());
            return distanceToWayPoints < _wayPointTolerance;
        }

        private void SuspicionBehaviour()
        {
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        private void AttackBehaviour()
        {
            _timeSinceLastSawPlayer = 0;
            _fighter.Attack(_player);
        }

        private bool InAttackRangeOfPlayer()
        {
            float distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);
            return distanceToPlayer < _chaseDistance;  
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _chaseDistance);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _chaseDistance);
        }
    }
}