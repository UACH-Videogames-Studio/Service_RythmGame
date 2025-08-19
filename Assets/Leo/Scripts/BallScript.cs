using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float initialForce;
    private Rigidbody2D rb;
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }
    private void LaunchBall()
    {
        rb.AddForce(Vector2.up * initialForce, ForceMode2D.Impulse);
    }
}