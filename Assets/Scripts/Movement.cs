using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    //Variables
    public float speed = 6.0f;
    public float gravity = 20.0f;
    private Vector3 move = Vector3.zero;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        // check if grounded
        if (controller.isGrounded)
        {
            //get input
            move = new Vector3(0, 0, Input.GetAxis("Vertical"));
            move = transform.TransformDirection(move);
            //speeeed?
            move *= speed;

        }
        //gravity
        move.y -= gravity * Time.deltaTime;
        //make character move
        controller.Move(move * Time.deltaTime * 2);
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * 0.5f);
    }
}
