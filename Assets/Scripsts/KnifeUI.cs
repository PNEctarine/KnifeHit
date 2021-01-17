using UnityEngine.UI;
using UnityEngine;

public class KnifeUI : MonoBehaviour
{
    public GameObject knifeIconPrefub;

    public GameObject knivesPannel;

    public Color usedKnivesColor;

    private GameObject knifeIcon;

    public static int knifeIndex = -1;
    private int cycle;

    private void Start()
    {
        CreateKnifeIcon();
    }

    private void Update()
    {
        UsedKnife();
    }

    public void CreateKnifeIcon()
    {
        for (cycle = 0; cycle < DestroyLog.logHealth; cycle++)
        {
            knifeIcon = Instantiate(knifeIconPrefub, knivesPannel.transform);
            knifeIcon.transform.Translate(0, knivesPannel.transform.position.y + 0.5f * cycle, 0);
        }
    }

    public void UsedKnife()
    {
        if (KnifeCollision.inLog)
        {
            knivesPannel.transform.GetChild(knifeIndex).GetComponent<Image>().color = usedKnivesColor;
        }

    }
}
