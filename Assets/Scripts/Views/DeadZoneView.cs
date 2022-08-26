using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneView : GameElement
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("character"))
        {
            app.controller.OnDeadZoneHit();
        }
    }
}
