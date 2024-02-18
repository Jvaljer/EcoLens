using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour {
    public void OnTriggerEnter(Collider other){
        //here we wanna delete the object if it is dropped only
        if(other.tag == "Object"){
            other.transform.GetComponent<Object>().OnTrash();
        }
    }
    public void OnTriggerExit(Collider other){
        //here we wanna delete the object if it is dropped only
        if(other.tag == "Object"){
            other.transform.GetComponent<Object>().OffTrash();
        }
    }
}
