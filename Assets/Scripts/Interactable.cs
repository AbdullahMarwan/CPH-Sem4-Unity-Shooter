using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //message displayed to player when looking at en interactable.
    public string promptMessage;

    //this funktion will be called from  our player.

    public void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {
        //we wont have any code written in this funktion
        //this is a template function to be overridden by our subclasses

    }
}
