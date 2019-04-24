using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones : MonoBehaviour
{
    public AppController appcontroller;
  
    public void DesactivarMenus(GameObject go )
    {
        for (int i = 0; i < appcontroller.menus.Length; i++)
        {
            appcontroller.menus[i].SetActive(false);
            go.SetActive(true);
            Debug.Log("das");
        }
    }
   
}
