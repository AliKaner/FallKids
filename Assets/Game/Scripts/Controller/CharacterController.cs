using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform finishLine;

    private AnimationClip _animation;
    private Vector3 _startLocation;
    private NavMeshAgent _navMeshAgent;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _startLocation = transform.position;
        anim.SetBool(IsWalking, true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag)
        {
            case "Obstacle":
                Death();
                break;
            case "Finish":
                break;
        }
    }

    public void Death()
    {
        var speed = _navMeshAgent.speed;
        transform.position = _startLocation;
        _navMeshAgent.speed = speed;
    }

    private void Update()
    {
        _navMeshAgent.destination = finishLine.position;
    }

    public NavMeshAgent GetNavMeshAgent()
    {
        return _navMeshAgent;
    }
}