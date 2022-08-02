using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalObstacle : MonoBehaviour
{
    [SerializeField] private float endPositionY;

    private float _startPositionY;
    private float _movementSpeed;
    private bool _isMoveForward = true;
    private void Start()
    {
        _startPositionY = GetComponent<Transform>().position.z;
        _movementSpeed = ObstacleManager.Instance.verticalObstacleMovementSpeed;
    }

    private void VerticalMovement()
    {
        switch (_isMoveForward)
        {
            case true:
            {
                transform.Translate(Vector3.up*Time.deltaTime*_movementSpeed);
                if (transform.position.y > endPositionY)
                {
                    _isMoveForward = false;
                }
                break;
            }
            case false:
            {
                transform.Translate(Vector3.down*Time.deltaTime*_movementSpeed);
                if (transform.position.y < _startPositionY)
                {
                    _isMoveForward = true;
                }
                break;
            }
        }
    }
    private void Update()
    {
        VerticalMovement();
    }
}
