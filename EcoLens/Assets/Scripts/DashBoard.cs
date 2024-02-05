using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBoard : MonoBehaviour {
    public GameObject room;
    private GameObject environment;
    public Material btn_M;
    public Material btn_hover_M;

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
    public void SetPosition(Vector3 pos){
        gameObject.transform.position = pos;
    }
    public void SetRotation(Quaternion rota){
        gameObject.transform.rotation = rota;
    }
}
