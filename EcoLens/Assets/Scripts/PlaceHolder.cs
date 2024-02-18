using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolder : MonoBehaviour {
    public void OnTriggerEnter(Collider other){
        if(other.tag=="Object"){
            Debug.Log("Object In of Holder");
            other.gameObject.transform.GetComponent<Object>().OnHolder();
        }
    }
    public void OnTriggerExit(Collider other){
        if(other.tag=="Object"){
            Debug.Log("Object Out of Holder");
            other.gameObject.transform.GetComponent<Object>().OffHolder();
        }
    }
}
