using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HalfDonut : MonoBehaviour
{
    [SerializeField] private float rotationX;
    [SerializeField] private Transform donutStick;

    private float _pullSpeed;
    private Vector3 _localPosition;
    private float _pushSpeed;
    private float _startRotationZ;
    private float _movementSpeed;

    private void Start()
    {
        _localPosition = donutStick.localPosition;
        _movementSpeed = ObstacleManager.Instance.halfDonutObstacleMovementSpeed;
        StartCoroutine(Push(rotationX,0.5f));
    }

    private IEnumerator Pull(float amount,float time)
    {
        donutStick.DOLocalMove(new Vector3(_localPosition.x-amount,_localPosition.y,_localPosition.z),time);
        yield return new WaitForSeconds(time);
        StartCoroutine(Push(amount, time*0.25f*_movementSpeed));
    }

    private IEnumerator Push(float amount,float time)
    {
        donutStick.DOLocalMove(new Vector3(_localPosition.x+amount,_localPosition.y,_localPosition.z),time);
        yield return new WaitForSeconds(time);
        StartCoroutine(Pull(amount, time*4*_movementSpeed));
    }

}
