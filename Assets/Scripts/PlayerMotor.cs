using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {
    Animation animation;

    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;

    public Vector3 jumpSpeed;//hauteur du saut

    CapsuleCollider playerCapsuleCollider;

    public bool isDead  ;
         
    // Use this for initialization
    void Start () {
        animation = gameObject.GetComponent<Animation>();
        playerCapsuleCollider = gameObject.GetComponent<CapsuleCollider>();

    }

    bool IsGrounded()
    {
        return Physics.CheckCapsule(playerCapsuleCollider.bounds.center, new Vector3(playerCapsuleCollider.bounds.center.x, playerCapsuleCollider.bounds.min.y - 0.1f, playerCapsuleCollider.bounds.center.z), 0.08f) ;
       
    }
	
	// Update is called once per frame
	void Update () {

        if (!isDead)
        {

            //walk
            if (Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0, 0, walkSpeed * Time.deltaTime);
                animation.Play("walk");
            }


            //run
            if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0, 0, runSpeed * Time.deltaTime);
                animation.Play("run");
            }

            //back
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, 0, -walkSpeed * Time.deltaTime);
                animation.Play("walk");
            }

            //left rotation
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(0,-turnSpeed * Time.deltaTime, 0);
            }

            //right rotation
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
            }

            //IDLE
            if (!Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.S))
            {
                animation.Play("idle");
            }


            //jump
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                Vector3 _velocity = gameObject.GetComponent<Rigidbody>().velocity;
                _velocity.y = jumpSpeed.y;
                gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;

            }

        }


    }
}
