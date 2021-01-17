using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextLevel : MonoBehaviour
{
    public static int CurrentLevel;
    public Text levelWindow;

    private void Start()
    {
        CurrentLevel++;
        levelWindow.text = CurrentLevel.ToString();
    }

    void Update()
    {
        if (KnifeCollision.win == true)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.3f);

        KnifeCollision.win = false;
        KnifeCollision.Knifecounter = 0;
        KnifeCollision.inLog = false;
        KnifeCollision.lose = false;
        KnifeCollision.playLose = false;

        KnifeHit.mouseOff = false;
        KnifeUI.knifeIndex = -1;

        SceneManager.LoadScene(1);
    }

}
