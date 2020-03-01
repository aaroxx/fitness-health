using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBall : MonoBehaviour
{
    
      
      bool active = false;
      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {
       float y = transform.position.y;
        float d = 5f;
        y -= d;
        transform.position = new Vector3(transform.position.x, y, transform.position.z) ;
      }

    

}

