using UnityEngine;
public class ObstacleScript : MonoBehaviour
{
    [SerializeField] float rightVelocity;
    private void Update() { transform.position += Vector3.left * rightVelocity * Time.deltaTime; }
    public void SetVelocity(float velocity) { this.rightVelocity = velocity; }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}