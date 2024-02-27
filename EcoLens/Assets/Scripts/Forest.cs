using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : MonoBehaviour {
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
    private string cur_env = "";

    void Start(){
        Debug.Log("Forest.cs Starts");
    }

    public void Init(){
        capsule.SetActive(true);
        capsule.transform.position = new Vector3(-11,5,-160);
        capsule.transform.rotation = Quaternion.Euler(0,-65,0);

        player.transform.position = spawn.position;
        player.transform.rotation = capsule.transform.rotation;

        dashboard_script.SetEnvironment(this.gameObject);
        ActiveObjects();
        dashboard_script.AddObjects(obj1.transform.GetComponent<Object>().obj_type, obj2.transform.GetComponent<Object>().obj_type, obj3.transform.GetComponent<Object>().obj_type);
    }

    public void Load(string time){
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
        back_door.SetEnvironment("Forest", past);
    }
    public void LoadPresent(){
        Unload();
        present.SetActive(true);
        dashboard_script.SetObjects(obj1, obj2, obj3);
        cur_env = "present";
        back_door.SetEnvironment("Forest", present);
    }
    public void LoadFuture(){
        Unload();
        future.SetActive(true);
        dashboard_script.SetObjects(obj1, obj2, obj3);
        cur_env = "future";
        back_door.SetEnvironment("Forest", future);
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
            obj1 = dashboard_script.SpawnSetObject("plastic-bottle");
        }
        if(obj2!=null){
            obj2.SetActive(true);
        } else {
            obj2 = dashboard_script.SpawnSetObject("tire");
        }
        if(obj3!=null){
            obj3.SetActive(true);
        } else {
            obj3 = dashboard_script.SpawnSetObject("paper-towel");
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
