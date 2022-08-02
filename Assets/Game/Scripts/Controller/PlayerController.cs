using System;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    private float _lastFrameFingerPositionX;
    private float _moveFactor;
    private Rigidbody _rb;
    
    [Header("Settings")] 
    public float speed;
    public float roadWidth;
    public float verticalMult;
    public float sweepMult;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        SweepControl();
    }

    private void VerticalMovement(float multiplier)
    {
        var position = transform.position;
        position = new Vector3(position.x, position.y, Mathf.Clamp(position.z - _moveFactor * multiplier, -roadWidth, roadWidth));
        transform.position = position;
    }

    private void ForwardMovement(float _speed)
    {
        _rb.AddForce(Vector3.forward*_speed);
    }

    private void SweepControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition.z;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactor = Mathf.Clamp((_lastFrameFingerPositionX - Input.mousePosition.z) / sweepMult, -roadWidth, roadWidth);
            VerticalMovement(verticalMult);
            ForwardMovement(speed);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactor = 0f;
        }
    }
}