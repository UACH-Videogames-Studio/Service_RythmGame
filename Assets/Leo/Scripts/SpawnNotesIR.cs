using System.Collections;
using UnityEngine;

public class SpawnNotesIR : MonoBehaviour
{
    [SerializeField] private GameObject[] notesToSpawn;
    [SerializeField] private float yMaxSpawn, yMinSpawn, xLocationSpawn, notesVelocity, timeBetweenSpawn;
    private float randomLocation;
    private int randomIndex;
    private void OnEnable() { StartCoroutine(SpawnTime()); }
    private void OnDisable() { StopAllCoroutines(); }
    private void SpawnNote(GameObject prefab)
    {
        randomLocation = Random.Range(yMinSpawn, yMaxSpawn);
        GameObject instance = Instantiate(prefab, new Vector2(xLocationSpawn, randomLocation), Quaternion.identity);
        NoteScript noteScript = instance.GetComponent<NoteScript>();
        noteScript.SetFallingSpeed(0);
        noteScript.SetLeftVelocity(notesVelocity);
    }
    private IEnumerator SpawnTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);
            randomIndex = Random.Range(0, notesToSpawn.Length);
            SpawnNote(notesToSpawn[randomIndex]);
        }
    }
}