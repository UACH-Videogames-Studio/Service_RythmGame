using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class ArkanoidMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float xMaxLimit;
    [SerializeField] private GameObject ballPosition;
    [SerializeField] private GameObject ball;
    [SerializeField] private TMP_Text scoreText;
    private GameInputActions inputActions;
    private Rigidbody2D rb;
    private float moveX, newX, movementVector;
    private bool theBallHasBeenInstatiate = false;
    private int lifes;
    private void UpdateScore() { scoreText.text = "VIDAS: " + lifes.ToString(); }
    private void Awake()
    {
        inputActions = GameManager.Instance.inputActions;
        theBallHasBeenInstatiate = false;
        lifes = 3;
        UpdateScore();
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
    private void EndGame()
    {
    }
    public void RestartBall()
    {
        theBallHasBeenInstatiate = false;
        ballPosition.GetComponent<SpriteRenderer>().enabled = true;
        lifes--;
        if (lifes <= 0)
        {
            EndGame();
        }
        else
        {
            UpdateScore();
        }
    }
}