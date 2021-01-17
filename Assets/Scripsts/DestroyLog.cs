using UnityEngine;
using UnityEngine.UI;

public class DestroyLog : MonoBehaviour
{
    public GameObject destructable;
    //public GameObject Knife;

    public AudioSource destroyLogSound;

    public static int logHealth = 7;

    public void FixedUpdate()
    {
        destructable.transform.Rotate(0, 0, LogRotation.logRotateSpeed);

        if (KnifeCollision.Knifecounter == logHealth)
        {
            GameObject destruct = Instantiate(destructable);
            destruct.transform.position = transform.position;
            gameObject.SetActive(false);
            KnifeCollision.Knifecounter = 0;
            destroyLogSound.Play();
        }
    }
}
