using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Halteres : MonoBehaviour
{
    public GameObject text0;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;
    public GameObject text7;
    public GameObject text8;
    public GameObject text9;
    public GameObject text10;
    public GameObject text11;
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
        text0.GetComponent<Text>().text = "[" + tabAlea[0] + "]";
        text1.GetComponent<Text>().text = "[" + tabAlea[1] + "]";
        text2.GetComponent<Text>().text = "[" + tabAlea[2] + "]";
        text3.GetComponent<Text>().text = "[" + tabAlea[3] + "]";
        text4.GetComponent<Text>().text = "[" + tabAlea[4] + "]";
        text5.GetComponent<Text>().text = "[" + tabAlea[5] + "]";
        text6.GetComponent<Text>().text = "[" + tabAlea[6] + "]";
        text7.GetComponent<Text>().text = "[" + tabAlea[7] + "]";
        text8.GetComponent<Text>().text = "[" + tabAlea[8] + "]";
        text9.GetComponent<Text>().text = "[" + tabAlea[9] + "]";
        text10.GetComponent<Text>().text = "[" + tabAlea[10] + "]";
        text11.GetComponent<Text>().text = "[" + tabAlea[11] + "]";
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft > 0)
        {
            text0.GetComponent<Text>().text = "[" + tabAlea[upWin] + "]";
            text1.GetComponent<Text>().text = "[" + tabAlea[upWin + 1] + "]";
            text2.GetComponent<Text>().text = "[" + tabAlea[upWin + 2] + "]";
            text3.GetComponent<Text>().text = "[" + tabAlea[upWin + 3] + "]";
            text4.GetComponent<Text>().text = "[" + tabAlea[upWin + 4] + "]";
            text5.GetComponent<Text>().text = "[" + tabAlea[upWin + 5] + "]";
            text6.GetComponent<Text>().text = "[" + tabAlea[upWin + 6] + "]";
            text7.GetComponent<Text>().text = "[" + tabAlea[upWin + 7] + "]";
            text8.GetComponent<Text>().text = "[" + tabAlea[upWin + 8] + "]";
            text9.GetComponent<Text>().text = "[" + tabAlea[upWin + 9] + "]";
            text10.GetComponent<Text>().text = "[" + tabAlea[upWin + 10] + "]";
            text11.GetComponent<Text>().text = "[" + tabAlea[upWin + 11] + "]";

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
                        }
                        else point--;
                        Debug.Log("score: " + point);
                        Debug.Log("temps restant: " + timeLeft + " s.");
                    }
                }
            }
        }
        else Debug.Log("Le jeu est fini, votre score est de: " + point);
    }
}
