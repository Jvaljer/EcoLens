using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sea : MonoBehaviour {
    public GameObject player;

    public GameObject hub_room;
    public DoorDetectors nav;

    public GameObject capsule;
    public DashBoard dashboard_script;
    public Transform spawn;
    public BackDoor back_door;

    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;

    public GameObject past;
    public GameObject present;
    public GameObject future;

    public Material underwaterSkybox;
    private string cur_env = "";

    void Start(){
        Debug.Log("Sea.cs Starts");
    }

    public void Init(){
        capsule.SetActive(true);
        capsule.transform.position = new Vector3(-44,7.25f,-52);
        capsule.transform.rotation = Quaternion.Euler(0,120,0);

        player.transform.position = spawn.position;
        player.transform.rotation = Quaternion.Euler(0,120,0);

        dashboard_script.SetEnvironment(this.gameObject);
        ActiveObjects();
        dashboard_script.AddObjects(obj1.transform.GetComponent<Object>().obj_type, obj2.transform.GetComponent<Object>().obj_type, obj3.transform.GetComponent<Object>().obj_type);

        //Added
        // Enable fog
        RenderSettings.skybox=underwaterSkybox;
        RenderSettings.fog = true;
        RenderSettings.fogMode = FogMode.Linear;
        RenderSettings.fogColor = new Color32(154,186, 214, 255);
        /*
        string colorcode = "#9ABAD6";
        int argb = Int32.Parse(colorcode.Replace("#", ""), NumberStyles.HexNumber);
        Color clr = Color.FromArgb(argb);
        RenderSettings.fogColor = clr;
        */
    }

    public void Load(string time){
        Debug.Log("Sea travelling to "+time);
        switch(time){
            case "past":
                LoadPast();
                break;
            case "present":
                LoadPresent();
                break;
            case "future":
                LoadFuture();
                break;
            default:
                break;
        }
    }

    public void LoadPast(){
        Unload();
        past.SetActive(true);
        dashboard_script.SetObjects(obj1, obj2, obj3);
        cur_env = "past";
        back_door.SetEnvironment("Sea", past);
    }
    public void LoadPresent(){
        Unload();
        present.SetActive(true);
        dashboard_script.SetObjects(obj1, obj2, obj3);
        cur_env = "present";
        back_door.SetEnvironment("Sea", present);
    }
    public void LoadFuture(){
        Unload();
        future.SetActive(true);
        dashboard_script.SetObjects(obj1, obj2, obj3);
        cur_env = "future";
        back_door.SetEnvironment("Sea", future);
    }

    public void Unload(){
        switch (cur_env){
            case "past":
                past.SetActive(false);
                break;
            case "present":
                present.SetActive(false);
                break;
            case "future":
                future.SetActive(false);
                break;
        }
    }

    private void ActiveObjects(){
        if(obj1!=null){
            obj1.SetActive(true);
        } else {
            obj1 = dashboard_script.SpawnSetObject("can");
        }
        if(obj2!=null){
            obj2.SetActive(true);
        } else {
            obj2 = dashboard_script.SpawnSetObject("plastic-bottle");
        }
        if(obj3!=null){
            obj3.SetActive(true);
        } else {
            obj3 = dashboard_script.SpawnSetObject("plastic-bag");
        }
    }
    public void DisableObjects(){
        if(obj1!=null)
            obj1.SetActive(false);
        if(obj2!=null)
            obj2.SetActive(false);
        if(obj3!=null)
            obj3.SetActive(false);
    }
}
