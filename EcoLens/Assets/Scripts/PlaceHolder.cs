using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolder : MonoBehaviour {
    public void OnTriggerEnter(Collider other){
        if(other.tag=="Object"){
            other.gameObject.transform.GetComponent<Object>().SetHolder(this.gameObject);
        }
    }
    public void OnTriggerExit(Collider other){
        if(other.tag=="Object"){
            other.gameObject.transform.GetComponent<Object>().DismissHolder();
        }
    }
}
