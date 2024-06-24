using System;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Enemy
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _chaseSpeed = 50f;

        private NavMeshAgent _navMeshAgent;
        private Ray _lastRay;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            if (Input.GetMouseButtonDown(0))
            {
                //_lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);

            if (hasHit)
            {
                _navMeshAgent.destination = hit.point * _chaseSpeed * Time.deltaTime;
            }
        }
    }
}