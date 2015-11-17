using UnityEngine;
using System.Collections;

public class CharacterChange : MonoBehaviour {


	public GameObject GuiHuman;
	public GameObject GuiRobot;
    public GameObject GuiRamasser;
    public GameObject GuiVoler;
    public GameObject GuiCreuser;
	public GameObject Human;
	public GameObject Robot;

	// Use this for initialization
	void Start () {
		HumanSelection ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void HumanSelection () {
		GuiHuman.SetActive (true);
        GuiRamasser.SetActive(true);
		GuiRobot.SetActive(false);
        GuiVoler.SetActive(false);
        GuiCreuser.SetActive(false);

		Human.GetComponent<SpriteRenderer> ().enabled = true;
		Robot.GetComponent<SpriteRenderer> ().enabled = false;
	
	}

	void RobotSelection () {

		GuiHuman.SetActive (false);
        GuiRamasser.SetActive(false);
        GuiRobot.SetActive (true);
        GuiVoler.SetActive(true);
        GuiCreuser.SetActive(true);

        Human.GetComponent<SpriteRenderer> ().enabled = false;
		Robot.GetComponent<SpriteRenderer> ().enabled = true;
		
	}
}

