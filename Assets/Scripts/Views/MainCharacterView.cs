using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacterView : GameElement
{
    public float speed;
    public string name;
    public VectorModel position;
    public float jumpSpeed;

    private float moveDirection;
    private bool isJumping;
    private bool isCrouch;
    private Rigidbody rb;
    private Animator animator;
    private CapsuleCollider capsuleCollider;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(app.level.Equals(ConstantsComp.STARTUP) && other.gameObject.CompareTag("KeyNotify"))
        {
            app.Notify(ConstantsComp.KEY);
        }

        if (app.level.Equals(ConstantsComp.STARTUP) && other.gameObject.CompareTag("TrapNotify"))
        {
            app.Notify(ConstantsComp.SPACE);
        }

        if (app.level.Equals(ConstantsComp.STARTUP) && other.gameObject.CompareTag("MonsterFlyNotify"))
        {
            app.Notify(ConstantsComp.CTRL);
        }

        if (app.level.Equals(ConstantsComp.STARTUP) && other.gameObject.CompareTag("MonsterGroundNotify"))
        {
            app.Notify(ConstantsComp.WARNING);
        }
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        //gameObject.transform.Translate(new Vector3(position.x, position.y, position.z));
    }

    private void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(moveDirection * speed, rb.velocity.y, rb.velocity.z);

        if (moveDirection < 0)
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
        else if (moveDirection > 0)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }

        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(rb.velocity.x, jumpSpeed, rb.velocity.z, ForceMode.Impulse);
            isJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouch = true;
            speed = speed / 3;
            capsuleCollider.height = (capsuleCollider.height / 1.5f);
            capsuleCollider.center = new Vector3(capsuleCollider.center.x, capsuleCollider.center.y / 1.5f, capsuleCollider.center.z);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouch = false;
            speed = speed * 3;
            capsuleCollider.height = (capsuleCollider.height * 1.5f);
            capsuleCollider.center = new Vector3(capsuleCollider.center.x, capsuleCollider.center.y * 1.5f, capsuleCollider.center.z);
        }

        if(moveDirection != 0)
        {
            app.HiddenNotify();
        }
        RunAnimation();
    }

    private void RunAnimation()
    {
        animator.SetFloat("Movement", Mathf.Abs(moveDirection));
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isCrouch", isCrouch);
    }
}
