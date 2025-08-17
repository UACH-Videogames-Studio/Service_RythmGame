using UnityEngine;
public class GameManager : MonoBehaviour
{
    //
    public static GameManager Instance { get; private set; }
    public GameInputActions inputActions;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            if (inputActions == null) inputActions = new GameInputActions();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
