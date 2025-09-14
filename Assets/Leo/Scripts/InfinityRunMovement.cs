using UnityEngine;
public class InfinityRunMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float numberOfJumps;
    private GameInputActions inputActions;
    private int jumpCount = 0;
    private Rigidbody2D playerRigidbody2D;
    private void Start() { playerRigidbody2D = GetComponent<Rigidbody2D>(); }
    private void OnEnable()
    {
        inputActions.InfinityRun.Enable();
    }
    private void OnDisable()
    {
        inputActions.InfinityRun.Disable();
    }
    private void Awake()
    {
        inputActions = GameManager.Instance.inputActions;
        jumpCount = 0;
    }
    private void Update()
    {
        if (inputActions.InfinityRun.Jump.WasPerformedThisFrame()) Jump();
    }
    private void Jump()
    {
        if (jumpCount < numberOfJumps)
        {
            playerRigidbody2D.linearVelocity = new Vector2(playerRigidbody2D.linearVelocity.x, jumpForce);
            jumpCount++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DownLimit")) jumpCount = 0;
    }
}