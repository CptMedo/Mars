using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	//	InvokeRepeating("Destroy", 0, 0.1f);
		
		//Object.Destroy(this.gameObject, 5.0f);
		
	}
	
	
	void Destroy () {




	}

	void Awake()
	{
		Object.Destroy(this.gameObject, 5.0f);
	}


	// Update is called once per frame
	void Update () {
	
	}
}
