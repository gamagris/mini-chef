using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";

    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Animator animator;
    

    [SerializeField] private float moveSpeed;


   
    private void Update()
    {
        rigidBody.velocity = new Vector3(joystick.Horizontal * moveSpeed, rigidBody.velocity.y, joystick.Vertical * moveSpeed);

        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rigidBody.velocity);
            animator.SetBool("IS_WALKING", true);

        }
        else
        {
            animator.SetBool("IS_WALKING", false);
        }

    }
}
