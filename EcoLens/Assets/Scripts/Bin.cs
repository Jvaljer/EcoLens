using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour {
    public DashBoard dashboard;

    public void OnTriggerEnter(Collider other){
        //here we wanna delete the object
        if(other.tag == "Object"){
            Destroy(other.gameObject);
            dashboard.ThrowInBin();
        }
    }
}
