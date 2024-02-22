using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InNOut : MonoBehaviour {
    public void OnTriggerExit(Collider other){
        if(other.tag=="Object"){
            other.gameObject.transform.GetComponent<Object>().in_capsule = false;
        }
    }
    public void OnTriggerEnter(Collider other){
        if(other.tag=="Object"){
            other.gameObject.transform.GetComponent<Object>().in_capsule = true;
        }
    }
}
