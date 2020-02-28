using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jauge : MonoBehaviour
{
    private Image jauge;

    private float max;
    public float get_max() { return this.max; }

    public void set_max(float x) { this.max = x; }


    private float valeur;
    public float get_valeur() { return this.valeur; }

    public void set_valeur(float x)
    {
        this.valeur = Mathf.Clamp(x, 0, this.max);

        if (this.jauge != null)
        {
            this.jauge.fillAmount = (1 / this.max) * this.valeur;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.jauge = GetComponent<Image>();
        this.jauge.fillAmount = (1 / this.max) * this.valeur;
    }
}
