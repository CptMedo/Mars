using UnityEngine;
using System.Collections;
using Com.LuisPedroFonseca.ProCamera2D.Platformer;

public class ObjectDestroy : MonoBehaviour {

    public Transform player;
    public Transform parent;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);

        player.GetComponent<PlayerInput>().objectToDestroy = parent;
    }

    void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayerInput>().objectToDestroy = null;
    }

}
