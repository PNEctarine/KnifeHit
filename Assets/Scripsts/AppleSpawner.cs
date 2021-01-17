using UnityEngine.UI;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    private GameObject apple;
    private GameObject destroyedApple_0;
    private GameObject destroyedApple_1;
    public GameObject log;
    public Text applesText;

    public static int appleCoin;

    public AudioSource appleHit;

    public Data appleSpawn;

    private void Start()
    {
        appleCoin = PlayerPrefs.GetInt("Apples");
        applesText.text = appleCoin.ToString();
        appleSpawn.chance = Random.Range(0, 100);
        SpawnEntities();
    }

    private void Update()
    {
        if (KnifeCollision.appleCollision)
        {
            apple.transform.parent = null;
            apple.SetActive(false);

            destroyedApple_0 = Instantiate(appleSpawn.destroyedAppe_0);
            destroyedApple_1 = Instantiate(appleSpawn.destroyedAppe_1);

            destroyedApple_0.transform.position = apple.transform.position;
            destroyedApple_1.transform.position = apple.transform.position;

            destroyedApple_0.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, -5);
            destroyedApple_1.GetComponent<Rigidbody2D>().velocity = new Vector2(5, -5);

            destroyedApple_0.GetComponent<Rigidbody2D>().gravityScale = 1f;
            destroyedApple_1.GetComponent<Rigidbody2D>().gravityScale = 1f;

            appleHit.Play();

            appleCoin++;
            PlayerPrefs.SetInt("Apples", appleCoin);
            applesText.text = appleCoin.ToString();

            KnifeCollision.appleCollision = false;
        }
    }

    void SpawnEntities()
    {
        if (appleSpawn.chance <= 25)
        {
            apple = Instantiate(appleSpawn.applePrefub);
            apple.transform.parent = log.transform;
            apple.transform.Translate(log.transform.position.x, log.transform.position.y / 5, 0);
            apple.transform.Rotate(0, 0, 180);
        }
    }
}
