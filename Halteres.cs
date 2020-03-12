using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Halteres : MonoBehaviour
{
    public TextMeshProUGUI text0;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6;
    public TextMeshProUGUI text7;
    public TextMeshProUGUI text8;
    public TextMeshProUGUI text9;
    public TextMeshProUGUI text10;
    public TextMeshProUGUI text11;
    public TextMeshProUGUI score;
    public TextMeshProUGUI timer;
    public char[] tabAlea = new char[111];
    public int point = 0;
    public int upWin = 0;
    public float timeLeft = 30F;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            Random rnd = new Random();
            tabAlea[i] = (char)Random.Range('A', 'Z');
        }
        text0.text = tabAlea[0].ToString();
        text1.text = tabAlea[1].ToString();
        text2.text = tabAlea[2].ToString();
        text3.text = tabAlea[3].ToString();
        text4.text = tabAlea[4].ToString();
        text5.text = tabAlea[5].ToString();
        text6.text = tabAlea[6].ToString();
        text7.text = tabAlea[7].ToString();
        text8.text = tabAlea[8].ToString();
        text9.text = tabAlea[9].ToString();
        text10.text = tabAlea[10].ToString();
        text11.text = tabAlea[11].ToString();

        text0.color = new Color32(0, 0, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft > 0)
        {
            if (timeLeft <= 6) timer.color = new Color32(254, 46, 46, 255);

            int t = (int)timeLeft;
            timer.text = t.ToString() + "s";
            score.text = "score: " + point.ToString();
            text0.text = tabAlea[upWin].ToString();
            text1.text = tabAlea[upWin + 1].ToString();
            text2.text = tabAlea[upWin + 2].ToString();
            text3.text = tabAlea[upWin + 3].ToString();
            text4.text = tabAlea[upWin + 4].ToString();
            text5.text = tabAlea[upWin + 5].ToString();
            text6.text = tabAlea[upWin + 6].ToString();
            text7.text = tabAlea[upWin + 7].ToString();
            text8.text = tabAlea[upWin + 8].ToString();
            text9.text = tabAlea[upWin + 9].ToString();
            text10.text = tabAlea[upWin + 10].ToString();
            text11.text = tabAlea[upWin + 11].ToString();

            if (Input.anyKeyDown)
            {
                foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(kcode))
                    {
                        char k = kcode.ToString().ToCharArray()[0];
                        if (k == tabAlea[upWin])
                        {
                            upWin++;
                            point++;
                            score.color = new Color32(71, 254, 51, 255);
                            text0.color = new Color32(0, 0, 0, 255);
                        }
                        else
                        {
                            point--;
                            score.color = new Color32(254, 46, 46, 255);
                            text0.color = new Color32(254, 46, 46, 255);
                        }
                    }
                }
            }
        }
    }
}
