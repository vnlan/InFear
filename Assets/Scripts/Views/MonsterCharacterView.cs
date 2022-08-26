using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCharacterView : GameElement
{
    public float speed;
    public string name;

    private Animator animator;
    private Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("character"))
        {
            animator.SetTrigger("isAttack");
            app.controller.OnMonsterHit(name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("leftBan"))
        {
            gameObject.transform.Rotate(Vector3.up * 180);
        }

        if (other.gameObject.CompareTag("rightBan"))
        {
            gameObject.transform.Rotate(Vector3.up * 180);
        }
    }

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        RunAnimation();
    }

    private void RunAnimation()
    {
        animator.SetFloat("Movement", 0.5f);
    }
}
