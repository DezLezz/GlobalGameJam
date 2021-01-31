using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markerSummon : MonoBehaviour
{
    // Update is called once per frame

    public Transform prefab;
    public Transform parent3D;
    public Transform parent2D;
    public GameObject firstPP;
    public GameObject mapP;
    
    public float cooldownTime = 0.5f;

    private float nextFireTime = 0;
    
    void Update()
    {
        
        
        if (Time.time > nextFireTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                
                var xf = firstPP.GetComponent<CharacterController>().transform.position.x;
                var yf = firstPP.GetComponent<CharacterController>().transform.position.y;
                var zf = firstPP.GetComponent<CharacterController>().transform.position.z;
                var xm = mapP.GetComponent<CharacterController>().transform.position.x;
                var ym = mapP.GetComponent<CharacterController>().transform.position.y;
                var zm = mapP.GetComponent<CharacterController>().transform.position.z;

                int l = mapP.GetComponent<PlayerMovement2D>().currentColor;

                var inst1 = Instantiate(prefab, new Vector3(xf, yf - 1.3f, zf), Quaternion.identity, parent3D);
                var inst2 = Instantiate(prefab, new Vector3(xm, ym - 1.3f, zm), Quaternion.identity, parent2D);


                inst2.gameObject.layer = l;




                nextFireTime = Time.time + cooldownTime;
            }
        }
        
        
    }
}
