using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DashBoard : MonoBehaviour {
    public TMP_Text info_pane;

    public GameObject room;
    private GameObject environment;
    public Material btn_M;
    public Material btn_hover_M;

    public Transform slot1;
    public Transform slot2;
    public Transform slot3;

    public GameObject cigaret;
    public GameObject drink;
    public GameObject foodwrapper;
    public GameObject pbottle;
    public GameObject tire;
    public GameObject papertowel;
    public GameObject can;
    public GameObject gbottle;
    public GameObject trashbag;
    private Dictionary<string, int> objects;

    private string current_time = "present";

    public void ButtonHoverEnter(GameObject btn){
        Renderer r = btn.transform.GetComponent<Renderer>();
        if(r != null){
            r.material = btn_hover_M;
        }
    }
    public void ButtonHoverExit(GameObject btn){
        Renderer r = btn.transform.GetComponent<Renderer>();
        if(r != null){
            r.material = btn_M;
        }
    }

    public void TravelToPast(){
        if(current_time == "past")
            return;
        
        Debug.Log("Travelling to PAST");
        current_time = "past";
    }
    public void TravelToPresent(){
        if(current_time == "present")
            return;
        Debug.Log("Travelling to PRESENT");
        current_time = "past";
    }
    public void TravelToFuture(){
        if(current_time == "future")
            return;
        Debug.Log("Travelling to FUTURE");
        current_time = "past";
    }

    public void SetEnvironment(GameObject env){
        environment = env;
    }

    public void PlaceObjects(GameObject o1, GameObject o2, GameObject o3){
        o1.transform.position = slot1.position;
        o2.transform.position = slot2.position;
        o3.transform.position = slot3.position;
    }
    public void AddObjects(string o1, string o2, string o3){
        objects = new Dictionary<string, int>();
        objects.Add(o1, 1);
        objects.Add(o2, 1);
        objects.Add(o3, 1);
    }

    public void DisplayInformations(string obj){
        switch (obj){
            case "test-cube":
                info_pane.text = "The object you grabbed is the testing cube";
                break;
            default:
                info_pane.text = "Object:["+obj+"] hasn't been implemented yet";
                break;
        }
    }
    public void SpawnObject(string obj){
        Debug.Log("SPAAAAWN");
        //here we might wanna bound the amount of spawned objects (present in the same time in the scene)
        if(objects[obj]>=10){
            //here we wanna display a message saying that no more object of this type will be created while existing in scene
            return;
        }
        GameObject new_obj;
        switch (obj){
            //forest object case
            case "plastic-bottle":
                new_obj = Instantiate(pbottle, slot1.position, slot1.rotation);
                break;
            case "tire":
                new_obj = Instantiate(tire, slot2.position, slot2.rotation);
                break;
            case "paper-towel":
                new_obj = Instantiate(papertowel, slot3.position, slot3.rotation);
                break;

            //mountain object case
            case "cigaret":
                new_obj = Instantiate(cigaret, slot1.position, slot1.rotation);
                break;
            case "drink":
                new_obj = Instantiate(drink, slot3.position, slot3.rotation);
                break;
            case "food-wrapper":
                new_obj = Instantiate(foodwrapper, slot2.position, slot2.rotation);
                break;
            
            //sea object case
            case "can":
                new_obj = Instantiate(can, slot1.position, slot1.rotation);
                break;
            case "glass-bottle":
                new_obj = Instantiate(gbottle, slot2.position, slot2.rotation);
                break;
            case "plastic-bag":
                new_obj = Instantiate(trashbag, slot3.position, slot3.rotation);
                break;
            
            default:
                new_obj = null;
                break;
        }
        if(new_obj!=null){
            objects[obj]++;
            new_obj.transform.GetComponent<Object>().Initiate(this);
        }
    }
}
