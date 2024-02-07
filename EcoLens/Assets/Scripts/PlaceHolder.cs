using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolder : MonoBehaviour {
    public void OnTriggerEnter(Collider other){
        Debug.Log("Entering");
    }
    public void OnTriggerExit(Collider other){
        Debug.Log("Exiting");
    }
}
