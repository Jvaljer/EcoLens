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
    public GameObject feature1;
    public GameObject feature2;
    public GameObject feature3;
    public GameObject feature4;
    public GameObject feature5;
    public GameObject feature6;
    public GameObject scores;
    public GameObject out_count;
    public GameObject trash_count;
    public GameObject thanks;

    //Sounds
    public AudioSource hover_sound;
    public AudioSource click_sound;

    //localizer
    private string current = ""; //"w", "g", "n", "m", "c", "s", "t", "f1-6", "oc", "tc"
    
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
            case "f1":
                feature1.SetActive(false);
                break;
            case "f2":
                feature2.SetActive(false);
                break;
            case "f3":
                feature3.SetActive(false);
                break;
            case "f4":
                feature4.SetActive(false);
                break;
            case "f5":
                feature5.SetActive(false);
                break;
            case "f6":
                feature6.SetActive(false);
                break;
            case "s":
                scores.SetActive(false);
                break;
            case "oc":
                out_count.SetActive(false);
                break;
            case "tc":
                trash_count.SetActive(false);
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
            case "f1":
                feature1.SetActive(false);
                capsule.SetActive(true);
                current = "c";
                break;
            case "f2":
                feature2.SetActive(false);
                feature1.SetActive(true);
                current = "f1";
                break;
            case "f3":
                feature3.SetActive(false);
                feature2.SetActive(true);
                current = "f2";
                break;
            case "f4":
                feature4.SetActive(false);
                feature3.SetActive(true);
                current = "f3";
                break;
            case "f5":
                feature5.SetActive(false);
                feature4.SetActive(true);
                current = "f4";
                break;
            case "f6":
                feature6.SetActive(false);
                feature5.SetActive(true);
                current = "f5";
                break;
            case "s":
                scores.SetActive(false);
                feature6.SetActive(true);
                current = "f6";
                break;
            case "oc":
                out_count.SetActive(false);
                scores.SetActive(true);
                current = "s";
                break;
            case "tc":
                trash_count.SetActive(false);
                out_count.SetActive(true);
                current = "oc";
                break;
            case "t":
                thanks.SetActive(false);
                trash_count.SetActive(true);
                next.SetActive(true);
                current = "tc";
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
                feature1.SetActive(true);
                current = "f1";
                break;
            case "f1":
                feature1.SetActive(false);
                feature2.SetActive(true);
                current = "f2";
                break;
            case "f2":
                feature2.SetActive(false);
                feature3.SetActive(true);
                current = "f3";
                break;
            case "f3":
                feature3.SetActive(false);
                feature4.SetActive(true);
                current = "f4";
                break;
            case "f4":
                feature4.SetActive(false);
                feature5.SetActive(true);
                current = "f5";
                break;
            case "f5":
                feature5.SetActive(false);
                feature6.SetActive(true);
                current = "f6";
                break;
            case "f6":
                feature6.SetActive(false);
                scores.SetActive(true);
                current = "s";
                break;
            case "s":
                scores.SetActive(false);
                out_count.SetActive(true);
                current = "oc";
                break;
            case "oc":
                out_count.SetActive(false);
                trash_count.SetActive(true);
                current = "tc";
                break;
            case "tc":
                trash_count.SetActive(false);
                thanks.SetActive(true);
                next.SetActive(false);
                current = "t";
                break;

            default:
                break;
        }
    }
}
