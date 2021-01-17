using UnityEngine.UI;
using UnityEngine;

public class KnifeCollision : MonoBehaviour
{
    public static int Knifecounter = 0;

    public static bool inLog = false;
    public static bool win = false;
    public static bool lose = false;
    public static bool playLose = false;
    public static bool appleCollision = false;

    public GameObject destroyedLog;
    private GameObject knife;
    private GameObject log;

    public new Rigidbody2D rigidbody;



    public void OnTriggerEnter2D(Collider2D collision)
    {
        Vibration.Init();
        log = collision.gameObject;

        if (collision.CompareTag("Log") && !collision.CompareTag("Knife") && !win) // Удар в дерево
        {
            Knifecounter++;

            if (Knifecounter != DestroyLog.logHealth)
            {
                rigidbody.velocity = Vector2.zero;
                gameObject.transform.parent = log.transform;
                inLog = true;
                KnifeUI.knifeIndex++;

                Vibration.VibratePop();
            }

            else if (Knifecounter == DestroyLog.logHealth)
            {
                inLog = true;
                LogRotation.gameOver = false;
                gameObject.transform.parent = log.transform;
                rigidbody.velocity = Vector2.zero;
                KnifeUI.knifeIndex++;
                KnifeHit.score++;

                Handheld.Vibrate();

                while (0 < log.transform.childCount)
                {
                    knife = log.transform.GetChild(0).gameObject;
                    knife.transform.parent = null;
                    knife.SetActive(true);
                    knife.GetComponent<Rigidbody2D>().gravityScale = 1f;
                    knife.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Random.Range(4f, 7f), ForceMode2D.Impulse);
                    knife.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-70, 70));
                }

                win = true;
            }
        }

        else if (collision.CompareTag("Knife") | collision.CompareTag("KnifeOnLog") && !collision.CompareTag("Log") && !win) // Удар о нож
        {
            if (!LogRotation.gameOver)
            {
                rigidbody.gravityScale = 1;
                rigidbody.velocity = new Vector2(10, -5) ;
                rigidbody.AddTorque(-600);

                KnifeHit.mouseOff = true;
                LogRotation.gameOver = true;
                Handheld.Vibrate();

                playLose = true;
                lose = true;
            }
        }

        if (collision.CompareTag("Apple") && !collision.CompareTag("Knife"))
        {
            appleCollision = true;
        }
    }
}
