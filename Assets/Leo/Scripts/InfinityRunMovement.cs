using UnityEngine;
public class InfinityRunMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float numberOfJumps;
    private GameInputActions inputActions;
    private int jumpCount = 0;
    private Rigidbody2D playerRigidbody2D;
    private Animator playerAnimator;
    private void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }
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
            playerAnimator.SetBool("IsJumping", true);
        }
    }
    private void StopJump()
    {
        jumpCount = 0;
        playerAnimator.SetBool("IsJumping", false);
    }
    private void TakeDamage()
    {
        Debug.Log("Has taken damage");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DownLimit")) StopJump();
        if (collision.gameObject.CompareTag("Obstacle")) TakeDamage();
    }
}