using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorDetectors : MonoBehaviour {
    public Material door_M;
    public Material available_M;
    public GameObject forest_door;
    public GameObject sea_door;
    public GameObject mountain_door;

    private bool forest = false;
    private bool seaside = false;
    private bool mountain = false;

    public TextMesh anchor_txt;

    void Start(){
        Debug.Log("DoorDetectors.cs Start");
    }

    public void EnableForest(){
        forest = true;
        anchor_txt.text = "Forest";
    }
    public void DisableForest(){
        forest = false;
        anchor_txt.text = "None";
    }

    public void EnableSea(){
        seaside = true;
        anchor_txt.text = "Sea";
    }
    public void DisableSea(){
        seaside = false;
        anchor_txt.text = "None";
    }

    public void EnableMountain(){
        mountain = true;
        anchor_txt.text = "Mountain";
    }
    public void HoverInMountain(){
        if(!mountain){
            return;
        }
        Renderer renderer = mountain_door.transform.GetChild(0).GetComponent<Renderer>(); 
        if(renderer !=null){
            renderer.material = available_M;
        }
    }
    public void HoverOutMountain(){
        if(!mountain){
            return;
        }
        Renderer renderer = mountain_door.transform.GetChild(0).GetComponent<Renderer>(); 
        if(renderer !=null){
            renderer.material = door_M;
        }
    }
    public void DisableMountain(){
        mountain = false;
        anchor_txt.text = "None";
    }
}
