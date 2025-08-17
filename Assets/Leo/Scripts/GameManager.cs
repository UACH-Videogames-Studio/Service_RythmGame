using UnityEngine;
public class GameManager : MonoBehaviour
{
    public GameInputActions inputActions;
    private void Awake()
    {
        inputActions = new GameInputActions();
    }
}
