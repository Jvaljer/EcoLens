using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBtn : MonoBehaviour {
    public DashBoard dashboard;
    public Material base_M;
    public Material hovered_M;
    private string obj;

    public void OnHoverEnter(){
        Renderer r = GetComponent<Renderer>();
        if(r != null){
            r.material = hovered_M;
        }
    }
    public void OnHoverExit(){
        Renderer r = GetComponent<Renderer>();
        if(r != null){
            r.material = base_M;
        }
    }

    public void Click(){
        dashboard.SpawnObject(obj);
    }

    public void SetObject(string str){
        obj = str;
    }
}
