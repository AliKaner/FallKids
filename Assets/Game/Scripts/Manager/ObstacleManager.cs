using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager Instance;

    [Header("HorizontalObstacle")] public float horizontalObstacleMovementSpeed;
    [Header("VerticalObstacle")] public float verticalObstacleMovementSpeed;
    [Header("SpinningObstacle")] public float spinningObstacleSpinningSpeed;
    [Header("HalfDonutObstacle")] public float halfDonutObstacleMovementSpeed;

    private void Awake()
    {
        if (Instance == null || !Instance || !Instance.gameObject)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.LogError($"Another instance of {GetType()} already exist! Destroying self...");
            Destroy(this);
        }
    }
}