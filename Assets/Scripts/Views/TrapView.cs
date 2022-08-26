using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapView : GameElement
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("character"))
        {
            app.controller.OnMonsterHit("Trap");
        }
    }
}
