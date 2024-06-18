using UnityEngine;

namespace ZombieRunner.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Script Reference")]
        [SerializeField] private Rigidbody _rigidbody;

        [Header("Player Attributes")]
        [SerializeField] private float _speed = 5.0f;
        [SerializeField] private float _jumpForce = 5.0f;
        [SerializeField] private float _gravity = -9.81f;
        [SerializeField] private bool _isGrounded;

        private Vector3 moveDirection;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.freezeRotation = true; // Freeze rotation on all axes
        }

        void Update()
        {
            PlayerMovement();
        }

        void FixedUpdate()
        {
            _rigidbody.MovePosition(_rigidbody.position + moveDirection * _speed * Time.fixedDeltaTime);

            // Apply gravity each physics update
            _rigidbody.AddForce(Vector3.up * _gravity * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
        private void PlayerMovement()
        {
            _isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.2f); // Check for ground

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            moveDirection = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;

            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                Jump();
            }
        }

        void Jump()
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
        }
    }


}