using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableInteractable : Interaction {
    public int objectCode;

    protected override void Start() {
        base.Start();
    }


    public override void Interact() {
        base.Interact();
        
        //gameObject.SetActive(false);
    }

    public override void SuccessInteraction ()
    {
        if (!playerInteractor.itemGot.Contains(objectCode))
            playerInteractor.itemGot.Add(objectCode);
    }
}
