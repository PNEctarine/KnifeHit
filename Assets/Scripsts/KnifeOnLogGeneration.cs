using UnityEngine;

public class KnifeOnLogGeneration : MonoBehaviour
{
    public GameObject knifePrefub;
    private GameObject knife;

    private int numbersOfKnives;
    private int cycle;

    private void Start()
    {
        numbersOfKnives = Random.Range(1, 3);

        for (cycle = 0; cycle <= numbersOfKnives; cycle++)
        {
            float randomPosition = Random.Range(10, 360);

            knife = Instantiate(knifePrefub);
            knife.transform.parent = gameObject.transform;
            knife.transform.Translate(gameObject.transform.position.x, gameObject.transform.position.y / 3.75f, 0);
            gameObject.transform.Rotate(0, 0, randomPosition);
        }
    }
}
