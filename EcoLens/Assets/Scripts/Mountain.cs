using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : MonoBehaviour {
    public GameObject player;

    public GameObject hub_room;
    public DoorDetectors nav;
    public GameObject capsule;
    public Transform spawn;

    void Start(){
        Debug.Log("Mountain.cs Starts");
        capsule.SetActive(true);
        capsule.transform.GetChild(1).GetComponent<DashBoard>().SetPosition(gameObject.transform.position);
        capsule.transform.GetChild(1).GetComponent<DashBoard>().SetRotation(gameObject.transform.rotation);

        player.transform.position = spawn.position;
    }
}
