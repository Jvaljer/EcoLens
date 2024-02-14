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

    public void DisplayInformations(string obj){
        switch (obj){
            case "test-cube":
                info_pane.text = "The object you grabbed is the testing cube";
                break;
            case "test-circle":
                info_pane.transform.GetComponent<TextMesh>().text = "The object you grabbed is a purple sphere";
                break;
            case "test-capsule":
                info_pane.transform.GetComponent<TextMesh>().text = "The object you grabbed is a simple capsule";
                break;
            default:
                info_pane.transform.GetComponent<TextMesh>().text = "Object:["+obj+"] hasn't been implemented yet";
                break;
        }
    }
}
