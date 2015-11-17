#pragma strict
//@RequireComponent(AudioSource)

// FadeInOut
//
//--------------------------------------------------------------------
//                        Public parameters
//--------------------------------------------------------------------
 
public var fadeOutTexture : Texture2D;
public var fadeSpeed = 0.3;
 
var drawDepth = -1000;
 
//--------------------------------------------------------------------
//                       Private variables
//--------------------------------------------------------------------
 
private var alpha = 1.0; 
private var loadlevel = false;
private var fadeDir = -1;
 
//--------------------------------------------------------------------
//                       Runtime functions
//--------------------------------------------------------------------
 
//--------------------------------------------------------------------
 
 

public var impact: AudioClip;
private var audi: AudioSource;


function OnGUI(){
 
	alpha += fadeDir * fadeSpeed * Time.deltaTime;	
	alpha = Mathf.Clamp01(alpha);	
 
	GUI.color.a = alpha;
 
	GUI.depth = drawDepth;
 
	GUI.DrawTexture(Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);

	if ((loadlevel) && (alpha ==1) ) Application.LoadLevel(1);

		
}

 
function Update(){

		if (Input.GetMouseButtonUp(0)){

 			fadeOut();
 			loadlevel = true;
 			audi.PlayOneShot(impact, 0.7F);
 			//audi.Play();
 			
			
		}
 }
 
//--------------------------------------------------------------------
 
function fadeIn(){
	fadeDir = -1;	
	
}
 
//--------------------------------------------------------------------
 
function fadeOut(){
	fadeDir = 1;	
}
 
function Start(){
	audi = GetComponent.<AudioSource>();
	alpha=1.0;
	fadeIn();

}