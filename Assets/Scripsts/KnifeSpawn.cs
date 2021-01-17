using System.Collections;
using UnityEngine;

public class KnifeSpawn : MonoBehaviour
{
    public Transform SpawnPosition;
    public GameObject Knife;

    void Start()
    {
        StartCoroutine(SpawnKnife());
    }

    void Repeat()
    {
        StartCoroutine(SpawnKnife());
    }

    IEnumerator SpawnKnife()
    {
        if (Knife.CompareTag("Log"))
        {
            Instantiate(Knife, SpawnPosition.position, Quaternion.identity);
            yield return new GameObject("Knife");
            Repeat();
        }
    }
}
