using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObstacle : MonoBehaviour
{
    private float _spinningSpeed;

    private void Start()
    {
        _spinningSpeed = ObstacleManager.Instance.spinningObstacleSpinningSpeed;
    }

    private void Spin()
    {
        transform.Rotate (0,10*_spinningSpeed*Time.deltaTime,0);
    }
    private void Update()
    {
        Spin();
    }
}
