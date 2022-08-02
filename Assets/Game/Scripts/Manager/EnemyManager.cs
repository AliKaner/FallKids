using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private CharacterController[] enemies;

    public void StopEnemies()
    {
        foreach (var enemy in enemies)
        {
            enemy.GetNavMeshAgent().speed = 0;
        }
    }

    public void RestartEnemies()
    {
        foreach (var enemy in enemies)
        {
            enemy.Death();
        }
    }
}