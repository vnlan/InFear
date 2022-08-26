using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyView : GameElement
{
/*    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("character"))
        {
            app.controller.OnKeyHit();
            DestroyObject(gameObject);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("character"))
        {
            UltilComponent.writeData($"{app.level}||{app.model.life}|{app.model.key}|{gameObject.transform.position.x}|{gameObject.transform.position.y}|{gameObject.transform.position.z}");
            app.controller.OnKeyHit();
            DestroyObject(gameObject);
        }
    }
}
