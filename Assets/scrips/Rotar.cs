using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotar : MonoBehaviour
{
    MoverRotar mr;
    Toggle tog;

    
    void Start()
    {
        mr = GameObject.Find("MoverRotar").GetComponent<MoverRotar>();
        tog = GetComponent<Toggle>();
    }

    void Update()
    {
        if (mr.rotar == true)
        {
            tog.isOn = true;
        }
        else
        {
            tog.isOn = false;
        }
    }

}
