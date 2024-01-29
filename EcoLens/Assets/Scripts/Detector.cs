using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {
    public DoorDetectors handler;
    public string door_id; //SEA, FOREST, MOUNTAIN

    public void OnTriggerEnter(Collider other){
        switch(door_id){
            case "SEA":
                handler.EnableSea();
                break;
            case "FOREST":
                handler.EnableForest();
                break;
            case "MOUNTAIN":
                handler.EnableMountain();
                break;
            default:
                break;
        }
    }
    public void OnTriggerExit(Collider other){
        switch(door_id){
            case "SEA":
                handler.DisableSea();
                break;
            case "FOREST":
                handler.DisableForest();
                break;
            case "MOUNTAIN":
                handler.DisableMountain();
                break;
            default:
                break;
        }
    }
}
