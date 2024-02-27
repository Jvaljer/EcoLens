using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour {
    public DashBoard dashboard;
    public AudioSource trash_sound;

    public void OnTriggerEnter(Collider other){
        //here we wanna delete the object
        if(other.tag == "Object"){
            Destroy(other.gameObject);
            trash_sound.Play();
            dashboard.ThrowInBin();
        }
    }
}
