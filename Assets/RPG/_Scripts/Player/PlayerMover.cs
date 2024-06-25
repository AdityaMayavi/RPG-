using System;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _chaseSpeed = 50f;

        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        private Ray _lastRay;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            MoveToCursor();
            UpdateAnimator();
        }

        private void MoveToCursor()
        {
            if (Input.GetMouseButton(0))
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

        private void UpdateAnimator()
        {
            Vector3 velociy  = _navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velociy);
            float speed = localVelocity.z;
            _animator.SetFloat("ForwardSpeed", speed);
        }
    }
}