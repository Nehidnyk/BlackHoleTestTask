using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : GoodThing
{
    private Rigidbody rigidbody;
    private Animator animator;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            RotateCharacter();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Ground"))
        {
            RotateCharacter();
        }
    }

    private void RotateCharacter()
    {
        gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.eulerAngles + new Vector3(0, 130, 0));
    }

    public override void GetAbsorbed()
    {
        base.GetAbsorbed();
        Falling();
    }

    private void Falling()
    {
        rigidbody.useGravity = true;
        animator.applyRootMotion = false;
        animator.SetBool("Falling", true);
    }
}
