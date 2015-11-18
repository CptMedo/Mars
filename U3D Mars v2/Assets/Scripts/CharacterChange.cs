using UnityEngine;
using System.Collections;
using Com.LuisPedroFonseca.ProCamera2D.Platformer;

public class CharacterChange : MonoBehaviour {


	public GameObject GuiHuman;
	public GameObject GuiRobot;
    public GameObject GuiRamasser;
    public GameObject GuiVoler;
    public GameObject GuiCreuser;
	public GameObject Human;
	public GameObject Robot;
    public Transform player;

    private Collider humanCollider;
    private Collider robotCollider;

    // Use this for initialization
    void Start () {
		HumanSelection ();
        humanCollider = Human.GetComponent<BoxCollider>();
        robotCollider = Robot.GetComponent<BoxCollider>();
        Debug.Log(humanCollider);
        Debug.Log(robotCollider);
    }
	
	// Update is called once per frame
	void Update () {
	
	}


	void HumanSelection () {
		GuiHuman.SetActive (true);
        GuiRamasser.SetActive(true);
		GuiRobot.SetActive(false);
        GuiCreuser.SetActive(false);

        Human.SetActive(true);
        Robot.SetActive(false);

		Human.GetComponent<SpriteRenderer> ().enabled = true;
		Robot.GetComponent<SpriteRenderer> ().enabled = false;
        player.GetComponent<PlayerInput>().jumpsAllowed = 1;
        player.GetComponent<CharacterController>().radius = 0.19f;
        player.GetComponent<CharacterController>().height = 0.46f;
        player.GetComponent<CharacterController>().center = new Vector3(0f, 0.25f, 0f);

    }

	void RobotSelection () {

		GuiHuman.SetActive (false);
        GuiRamasser.SetActive(false);
        GuiRobot.SetActive (true);
        GuiCreuser.SetActive(true);

        Human.SetActive(false);
        Robot.SetActive(true);

        Human.GetComponent<SpriteRenderer> ().enabled = false;
		Robot.GetComponent<SpriteRenderer> ().enabled = true;
        player.GetComponent<PlayerInput>().jumpsAllowed = 2;
        player.GetComponent<CharacterController>().radius = 0.22f;
        player.GetComponent<CharacterController>().height = 0.65f;
        player.GetComponent<CharacterController>().center = new Vector3(0f, 0.32f, 0f);

    }
}

