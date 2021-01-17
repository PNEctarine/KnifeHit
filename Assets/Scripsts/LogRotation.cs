using UnityEngine;

public class LogRotation : MonoBehaviour
{
    public static float logRotateSpeed = 3f;
    public static bool gameOver = false;

    void FixedUpdate()
    {
        if (gameOver == false)
        {
            transform.Rotate(0, 0, logRotateSpeed);
        }

        else
        {
            transform.Rotate(0, 0, 0);
        }
    }
}
