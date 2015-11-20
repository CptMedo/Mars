using UnityEngine;
using System.Collections;
using Com.LuisPedroFonseca.ProCamera2D.Platformer;

public class Move : MonoBehaviour {

    public Transform player;

    public void GoLeft()
    {
        Debug.Log("mouse down");
        player.GetComponent<PlayerInput>().direction = -1;
    }

    public void GoRight()
    {
        Debug.Log("mouse down");
        player.GetComponent<PlayerInput>().direction = 1;
    }

    public void Jump()
    {
        player.GetComponent<PlayerInput>().isJumping = true;
    }

    public void StopMove()
    {
        Debug.Log("mouse up");
        player.GetComponent<PlayerInput>().direction = 0;
    }

    public void Destroy()
    {
        player.GetComponent<PlayerInput>().destroy();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
