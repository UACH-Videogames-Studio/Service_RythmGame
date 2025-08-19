using UnityEngine;
using UnityEngine.InputSystem;
public class ArkanoidMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float xMaxLimit;
    [SerializeField] private GameObject ballPosition;
    [SerializeField] private GameObject ball;
    private GameInputActions inputActions;
    private Rigidbody2D rb;
    private float moveX, newX, movementVector;
    private bool theBallHasBeenInstatiate = false;
    private void Awake()
    {
        inputActions = GameManager.Instance.inputActions;
        theBallHasBeenInstatiate = false;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        inputActions.Arkanoid.Enable();
        inputActions.Arkanoid.Move.performed += Move;
        inputActions.Arkanoid.Move.canceled += Move;
        inputActions.Arkanoid.Launch.performed += Launch;
    }
    private void OnDisable()
    {
        inputActions.Arkanoid.Move.performed -= Move;
        inputActions.Arkanoid.Move.canceled -= Move;
        inputActions.Arkanoid.Launch.performed -= Launch;
        inputActions.Arkanoid.Disable();
    }
    private void Move(InputAction.CallbackContext context)
    {
        movementVector = context.ReadValue<float>();
    }
    private void FixedUpdate()
    {
        moveX = movementVector * speed * Time.fixedDeltaTime;
        newX = Mathf.Clamp(transform.position.x + moveX, -xMaxLimit, xMaxLimit);
        if (rb != null)
        {
            rb.MovePosition(new Vector2(newX, transform.position.y));
        }
        else
        {
            transform.position = new Vector3(newX, transform.position.y, 0f);
        }
    }
    private void Launch(InputAction.CallbackContext context)
    {
        if (!theBallHasBeenInstatiate)
        {
            ballPosition.GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(ball, ballPosition.transform.position, Quaternion.identity);
            theBallHasBeenInstatiate = true;
        }
    }
}