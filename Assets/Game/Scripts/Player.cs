using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform startTransform;
   

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag)
        {
            case "Obstacle":
                GameStateManager.Instance.SetGameState(GameStates.Lose);
                break;
            case "Water":
                GameStateManager.Instance.SetGameState(GameStates.Lose);
                break;
        }

    }
    public void RestartPlayer()
    {
        transform.position = startTransform.position;
        transform.rotation = startTransform.rotation;
    }
}
