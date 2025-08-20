using System.Collections;
using UnityEngine;
public class TileScript : MonoBehaviour
{
    [SerializeField] private AudioClip destroyAudio;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (destroyAudio != null)
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
        audioSource.PlayOneShot(destroyAudio);
        yield return new WaitForSeconds(destroyAudio.length);
        Destroy(gameObject);
    }
}
