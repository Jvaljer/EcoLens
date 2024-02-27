using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DashBoard : MonoBehaviour {
    public TMP_Text info_pane;
    public TMP_Text bin_pane;
    public TMP_Text out_pane;
    public TMP_Text outinfo_pane;
    public TMP_Text indicator;

    public GameObject room;
    private GameObject environment;
    public GameObject info_screen;

    private Forest env_f;
    private Mountain env_m;
    private Sea env_s;
    private string cur_env = "";

    public Material btn_M;
    public Material btn_click_M;
    public Material btn_hover_M;

    public GameObject past_btn;
    public GameObject present_btn;
    public GameObject future_btn;
    public GameObject player_cam;
    public GameObject bin_screen;

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
    private bool end = false;
    private bool set_info = false;

    private Dictionary<string, int> objects;

    private string current_time = "present";

    public AudioSource spawn_sound;
    public AudioSource travel_sound;
    public AudioSource hover_sound;
    public AudioSource out_sound;
    public AudioSource click_sound;
    public AudioSource win_sound;
    public AudioSource loose_sound;

    public void ButtonHoverEnter(GameObject btn){
        hover_sound.Play();
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
        click_sound.Play();
        Renderer r = btn.transform.GetComponent<Renderer>();
        if(r != null){
            r.material = btn_click_M;
        }
    }

    public void TravelToPast(){
        if(current_time == "past" || end)
            return;
        current_time = "past";
        indicator.text = "Currently in PAST";
        TimeTravel();
    }
    public void TravelToPresent(){
        if(current_time == "present" || end)
            return;
        current_time = "present";
        indicator.text = "Currently in PRESENT";
        TimeTravel();
    }
    public void TravelToFuture(){
        if(current_time == "future" || end)
            return;
        indicator.text = "Currently in FUTURE";
        current_time = "future";
        TimeTravel();
    }

    private void TimeTravel(){
        travel_sound.Play();
        switch (cur_env){
            case "forest":
                env_f.Load(current_time);
                break;
            case "mountain":
                env_m.Load(current_time);
                break;
            case "sea":
                //env_s.Load(current_time);
                break;
            default:
                break;
        }
    }

    public void SetEnvironment(GameObject env){
        environment = env;
        switch (environment.tag){
            case "Forest":
                env_f = environment.transform.GetComponent<Forest>();
                cur_env = "forest";
                break;
            case "Mountain":
                env_m = environment.transform.GetComponent<Mountain>();
                cur_env = "mountain";
                break;
            case "Sea":
                env_s = environment.transform.GetComponent<Sea>();
                cur_env = "sea";
                break;
            default:
                break;
        }
    }

    public void SetObjects(GameObject o1, GameObject o2, GameObject o3){
        o1.transform.position = slot1.position;
        o2.transform.position = slot2.position;
        o3.transform.position = slot3.position;

        o1.transform.GetComponent<Object>().Initiate(this, room.transform, 0);
        o2.transform.GetComponent<Object>().Initiate(this, room.transform, 0);
        o3.transform.GetComponent<Object>().Initiate(this, room.transform, 0);

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
            
            // Mountain objects
            case "cigaret":
                info_pane.text = "Cigarettes are commonly found littered in mountain areas, posing a threat to wildlife and ecosystems.";
                break;
            case "drink":
                info_pane.text = "You've found a discarded beverage container, commonly left behind in mountainous regions.";
                break;
            case "food-wrapper":
                info_pane.text = "This food wrapper is likely from hikers or campers, unfortunately left behind in nature.";
                break;
            
            // Forest objects
            case "plastic-bottle":
                info_pane.text = "Plastic bottles are often discarded in forests, contributing to pollution and harming forest inhabitants due to their plastic materials.";
                break;
            case "tire":
                info_pane.text = "Tires -as any engine parts- dumped in forests pose a significant environmental hazard, contaminating soil and water.";
                break;
            case "paper-towel":
                info_pane.text = "Paper towels littered in forests can take a long time to decompose, impacting the natural environment.";
                break;
            
            // Sea objects
            case "can":
                info_pane.text = "Cans are commonly found in coastal areas, washed ashore by tides, posing a threat to marine life.";
                break;
            case "glass-bottle":
                info_pane.text = "Glass bottles discarded in the sea can break into dangerous shards and harm marine creatures.";
                break;
            case "plastic-bag":
                info_pane.text = "Plastic bags are a major source of marine pollution, endangering ocean ecosystems and wildlife.";
                break;
            
            default:
                info_pane.text = "Object:["+obj+"] hasn't been implemented yet";
                break;
        }
    }

    public void DisplayThrewInfo(string obj){
        switch (obj){
            // Mountain objects
            case "cigaret":
                outinfo_pane.text = "* 500 liters of water contaminated,\n* 10+ years to decompose,\n* contains toxic plastic materials & chemicals.";
                break;
            case "drink":
                outinfo_pane.text = "* 9% of plastic pollution,\n* Contaminate fauna and flora\n";
                break;
            case "food-wrapper":
                outinfo_pane.text = "* 9% of plastic pollution,\n* Animals eat it and get sick\n* 10 to 100 years to decompose";
                break;
            
            // Forest objects
            case "plastic-bottle":
                outinfo_pane.text = "* 12% of plastic pollution,\n* Isn't biodegradable,\n* 1000 years to decompose";
                break;
            case "tire":
                outinfo_pane.text = "* Polluting the soils due to their compositon,\n* 577'200 tons of tires in 2022\n";
                break;
            case "paper-towel":
                outinfo_pane.text = "* 3+ months to decompose,\n";
                break;
            
            // Sea objects
            case "can":
                outinfo_pane.text = "* 77 cans per human each year\n* 200 years to decompose,\n* Alluminum pollution of oceans and soils";
                break;
            case "glass-bottle":
                outinfo_pane.text = "* 4000 years to decompose,\n";
                break;
            case "plastic-bag":
                outinfo_pane.text = "* 14% of plastic pollution,\n* 400 years to decompose";
                break;
            
            default:
                outinfo_pane.text = "~Not Informed~";
                break;
        }
    }
    private void DisplayLoose(){
        //here we wanna display an explanatory message on the front wall
    }
    private void DisplayWin(){
        //here we wanna display an explanatory message on the front wall
    }
    private void End(){
        //here we wanna set the counters OFF
        bin_screen.SetActive(false);
        out_pane.gameObject.SetActive(false);

        //display quick message
        if(win){
            win_sound.Play();
            indicator.text = "Well Done !!!";
        }
        if(loose){
            loose_sound.Play();
            indicator.text = "Too Bad...";
        }

        //also disable the objects
        switch (cur_env){
            case "forest":
                env_f.DisableObjects();
                break;
            case "mountain":
                env_m.DisableObjects();
                break;
            case "sea":
                //env_s.DisableObjects();
                break;
        }
        btn1.SetActive(false);
        btn2.SetActive(false);
        btn3.SetActive(false);
    }
    public void Launch(){
        if(!end)
            return;
        
        end = false;
        bin_screen.SetActive(true);
        out_pane.gameObject.SetActive(true);
    }

    public void ThrowInBin(){
        bin_cpt++;
        if(bin_cpt==5 && !loose){
            TravelToPast();
            DisplayWin();
            win = true;
            end = true;
            End();
        }
        bin_pane.text = bin_cpt+"/5";
    }

    public void SpawnObject(string obj_str){
        spawn_sound.Play();
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
                go = null;
                break;
        }
        if(go!=null){
            Debug.Log("SPAWNED A NOT NULL OBJECT");
            go.tag = "Object";
            go.transform.GetComponent<Object>().Initiate(this, room.transform, 1);
            objects[obj_str]++;
        }
    }

    public void DestroyObject(string obj_type){
        objects[obj_type]--;
    }

    public void ObjectOut(string obj){
        Debug.Log("We got an object out duh");
        out_cpt++;
        out_sound.Play();
        DisplayThrewInfo(obj);
        if(out_cpt==5 && !win){
            TravelToFuture();
            DisplayWin();
            loose = true;
            end = true;
            End();
        }
        out_pane.text = "Objects Out -> "+out_cpt+"/5";
    }
    public void ObjectIn(){
        Debug.Log("We got an object in rn");
        out_cpt--;
        out_sound.Play();
        out_pane.text = "Objects Out -> "+out_cpt+"/5";
    }

    public void PlaceInfo(Vector3 pts){
        if(!set_info){
            info_screen.SetActive(true);
            set_info = true;
        }
        info_screen.transform.position = pts;
        Vector3 cam_dir = player_cam.transform.position - info_screen.transform.position;
        info_screen.transform.rotation = Quaternion.LookRotation(cam_dir);
    }
}
