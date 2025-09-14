using UnityEngine;
public class ObstacleScript : MonoBehaviour
{
    [SerializeField] float rightVelocity;
    private void Update() { transform.position += Vector3.left * rightVelocity * Time.deltaTime; }
    public void SetVelocity(float velocity) { this.rightVelocity = velocity; }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
    //     {
    //         Destroy(this.gameObject);
    //     }
    // }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Revisamos los puntos de contacto de la colisión
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // Si la normal apunta hacia arriba (jugador vino de arriba)
                if (contact.normal.y > 0.5f) return;
            }
            // Si no cayó encima, entonces sí recibe daño
            if (GameManager.Instance.player != null)
            {
                GameManager.Instance.player.TakeDamage();
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Wall")) Destroy(gameObject);
    }
}