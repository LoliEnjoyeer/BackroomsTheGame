using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : interactable
{
    private bool isOpen = false;
    private bool canBeInteractedWith = true;
    private Animator anim;

    public override void OnFocus()
    {
        anim = GetComponent<Animator>();
    }

    public override void OnInteract()
    {
        if (canBeInteractedWith)
        {
            isOpen = !isOpen;

            anim.SetBool("isOpen", isOpen);
        }
    }

    public override void OnLoseFocus()
    {

    }
}
