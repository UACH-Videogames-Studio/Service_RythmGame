using UnityEngine;

public class ArkanoidMovement : MonoBehaviour
{
    private GameInputActions inputActions;
    private void Awake()
    {
        inputActions = GameManager.Instance.inputActions;
    }
}
