using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour {
    public DashBoard dashboard;
    
    private bool placed = false;
    private bool dropped = false;
    private bool in_capsule = true;
    private GameObject holder;
    public string obj_type;

    void Update(){
        if(placed){
            gameObject.transform.position = holder.transform.position;
        }
        if(dropped){
            //then we wanna know if it was dropped inside or outside
            //for that we have 2 options
                //adding an "in" collider for the capsule and checking if there is a triggering or not
                //checking for positions
            
        }
    }

    public void Pick(){
        //here we wanna display the related informations of the picked object
        dashboard.DisplayInformations(obj_type);
        dropped = false;
    }
    public void Drop(){
        dashboard.DisplayInformations(obj_type);
        dropped = true;
    }
    public void TakeOut(){
        in_capsule = false;
    }
    public void BringIn(){
        in_capsule = true;
    }

    public void SetHolder(GameObject go){
        holder = go;
        placed = true;
    }
    public void DismissHolder(){
        holder = null;
        placed = false;
    }
}
