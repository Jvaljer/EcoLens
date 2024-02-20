using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DashBoard : MonoBehaviour {
    public TMP_Text info_pane;
    public TMP_Text bin_pane;
    public TMP_Text out_pane;

    public GameObject room;
    private GameObject environment;

    public Material btn_M;
    public Material btn_click_M;
    public Material btn_hover_M;

    public GameObject past_btn;
    public GameObject present_btn;
    public GameObject future_btn;

    public Transform slot1;
    public Transform slot2;
    public Transform slot3;
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;

    public GameObject cigaret;
    public GameObject drink;
    public GameObject foodwrapper;
    public GameObject pbottle;
    public GameObject tire;
    public GameObject papertowel;
    public GameObject can;
    public GameObject gbottle;
    public GameObject trashbag;

    private int out_cpt = 0;
    private int bin_cpt = 0;

    private bool win = false;
    private bool loose = false;

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
    public void ButtonClick(GameObject btn){
        Renderer r = btn.transform.GetComponent<Renderer>();
        if(r != null){
            r.material = btn_click_M;
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

        o1.transform.GetComponent<Object>().Initiate(this, room.transform);
        o2.transform.GetComponent<Object>().Initiate(this, room.transform);
        o3.transform.GetComponent<Object>().Initiate(this, room.transform);

        btn1.transform.GetComponent<SpawnBtn>().SetObject(o1.transform.GetComponent<Object>().obj_type);
        btn2.transform.GetComponent<SpawnBtn>().SetObject(o2.transform.GetComponent<Object>().obj_type);
        btn3.transform.GetComponent<SpawnBtn>().SetObject(o3.transform.GetComponent<Object>().obj_type);

        out_cpt = 0;
        out_pane.text = "Objects Out -> "+out_cpt+"/10";
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
    private void DisplayLoose(){
        //must implement
    }
    private void DisplayWin(){
        //must implement
    }

    public void ThrowInBin(){
        bin_cpt++;
        if(bin_cpt==10 && !loose){
            TravelToPast();
            DisplayWin();
            win = true;
        }
        bin_pane.text = bin_cpt+"/10";
    }

    public void SpawnObject(string obj_str){
        GameObject go;
        switch (obj_str){
            //mountain objects
            case "cigaret":
                go = Instantiate(cigaret, slot1.position, slot1.rotation);
                break;
            case "drink":
                go = Instantiate(drink, slot3.position, slot3.rotation);
                break;
            case "food-wrapper":
                go = Instantiate(foodwrapper, slot2.position, slot2.rotation);
                break;
            
            //forest objects
            case "plastic-bottle":
                go = Instantiate(pbottle, slot1.position, slot1.rotation);
                break;
            case "tire":
                go = Instantiate(tire, slot2.position, slot2.rotation);
                break;
            case "paper-towel":
                go = Instantiate(papertowel, slot3.position, slot3.rotation);
                break;
            
            //sea objects
            case "can":
                go = Instantiate(can, slot1.position, slot1.rotation);
                break;
            case "glass-bottle":
                go = Instantiate(gbottle, slot2.position, slot2.rotation);
                break;
            case "plastic-bag":
                go = Instantiate(trashbag, slot3.position, slot3.rotation);
                break;
            
            default:
                Debug.Log("default case");
                go = null;
                break;
        }
        if(go!=null){
            go.transform.GetComponent<Object>().Initiate(this, room.transform);
            objects[obj_str]++;
        }
    }

    public void DestroyObject(string obj_type){
        objects[obj_type]--;
    }

    public void ObjectOut(){
        out_cpt++;
        if(out_cpt==10 && !win){
            TravelToFuture();
            DisplayWin();
            loose = true;
        }
        out_pane.text = "Objects Out -> "+out_cpt+"/10";
    }
    public void ObjectIn(){
        out_cpt--;
        out_pane.text = "Objects Out -> "+out_cpt+"/10";
    }
}
