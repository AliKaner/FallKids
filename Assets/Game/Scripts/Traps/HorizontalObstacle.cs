using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HorizontalObstacle : MonoBehaviour
{
    [SerializeField] private float endPositionZ;

    private float _startPositionZ;
    private float _movementSpeed;
    private bool _isMoveForward = true;
    private void Awake()
    {
        _startPositionZ = GetComponent<Transform>().position.z;
        
    }

    private void Start()
    {
        _movementSpeed = ObstacleManager.Instance.horizontalObstacleMovementSpeed;
    }

    private void HorizontalMovement()
    {
        switch (_isMoveForward)
        {
            case true:
            {
                transform.Translate(Vector3.forward*Time.deltaTime*_movementSpeed);
                if (transform.position.z > endPositionZ)
                {
                    _isMoveForward = false;
                }

                break;
            }
            case false:
            {
                transform.Translate(Vector3.back*Time.deltaTime*_movementSpeed);
                if (transform.position.z < _startPositionZ)
                {
                    _isMoveForward = true;
                }

                break;
            }
        }
    }
    private void Update()
    {
        HorizontalMovement();
    }
    
}
