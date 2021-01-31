using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class markerDestroy : MonoBehaviour
{
    
    // Start is called before the first frame update
   
    // Update is called once per frame
    
   
    

    public void OnTriggerStay(Collider myCollider)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("found");

            if (myCollider.transform.tag != "Marker")
            {
                return;
            }
            else Destroy(myCollider.transform.gameObject);

        }
    }
}
