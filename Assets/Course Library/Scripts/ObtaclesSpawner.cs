using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtaclesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclePrefabs;

    private PlayerFailure _player;

    private int _obstacleIndex;

    private float _startDelay = 2.0f;
    private float _repeatRate = 3.0f;

    private Vector3 _spawnPoint;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerFailure>();

        InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
    }

    private void SpawnObstacle()
    {
        _spawnPoint = new Vector3(Random.Range(20, 25), 0, 0);

        _obstacleIndex = Random.Range(0, _obstaclePrefabs.Length);

        if (!_player.IsFailure)
            Instantiate(_obstaclePrefabs[_obstacleIndex], 
                _spawnPoint, _obstaclePrefabs[_obstacleIndex].transform.rotation);
    }
}
