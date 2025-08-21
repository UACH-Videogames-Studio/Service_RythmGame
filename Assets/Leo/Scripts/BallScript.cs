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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DownLimit"))
        {
            DestroyThis();
        }
    }
    private void DestroyThis()
    {
        ArkanoidMovement arkanoidMovement = FindAnyObjectByType<ArkanoidMovement>().GetComponent<ArkanoidMovement>();
        arkanoidMovement.RestartBall();
        Destroy(gameObject);
    }
}