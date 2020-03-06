using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Presse : MonoBehaviour
{
    public Jauge temps;
    public TextMeshProUGUI lettre;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI score;
    public TextMeshProUGUI indicateur;
    public int point = 0;
    public float decrementation = 0.5F;
    public float timeLeft = 30F;

    void Start()
    {
        temps = GameObject.Find("Image").GetComponent<Jauge>();
        temps.set_max(100F);
        temps.set_valeur(100F);
        lettre.text = "M";
        indicateur.fontSize = 25;
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft > 0)
        {
            int t = (int)timeLeft;
            timer.text = t.ToString() + "s";
            score.text = "score: " + point.ToString();
            temps.set_valeur(temps.get_valeur() - decrementation);

            if (temps.get_valeur() <= 0F)
            {
                point -= 2;
                decrementation -= 0.125F;
                temps.set_valeur(100F);
                score.color = new Color32(254, 46, 46, 255);
                indicateur.text = "Trop tard";
                indicateur.color = new Color32(254, 46, 46, 255);
            }
            if (Input.GetKeyDown(KeyCode.M) && temps.get_valeur() <= 15F)
            {
                point += 2;
                decrementation += 0.125F;
                temps.set_valeur(100F);
                score.color = new Color32(71, 254, 51, 255);
                indicateur.text = "Parfait!";
                indicateur.color = new Color32(7, 226, 0, 255);
            }
            else if (Input.GetKeyDown(KeyCode.M) && temps.get_valeur() <= 40F)
            {
                point++;
                decrementation += 0.0625F;
                temps.set_valeur(100F);
                score.color = new Color32(71, 254, 51, 255);
                indicateur.text = "Pas mal";
                indicateur.color = new Color32(7, 226, 0, 255);
            }
            else if (Input.GetKeyDown(KeyCode.M))
            {
                point--;
                decrementation -= 0.0625F;
                temps.set_valeur(100F);
                score.color = new Color32(254, 46, 46, 255);
                indicateur.text = "Trop tôt";
                indicateur.color = new Color32(254, 46, 46, 255);
            }
            if (decrementation <= 0.0625F)
            {
                decrementation = 0.125F;
            }
        }
    }
}