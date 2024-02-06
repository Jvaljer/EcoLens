using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BtnFollowVisual : MonoBehaviour {
    public Transform visual_trgt;
    public Vector3 local_axis;
    public float reset_speed = 5;
    private Vector3 offset;
    private Transform poke_attach_transform;
    private XRBaseInteractable interactable;
    private bool is_following = false;
    private bool freeze = false;
    private Vector3 init_local_pos;

    void Start(){
        init_local_pos = visual_trgt.localPosition;

        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Follow);
        interactable.hoverExited.AddListener(Reset);
        interactable.selectEntered.AddListener(Freeze);
    }
    void Update(){
        if(freeze)
            return;
        
        if(is_following){
            Vector3 local_trgt_pos = visual_trgt.InverseTransformPoint(poke_attach_transform.position + offset);
            Vector3 constrained_local_trgt_pos = Vector3.Project(local_trgt_pos, local_axis);
            visual_trgt.position = visual_trgt.TransformPoint(constrained_local_trgt_pos);
        } else {
            visual_trgt.localPosition = Vector3.Lerp(visual_trgt.localPosition, init_local_pos, Time.deltaTime*reset_speed);
        }
    }

    public void Follow(BaseInteractionEventArgs hover){
        if(hover.interactorObject is XRPokeInteractor){
            XRPokeInteractor interactor = (XRPokeInteractor) hover.interactorObject;
            is_following = true; 
            freeze = false;
            poke_attach_transform = interactor.attachTransform;
            offset = visual_trgt.position - poke_attach_transform.position;
        }
    }

    public void Reset(BaseInteractionEventArgs hover){
        if(hover.interactorObject is XRPokeInteractor){
            is_following = false;
            freeze = false;
        }
    }

    public void Freeze(BaseInteractionEventArgs hover){
        if(hover.interactorObject is XRPokeInteractor){
            freeze = true;
        }
    }
}
