using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleWall : MonoBehaviour{

    //yet the system is a bit dumb, if you don't put the object fully outside or inside, then it's gonnq bug out
    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Object"){
            other.gameObject.transform.GetComponent<Object>().TakeOut();
        }
    }
    public void OnTriggerExit(Collider other){
        if(other.gameObject.tag=="Object"){
            other.gameObject.transform.GetComponent<Object>().BringIn();
        }
    }
}
