using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoNavigation : MonoBehaviour{
    //Buttons objects
    public GameObject cancel;
    public GameObject previous;
    public GameObject next;
    public Material out_m;
    public Material in_m;

    //Texts objects
    public GameObject welcome;
    public GameObject game;
    public GameObject nav;
    public GameObject manip;
    public GameObject capsule;
    public GameObject scores;
    public GameObject thanks;

    //Sounds
    public AudioSource hover_sound;
    public AudioSource click_sound;

    //localizer
    private string current = ""; //"w", "g", "n", "m", "c", "s", "t"
    
    public void Start(){
        current = "w";
    }

    public void HoverInBtn(GameObject btn){
        hover_sound.Play();
        Renderer r = btn.transform.GetComponent<Renderer>();
        if(r != null){
            r.material = in_m;
        }
    }
    public void HoverOutBtn(GameObject btn){
        Renderer r = btn.transform.GetComponent<Renderer>();
        if(r != null){
            r.material = out_m;
        }
    }

    public void ClickCancel(){
        click_sound.Play();
        switch (current){
            case "w":
                welcome.SetActive(false);
                break;
            case "g":
                game.SetActive(false);
                break;
            case "n":
                nav.SetActive(false);
                break;
            case "m":
                manip.SetActive(false);
                break;
            case "c":
                capsule.SetActive(false);
                break;
            case "s":
                scores.SetActive(false);
                break;
            
            default:
                break;
        }
        current = "t";
        thanks.SetActive(true);
        previous.SetActive(true);
        next.SetActive(false);
    }
    public void ClickPrevious(){
        click_sound.Play();
        switch (current){
            case "g":
                game.SetActive(false);
                welcome.SetActive(true);
                previous.SetActive(false);
                current = "w";
                break;
            case "n":
                nav.SetActive(false);
                game.SetActive(true);
                current = "g";
                break;
            case "m":
                manip.SetActive(false);
                nav.SetActive(true);
                current = "n";
                break;
            case "c":
                capsule.SetActive(false);
                manip.SetActive(true);
                current = "m";
                break;
            case "s":
                scores.SetActive(false);
                capsule.SetActive(true);
                current = "c";
                break;
            case "t":
                thanks.SetActive(false);
                scores.SetActive(true);
                next.SetActive(true);
                current = "s";
                break;
            
            default:
                break;
        }
    }
    public void ClickNext(){
        click_sound.Play();
        switch (current){
            case "w":
                welcome.SetActive(false);
                game.SetActive(true);
                previous.SetActive(true);
                current = "g";
                break;
            case "g":
                game.SetActive(false);
                nav.SetActive(true);
                current = "n";
                break;
            case "n":
                nav.SetActive(false);
                manip.SetActive(true);
                current = "m";
                break;
            case "m":
                manip.SetActive(false);
                capsule.SetActive(true);
                current = "c";
                break;
            case "c":
                capsule.SetActive(false);
                scores.SetActive(true);
                current = "s";
                break;
            case "s":
                scores.SetActive(false);
                thanks.SetActive(true);
                next.SetActive(false);
                current = "t";
                break;
            
            default:
                break;
        }
    }
}
