using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rameur : MonoBehaviour
{
    public bool leftpress = true;
    public int point = 0;
    public float timeLeft = 30F;
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft > 0)
        {
            float x = gameObject.transform.position.x;
            float d = 5F;


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
                    Debug.Log("score: " + point);
                    Debug.Log("temps restant: " + timeLeft + " s.");
            }
        }
        else Debug.Log("Le jeu est fini, votre score est de: " + point);
    }
}
