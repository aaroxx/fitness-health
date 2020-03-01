using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CreateObject : MonoBehaviour
{

    public float AppearChances;
    public KeyCode key;
    private GameObject hitball;
    private Queue<GameObject> balls = new Queue<GameObject>();
    int Sec = 5;
    // Start is called before the first frame update
    void Start()
    {
        this.hitball = addBall();
        // StartCoroutine(Coroutine());     Coroutine pour la coroutine par frame
        //StartCoroutine(WaitForSec());     Coroutine pour afficher le TextMesh
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



    void NiceHit(GameObject hitball)
    {
        if (Input.GetKeyDown(key)) {
            if (hitball.transform.position.y <= 150 && hitball.transform.position.y >= 50)
            {
                Destroy(hitball);
                if (hitball.transform.position.y <= 120 && hitball.transform.position.y >= 80)
                {
                    Debug.Log("Perfect Hit!");

                }
                else
                    Debug.Log("Nice Hit!");
                
            }
            
            else Debug.Log("Miss!");
            if (balls.Count >0)
                this.hitball = balls.Dequeue();
       }
    }


    void AutoDestruction(GameObject hitball)
    {
        if (hitball.transform.position.y < -37.5)
        {
            Destroy(hitball);
            this.hitball = null;
        }
       
    }

    private GameObject addBall()
    {
        GameObject hitball = Instantiate(GameObject.Find("StartHitBall"));
        hitball.transform.position = new Vector3(transform.position.x, 611.3f, transform.position.z);
        hitball.transform.localScale = new Vector3(40, 40, 1);
        hitball.SetActive(true);
        return hitball;
    }
    
   
 /*   //être sûr que ça existe

    //afficher le texte
    void ShowFloatText(string performance)
    {
            //instancer l'objet
            GameObject FloatText = Instantiate(FloatText.transform.position(502, 414, 0)); /////////, transform)
        FloatText.GetComponent<TextMesh>().text = performance;
       // StartCoroutine(WaitForSec());
    }


    //détruire le texte au bout de quelques secondes s'il n'y a pas un autre hit ou miss avant
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(3);
        Destroy(FloatText);
        this.FloatText = null;
    }

*/
}

