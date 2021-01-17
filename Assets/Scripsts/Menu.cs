using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Knife;
    public GameObject PlayButton;

    public Text highLevel;

    public Text applesText;

    private bool play = false;

    private float knifePosition = 0;
    private float highLevelPosition = 0;

    private void Start()
    {
        highLevel.GetComponent<Text>().text = PlayerPrefs.GetInt("Level").ToString();
        applesText.text = PlayerPrefs.GetInt("Apples").ToString();
    }

    private void Update()
    {
        if (play)
        {
            if (Knife.transform.position.y > -2.207f & highLevel.transform.position.y < 10f)
            {
                Knife.transform.Translate(0, knifePosition * Time.deltaTime, 0);
                PlayButton.transform.Translate(0, knifePosition * Time.deltaTime, 0);
                knifePosition -= 1.2f;

                highLevel.transform.Translate(0, highLevelPosition * Time.deltaTime, 0);
                highLevelPosition += 1.2f;

            }

            else
            {
                SceneManager.LoadScene(1);
            }

        }
    }

    public void Play()
    {
        play = true;
    }
}
