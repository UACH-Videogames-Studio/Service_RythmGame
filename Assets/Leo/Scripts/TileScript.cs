using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TileScript : MonoBehaviour
{
    [SerializeField] private AudioClip destroyAudio;
    [SerializeField] private List<GameObject> notesGameObjects;
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
                SpawnNote();
                Destroy(gameObject);
            }
        }
    }
    private void SpawnNote()
    {
        int randomIndex = Random.Range(0, notesGameObjects.Count);
        Instantiate(notesGameObjects[randomIndex], transform.position, Quaternion.identity);
    }
    private IEnumerator DestroyAfterSound()
    {
        audioSource.PlayOneShot(destroyAudio);
        yield return new WaitForSeconds(destroyAudio.length);
        SpawnNote();
        Destroy(gameObject);
    }
}
