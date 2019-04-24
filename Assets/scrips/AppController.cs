using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    public Animator anim;
    public bool b;
    public GameObject[] menus;
    [SerializeField]
    private ObjectController objController;

    public void DeletedModel()
    {
        objController.currentModel.transform.gameObject.SetActive(false);
    }

    public void SwipeDown()
    {
        Debug.Log(b);
        if (!b)
        {
            b = true;
            anim.SetBool("UpOrDown", true);

            
        }
        else {
            b = false;
            anim.SetBool("UpOrDown", false);
         
        }
    }
        
}
