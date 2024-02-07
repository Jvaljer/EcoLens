using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour {
    
    private bool placed = false;
    private bool picked = false;
    private GameObject holder;

    void Update(){
        if(placed){
            gameObject.transform.position = holder.transform.position;
        }
    }

    public void Pick(){
        picked = true;
    }
    public void Drop(){
        picked = false;
    }

    public void SetHolder(GameObject go){
        holder = go;
        placed = true;
    }
    public void DismissHolder(){
        holder = null;
        placed = false;
    }
}
