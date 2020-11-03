using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Transform follow;
    bool canMove = true;
    bool canMoveForward = true;

    bool forward = false;
    bool turnRight = false;
    bool turnLeft = false;

    public void Move(string key)
    {
        if (key == "w" && canMove && canMoveForward)
        {
            canMove = false;
            forward = true;
            StartCoroutine(Interval(1));
        } else if (key == "a" && canMove)
        {
            canMove = false;
            turnLeft = true;
            StartCoroutine(Interval(2));
        } else if (key == "d" && canMove)
        {
            canMove = false;
            turnRight = true;
            StartCoroutine(Interval(2));
        }
    }

    private void FixedUpdate()
    {
        if (forward)
        {
            transform.position = Vector3.Lerp(transform.position, follow.position, Time.deltaTime);
        }

        if (turnLeft)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), 3 * Time.deltaTime);
        }

        if (turnRight)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 3 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            canMoveForward = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
        {
            canMoveForward = true;
        }
    }

    IEnumerator Interval(int t)
    {
        yield return new WaitForSeconds(t);
        forward = false;
        turnRight = false;
        turnLeft = false;
        canMove = true;
    }
}
