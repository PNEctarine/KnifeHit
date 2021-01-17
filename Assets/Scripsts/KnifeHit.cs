using UnityEngine;
using UnityEngine.UI;

public class KnifeHit : MonoBehaviour
{
    public GameObject knifePrefub;
    private GameObject knife;

    public Text scoreWindow;

    public AudioSource HitSound;
    public AudioSource loseSound;

    public ParticleSystem Slivers;

    public static bool mouseOff = false;
    public float force;

    public static int score;

    private void Start()
    {
        knife = Instantiate(knifePrefub, transform);
    }

    private void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0) && mouseOff != true && LogRotation.gameOver != true)
        {
            knife.transform.parent = null;
            knife.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
            mouseOff = true;
        }

        if (!KnifeCollision.lose && KnifeCollision.inLog && !KnifeCollision.win)
        {
            KnifeCollision.inLog = false;
            knife = Instantiate(knifePrefub, transform);
            Slivers.Play();
            HitSound.Play();

            score++;
            mouseOff = false;
        }

        if(KnifeCollision.playLose == true)
        {
            loseSound.Play();
            KnifeCollision.playLose = false;
        }

        scoreWindow.text = score.ToString();
    }
}
