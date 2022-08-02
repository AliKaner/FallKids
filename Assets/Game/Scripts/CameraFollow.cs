using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform followingObject;
    [SerializeField] private float followSpeed;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        FollowObject();
    }

    private void Update()
    {
        FollowObject();
    }

    private void FollowObject()
    {
        var pos = followingObject.position;
        _transform.position = Vector3.Lerp(pos, pos + offset, followSpeed);
    }
}
    
