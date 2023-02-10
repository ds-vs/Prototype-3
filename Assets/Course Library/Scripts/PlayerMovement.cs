using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpKey;

    [SerializeField] private float _jumpForce = 10.0f;

    private PlayerFailure _player;

    private Rigidbody _playerRigidBody;
    private Animator _playerAnimator;

    private bool _isOnGround = true;

    private float _gravityModifier = 1.5f;

    private void Start()
    {
        _player = GetComponent<PlayerFailure>();
        _playerRigidBody = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<Animator>();

        Physics.gravity *= _gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey) && _isOnGround && !_player.IsFailure)
        {
            _playerRigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

            _playerAnimator.SetTrigger("Jump_trig");

            _isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            _isOnGround = true;
    }
}
