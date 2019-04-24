using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mover : MonoBehaviour
{

    private MoverRotar mr;
    private Toggle tog;

    void Start()
    {
        mr = GameObject.Find("MoverRotar").GetComponent<MoverRotar>();
        tog = GetComponent<Toggle>();

    }

    // Update is called once per frame
    void Update()
    {
        if(mr.mover == true)
        {
            tog.isOn = true;
        }
        else
        {
            tog.isOn = false;
        }
    }
}
