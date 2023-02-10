using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFailure : MonoBehaviour
{
    private Animator _playerAnimator;

    [NonSerialized] public bool IsFailure = false;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            IsFailure = true;

            _playerAnimator.SetBool("Death_b", true);
            _playerAnimator.SetInteger("DeathType_int", 1);

            Debug.Log("Game Over!");
        }
    }
}
