using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour {
    public DashBoard dashboard;
    
    private bool placed = false;
    private bool in_capsule = true;
    private GameObject holder;
    public string obj_type;

    void Update(){
        if(placed){
            gameObject.transform.position = holder.transform.position;
        }
    }

    public void Pick(){
        //here we wanna display the related informations of the picked object
        dashboard.DisplayInformations(obj_type);
    }
    public void Drop(){
        //must implement
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
