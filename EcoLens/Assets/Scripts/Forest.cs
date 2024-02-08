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

    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;

    void Start(){
        Debug.Log("Forest.cs Starts");
    }

    public void Load(){
        capsule.SetActive(true);
        capsule.transform.position = gameObject.transform.position;
        capsule.transform.rotation = gameObject.transform.rotation;

        player.transform.position = spawn.position;

        dashboard_script.PlaceObjects(obj1, obj2, obj3);
    }
}
