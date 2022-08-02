using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag)
        {
            case "Player":
                GameStateManager.Instance.SetGameState(GameStates.Paint);
                break;
            case "Character":
                collision.gameObject.GetComponent<CharacterController>().Death();
                GameStateManager.Instance.SetGameState(GameStates.Lose);
                break;
        }
    }
}