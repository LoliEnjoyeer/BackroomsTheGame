using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screwdriver : interactable
{
    public override void OnFocus()
    {
        print("Looking at Screwdriver");
    }

    public override void OnInteract()
    {
        print("I interacted with Screwdriver");
    }

    public override void OnLoseFocus()
    {
        print("Not Looking anymore at Screwdriver");
    }
}
