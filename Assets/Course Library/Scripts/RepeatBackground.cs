using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 _startPositon;

    private float _repeatWitdh;

    private void Start()
    {
        _repeatWitdh = GetComponent<BoxCollider>().size.x / 2;

        _startPositon = transform.position;
    }

    private void Update()
    {
        if (transform.position.x < _startPositon.x - _repeatWitdh)
            transform.position = _startPositon;
    }
}
