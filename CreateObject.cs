using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using TMPro;

public class CreateObject : MonoBehaviour
{
    int Score = 0;
    public TextMeshProUGUI PopUp;
    public float AppearChances;
    public KeyCode key;
    private GameObject hitball;
    private Queue<GameObject> balls = new Queue<GameObject>();
    int Sec = 5;
    string performance;
    // Start is called before the first frame update
    void Start()
    {
        //-- Commence à créer les hitballs
        this.hitball = addBall();
        // StartCoroutine(Coroutine());     Coroutine pour la coroutine par frame
        //StartCoroutine(WaitForSec());     //Coroutine pour afficher le TextMesh
        
    }

    /*IEnumerator Coroutine()
    {
        /*
        while (true)
        {
            yield return new WaitForSeconds(1);
            System.Random r = new System.Random();
            if (r.Next(0, 100) <= AppearChances)
            {
                balls.Enqueue(addBall());
            }
        }
      
    }
    */
   
    // Update is called once per frame
    void Update() 
    {
       
        // Fais apparaître les boules de manières aléatoires. NB : Ne pas mettre le même taux de probabilités.
        System.Random r = new System.Random();

        if (r.Next(0,100) == AppearChances)
        {
            balls.Enqueue(addBall());
        }
       

        if (this.hitball != null)
        {
            NiceHit(hitball);
            AutoDestruction(this.hitball);
        }
        else
        {
            if(balls.Count > 0)
                this.hitball = balls.Dequeue();
        }

        

    }


    // Code permettant de connaître le timing de l'utilisateur ==> Cherche à lui montrer par message si le hit est bon, parfait ou rater.
    void NiceHit(GameObject hitball)
    {
        //PopUp.text = "";
        if (Input.GetKeyDown(key)) {
            if (hitball.transform.position.y <= 150 && hitball.transform.position.y >= 50)
            {
                Destroy(hitball);
                if (hitball.transform.position.y <= 120 && hitball.transform.position.y >= 80)
                {
                    Debug.Log("Perfect Hit!");
                    Score = Score + 3;
                    //PopUp.text = "Perfect !";
                    performance = "Perfect !";
                }
                else
                {
                    Debug.Log("Nice Hit!");
                    Score = Score + 1;
                    //PopUp.text = "Nice !";
                    performance = "Nice !";
                    //réussite
                    PopUp.color = new Color32(71, 254, 51, 255);
                   
                }



            }

            else
            {
                Debug.Log("Miss!");
                //PopUp.text = "Miss !";
                Score = Score - 1;
                performance = "Miss !";
                //échec
                PopUp.color = new Color32(254, 46, 46, 255);
            }
            if (balls.Count > 0)
            {
                
                this.hitball = balls.Dequeue();
            }
       }
        if (hitball.transform.position.y < 50)
        {
            Debug.Log("Miss !");
            Score = Score - 1;
            performance = "Miss !";
            PopUp.color = new Color32(254, 46, 46, 255);
        }
        ShowFloatText(performance);
    }

    //-- Si la hitball descends trop bas, la détruire systématiquement.
    void AutoDestruction(GameObject hitball)
    {
        if (hitball.transform.position.y < -37.5)
        {
            Destroy(hitball);
            this.hitball = null;
           
        }

    }

    // création de la hitball dans son slot avec les mêmes propriétes que les précédentes.
    private GameObject addBall()
    {
        GameObject hitball = Instantiate(GameObject.Find("StartHitBall"));
        hitball.transform.position = new Vector3(transform.position.x, 611.3f, transform.position.z);
        hitball.transform.localScale = new Vector3(40, 40, 1);
        hitball.SetActive(true);
        return hitball;
    }


   void ShowFloatText(string performance)
   {
       //instancer l'objet
       
       PopUp.text = performance;
        PopUp.ForceMeshUpdate();
       
       
   }


   //détruire le texte au bout de quelques secondes s'il n'y a pas un autre hit ou miss avant
   /*IEnumerator WaitForSec()
   {
       
       yield return new WaitForSeconds(3);
       PopUp.text = " ";
   }
   */
   
}

