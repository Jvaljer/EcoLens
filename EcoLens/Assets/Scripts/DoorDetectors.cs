using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorDetectors : MonoBehaviour {
    public GameObject player;

    public Material door_M;
    public Material available_M;

    public GameObject forest_door;
    public GameObject sea_door;
    public GameObject mountain_door;

    public AudioSource door_hover_sound;

    public GameObject forest_env;
    public GameObject mountain_env;
    public GameObject sea_env;

    public GameObject hub_room;
    public GameObject floor;

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
    public void HoverInForest(){
        if(!forest){
            return;
        }
        door_hover_sound.Play();
        Renderer renderer = forest_door.transform.GetChild(0).GetComponent<Renderer>(); 
        if(renderer !=null){
            renderer.material = available_M;
        }
    }
    public void HoverOutForest(){
        if(!forest){
            return;
        }
        Renderer renderer = forest_door.transform.GetChild(0).GetComponent<Renderer>(); 
        if(renderer !=null){
            renderer.material = door_M;
        }
    }
    public void DisableForest(){
        forest = false;
        anchor_txt.text = "None";
    }

    public void EnableSea(){
        seaside = true;
        anchor_txt.text = "Sea";
    }
    public void HoverInSea(){
        if(!seaside){
            return;
        }
        door_hover_sound.Play();
        Renderer renderer = sea_door.transform.GetChild(0).GetComponent<Renderer>(); 
        if(renderer !=null){
            renderer.material = available_M;
        }
    }
    public void HoverOutSea(){
        if(!seaside){
            return;
        }
        Renderer renderer = sea_door.transform.GetChild(0).GetComponent<Renderer>(); 
        if(renderer !=null){
            renderer.material = door_M;
        }
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
        door_hover_sound.Play();
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

    public void EnterForest(){
        Debug.Log("Player trying to enter in FOREST");
        if(!forest){
            return;
        }
        forest_env.transform.GetComponent<Forest>().Init();
        forest_env.transform.GetComponent<Forest>().LoadPresent();
        hub_room.SetActive(false);
        floor.SetActive(false);
    }
    public void EnterMountain(){
        Debug.Log("Player trying to enter in MOUNTAIN");
        if(!mountain){
            Debug.Log("ERR -> return");
            return;
        }
        //here we wanna activate the related environment
        mountain_env.transform.GetComponent<Mountain>().Init();
        mountain_env.transform.GetComponent<Mountain>().LoadPresent();
        //disable the possibility to teleport
            //just don't attach any teleport script to env scripts
        //make the hub disappear
        hub_room.SetActive(false);
        floor.SetActive(false);
        //give hand to another script (the one attached to the loaded environment)
            //handled by deactivating this script & putting "Start" method in mountain script
    }
    public void EnterSea(){
        Debug.Log("Player trying to enter in SEA");
        if(!seaside){
            return;
        }
        sea_env.transform.GetComponent<Sea>().Init();
        sea_env.transform.GetComponent<Sea>().LoadPresent();
        hub_room.SetActive(false);
        floor.SetActive(false);
    }

    public void ExitRoom(){
        seaside = false;
        forest = false;
        mountain = false;
    }
}
