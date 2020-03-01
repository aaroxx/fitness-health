using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Presse : MonoBehaviour
{
    public Jauge temps;
    public GameObject text;
    public int point = 0;
    public float decrementation = 0.5F;
    public float timeLeft = 30F;

    void Start()
    {
        text.GetComponent<Text>().text = "[M]";
        temps = GameObject.Find("Image").GetComponent<Jauge>();
        temps.set_max(100F);
        temps.set_valeur(100F);
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft > 0)
        {
            temps.set_valeur(temps.get_valeur() - decrementation);

            if (temps.get_valeur() <= 0F)
            {
                point -= 2;
                decrementation -= 0.125F;
                temps.set_valeur(100F);
                Debug.Log("score: " + point);
                Debug.Log("temps restant: " + timeLeft + " s.");
            }
            if (Input.GetKeyDown(KeyCode.M) && temps.get_valeur() <= 15F)
            {
                point += 2;
                decrementation += 0.125F;
                temps.set_valeur(100F);
                Debug.Log("score: " + point);
                Debug.Log("temps restant: " + timeLeft + " s.");
            }
            else if (Input.GetKeyDown(KeyCode.M) && temps.get_valeur() <= 30F)
            {
                point++;
                decrementation += 0.0625F;
                temps.set_valeur(100F);
                Debug.Log("score: " + point);
                Debug.Log("temps restant: " + timeLeft + " s.");
            }
            else if (Input.GetKeyDown(KeyCode.M))
            {
                point--;
                decrementation -= 0.0625F;
                temps.set_valeur(100F);
                Debug.Log("score: " + point);
                Debug.Log("temps restant: " + timeLeft + " s.");
            }
            if (decrementation <= 0.0625F)
            {
                decrementation = 0.125F;
            }
        }
    }
}