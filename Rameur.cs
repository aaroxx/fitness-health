using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rameur : MonoBehaviour
{
    public bool leftpress = true;
    public int point = 0;
    public float timeLeft = 30F;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI score;

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft > 0)
        {
            if(timeLeft<=6) timer.color = new Color32(254, 46, 46, 255);

            int t = (int)timeLeft;
            timer.text = t.ToString() + "s";
            score.text = "score: " + point.ToString();
            float x = gameObject.transform.position.x;
            float d = 150F;


            if (Input.GetKeyDown(KeyCode.RightArrow) && leftpress)
            {
                    leftpress = false;
                    gameObject.transform.position = new Vector3(x + d, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && !leftpress)
            {
                    leftpress = true;
                    gameObject.transform.position = new Vector3(x - d, 0, 0);
                    point++;
            }
        }
    }
}
