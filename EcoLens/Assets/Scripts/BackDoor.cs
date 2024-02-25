using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDoor : MonoBehaviour {
    //Door Components
    public GameObject body;
    public GameObject low_j;
    public GameObject high_j;
    public GameObject knob_base;
    public GameObject knob_handle;
    public GameObject knob_stick;

    //Materials
    public Material highlight_M;
    public Material base_M;

    //Game Components
    public GameObject hub;
    public GameObject floor;
    public GameObject capsule;
    private GameObject environment;
    public Transform hub_spawn;
    public GameObject player;
    public DoorDetectors navigation;
    

    void Start(){
        //shall load current environment !!!
        //must implement
    }

    public void GoBackHub(){
        Debug.Log("Going Back Hub");
        hub.SetActive(true);
        floor.SetActive(true);
        environment.SetActive(false);
        navigation.ExitRoom();
        capsule.SetActive(false);

        player.transform.position = hub_spawn.position;
    }

    public void HoverIn(){
        Renderer r1 = body.transform.GetComponent<Renderer>(); 
        Renderer r2 = low_j.transform.GetComponent<Renderer>(); 
        Renderer r3 = high_j.transform.GetComponent<Renderer>(); 
        Renderer r4 = knob_base.transform.GetComponent<Renderer>(); 
        Renderer r5 = knob_handle.transform.GetComponent<Renderer>(); 
        Renderer r6 = knob_stick.transform.GetComponent<Renderer>(); 

        if(r1 !=null){
            r1.material = highlight_M;
        }
        if(r2 !=null){
            r2.material = highlight_M;
        }
        if(r3 !=null){
            r3.material = highlight_M;
        }
        if(r4 !=null){
            r4.material = highlight_M;
        }
        if(r5 !=null){
            r5.material = highlight_M;
        }
        if(r6 !=null){
            r6.material = highlight_M;
        }
    }
    public void HoverOut(){
        Renderer r1 = body.transform.GetComponent<Renderer>(); 
        Renderer r2 = low_j.transform.GetComponent<Renderer>(); 
        Renderer r3 = high_j.transform.GetComponent<Renderer>(); 
        Renderer r4 = knob_base.transform.GetComponent<Renderer>(); 
        Renderer r5 = knob_handle.transform.GetComponent<Renderer>(); 
        Renderer r6 = knob_stick.transform.GetComponent<Renderer>(); 

        if(r1 != null){
            r1.material = base_M;
        }
        if(r2 !=null){
            r2.material = base_M;
        }
        if(r3 !=null){
            r3.material = base_M;
        }
        if(r4 !=null){
            r4.material = base_M;
        }
        if(r5 !=null){
            r5.material = base_M;
        }
        if(r6 !=null){
            r6.material = base_M;
        }
    }
}
