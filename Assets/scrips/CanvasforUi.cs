using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasforUi : MonoBehaviour
{
    ObjectController obj;
    // encima del current model

    public Transform location;
    public  Vector3 actloc;
    public GameObject canvassss;
    public bool activa;
    

    void Start()
    {
       
        obj = GameObject.Find("ObjectController").GetComponent<ObjectController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (obj.currentModel != null) {

            canvassss.SetActive(true);
            actloc = new Vector3(obj.currentModel.transform.position.x, obj.currentModel.transform.position.y+1.0f, obj.currentModel.transform.position.z+1.2f);
            Debug.Log("nope");
        }
        else
        {
            canvassss.SetActive(false);
            Debug.Log("yep");
         
        }
        canvassss.transform.position = actloc;
    }


   
}
