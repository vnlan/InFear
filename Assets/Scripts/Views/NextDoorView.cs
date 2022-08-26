using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDoorView : GameElement
{
    public string nameNextDoor;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("character"))
        {
            app.controller.OnNextDoorHit(nameNextDoor);
        }
    }
}
