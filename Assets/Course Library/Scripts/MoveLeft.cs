using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerFailure _player;

    private float _speed = 6.5f;
    private float _leftBound = -10.0f;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerFailure>();
    }

    private void Update()
    {
        if (!_player.IsFailure)
            transform.Translate(Vector3.left * Time.deltaTime * _speed);

        if (gameObject.CompareTag("Obstacle") && transform.position.x < _leftBound)
            Destroy(gameObject);
    }
}
