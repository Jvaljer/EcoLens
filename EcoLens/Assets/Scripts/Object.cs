using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour {
    public DashBoard dashboard;
    public Transform capsule;
    
    private bool dropped = false;
    public bool in_capsule = true;
    private bool init = false;
    private bool counted_out = false;
    public string obj_type;

    void Update(){
        if(!init) return;
        if(dropped){
            //then we wanna know if it was dropped inside or outside
            //for that we have 2 options
                //adding an "in" collider for the capsule and checking if there is a triggering or not
                //checking for positions
            if(!in_capsule){
                if(!counted_out){
                    dashboard.ObjectOut(obj_type);
                    dashboard.PlaceInfo(this.transform.position);
                    counted_out = true;
                }
            } else {
                if(counted_out){
                    dashboard.ObjectIn();
                    counted_out = false;
                }
            }
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

    public void Initiate(DashBoard script, Transform boundaries){
        dashboard = script;
        capsule = boundaries;
        init = true;
    }

    private void OnDestroy(){
        if(counted_out){
            dashboard.ObjectIn();
        }
    }
}
