using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour {
    public DashBoard dashboard;
    public Transform capsule;
    
    private bool placed = false;
    private bool dropped = false;
    private bool in_capsule = true;
    private bool held = true;
    private bool spawned = false;
    private bool trash = false;
    public string obj_type;

    void Update(){
        if(dropped){
            if(trash){
                Destroy(gameObject);
                dashboard.ThrowInBin(obj_type);
            }
            if(!held){
                Debug.Log("We wanna spawn a new one !");
                //here we wanna spawn a new object of same type in the holder (correlated spawn point)
                if(!spawned){
                    dashboard.SpawnObject(obj_type);
                    spawned = true;
                }
            }
            //then we wanna know if it was dropped inside or outside
            //for that we have 2 options
                //adding an "in" collider for the capsule and checking if there is a triggering or not
                //checking for positions
            float x_dist = gameObject.transform.position.x - capsule.position.x;
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

    public void OnHolder(){
        held = true;
    }

    public void OffHolder(){
        held = false;
    }

    public void OnTrash(){
        trash = true;
    }
    public void OffTrash(){
        trash = false;
    }

    public void Initiate(DashBoard script){
        dashboard = script;
    }
}
