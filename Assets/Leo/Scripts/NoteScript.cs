using System.Collections;
using UnityEngine;
public class NoteScript : MonoBehaviour
{
    [SerializeField] private AudioClip noteAudio;
    [SerializeField] private float fallingSpeed;
    [SerializeField] private float leftVelocity;
    private AudioSource audioSource;
    private void Update()
    {
        transform.position += Vector3.down * fallingSpeed * Time.deltaTime;
        transform.position += Vector3.left * leftVelocity * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (noteAudio != null)
            {
                StartCoroutine(DestroyAfterSound());
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    private IEnumerator DestroyAfterSound()
    {
        audioSource.PlayOneShot(noteAudio);
        yield return new WaitForSeconds(noteAudio.length);
        Destroy(gameObject);
    }
    public void SetFallingSpeed(float speed) { fallingSpeed = speed; }
    public void SetLeftVelocity(float velocity) { leftVelocity = velocity; }
}
