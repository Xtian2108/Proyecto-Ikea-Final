using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EzRotate1 : MonoBehaviour, IDragHandler
{

    float rotationSpeed = 2f;


    void OnMouseDrag()
    {
        
    }


    public void OnDrag(PointerEventData eventData)
    {

        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;

        transform.Rotate(Vector3.back, XaxisRotation);

    }
}

