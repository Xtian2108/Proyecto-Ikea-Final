using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EzRotate : MonoBehaviour, IDragHandler
{

    float rotationSpeed = 2f;

    public MoverRotar paraUI;
    public BoxCollider box;

    public void Start()
    {
        paraUI = GameObject.Find("MoverRotar").GetComponent<MoverRotar>();
        box = GetComponent<BoxCollider>();
    }


    void OnMouseDrag()
    {
        
    }


    public void OnDrag(PointerEventData eventData)
    {
        if(paraUI.rotar == true)
        {
            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
            // select the axis by which you want to rotate the GameObject
            transform.Rotate(Vector3.down, XaxisRotation);
        }

    }
}

