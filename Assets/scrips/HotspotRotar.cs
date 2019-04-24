using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HotspotRotar : MonoBehaviour, IPointerClickHandler {

    MoverRotar mr;



    public void Start()
    {
        mr = GameObject.Find("MoverRotar").GetComponent<MoverRotar>();
    }


    public void OnPointerClick(PointerEventData eventData) 
    {
        OnHotspotTransition();
    }
   

    public void OnHotspotTransition() 
    {
        mr.Rotar();
    }

}
