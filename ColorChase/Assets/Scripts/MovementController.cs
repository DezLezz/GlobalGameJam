using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public GameObject firstPersonPlayer;
    public GameObject mapPlayer;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonPlayer.GetComponent<PlayerMovement>().enabled = true;
        mapPlayer.GetComponent<PlayerMovement2D>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.R) ||Input.GetKeyDown(KeyCode.Space))  && (firstPersonPlayer.GetComponent<PlayerMovement>().enabled || mapPlayer.GetComponent<PlayerMovement2D>().enabled))
        {
            int heightDifference = mapPlayer.GetComponent<PlayerMovement2D>().getGroundLevel();
            if (firstPersonPlayer.GetComponent<PlayerMovement>().enabled)
            {
                
                mapPlayer.transform.position =  new Vector3(
                    firstPersonPlayer.transform.position.x-200, firstPersonPlayer.transform.position.y-heightDifference, firstPersonPlayer.transform.position.z);
            }
            else if (mapPlayer.GetComponent<PlayerMovement2D>().enabled)
            {
                
                firstPersonPlayer.transform.position =  new Vector3(
                    mapPlayer.transform.position.x-200, mapPlayer.transform.position.y-heightDifference, mapPlayer.transform.position.z);
            }
                
            
            firstPersonPlayer.GetComponent<PlayerMovement>().enabled = !firstPersonPlayer.GetComponent<PlayerMovement>().enabled;
            mapPlayer.GetComponent<PlayerMovement2D>().enabled = !mapPlayer.GetComponent<PlayerMovement2D>().enabled;

            

        }
    }
}
