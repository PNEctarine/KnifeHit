using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static int Highlevel;

    public GameObject gameOver;

    void Start()
    {
        gameOver.SetActive(false);
        Highlevel = PlayerPrefs.GetInt("Level");
    }

    void Update()
    {
        if (KnifeCollision.playLose)
        {
            gameOver.SetActive(true);
        }
    }

    public void Restart()
    {
        SetHighScore();

        KnifeCollision.Knifecounter = 0;
        KnifeCollision.inLog = false;
        KnifeCollision.win = false;
        KnifeCollision.lose = false;
        KnifeCollision.playLose = false;

        LogRotation.gameOver = false;

        KnifeHit.mouseOff = false;

        KnifeHit.score = 0;

        KnifeUI.knifeIndex = -1;

        NextLevel.CurrentLevel = 0;

        SceneManager.LoadScene(1);
    }

    public void Home()
    {
        SetHighScore();

        KnifeCollision.Knifecounter = 0;
        KnifeCollision.inLog = false;
        KnifeCollision.win = false;
        KnifeCollision.lose = false;
        KnifeCollision.playLose = false;

        LogRotation.gameOver = false;

        KnifeHit.mouseOff = false;
        KnifeHit.score = 0;

        KnifeUI.knifeIndex = -1;

        NextLevel.CurrentLevel = 0;

        SceneManager.LoadScene(0);
    }

    private void SetHighScore()
    {
        if (NextLevel.CurrentLevel > Highlevel)
        {
            Highlevel = NextLevel.CurrentLevel;
            PlayerPrefs.SetInt("Level", Highlevel);
        }

        else
        {
            PlayerPrefs.SetInt("Level", Highlevel);
        }
    }
}
