using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D.Platformer
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerInput2 : MonoBehaviour
    {
        public Transform Body;

        // Player Handling
        public float gravity = 20;
        public float runSpeed = 12;
        public float acceleration = 30;
        public float jumpHeight = 12;
        public int jumpsAllowed = 2;

		public GameObject man;		
		public GameObject manJump;

		private float targetSpeed;

        private float currentSpeed;
        private Vector3 amountToMove;
        int totalJumps;

        CharacterController _characterController;

        void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }


		public void Jump()
		{
			totalJumps++;
			amountToMove.y = jumpHeight;	
			//			man.SetActive(false);
			//			manJump.SetActive(true);

		}

		
		public void Left()
		{
			 targetSpeed =  -runSpeed;
			MovePlayer ();
			
			
		}

		
		public void Right()
		{
			 targetSpeed =  runSpeed;
			MovePlayer ();
			
		}

        void Update()
        {
            // Reset acceleration upon collision
            if ((_characterController.collisionFlags & CollisionFlags.Sides) != 0)
            {
                currentSpeed = 0;

            }
		
            // If player is touching the ground
            if ((_characterController.collisionFlags & CollisionFlags.Below) != 0)
            {
                amountToMove.y = -1f;
                totalJumps = 0;
	//			man.SetActive(true);
	//			manJump.SetActive(false);
            }
            else
            {
                amountToMove.y -= gravity * Time.deltaTime;
            }

            // Jump
            if ((Input.GetKeyDown(KeyCode.W) || 
                Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown(KeyCode.UpArrow)) 
                && totalJumps < jumpsAllowed)
            {

				Jump();



			}
            // Input
			//if (Input.GetAxis("Horizontal") > 0)


			if (Input.GetAxis("Horizontal") > 0)
			{
				Right();
				
			}else if(Input.GetAxis("Horizontal") < 0){
				Left();
			}else{
				 targetSpeed = 0;
				
			}

			//   var targetSpeed = Input.GetAxis("Horizontal") * runSpeed;
			currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);
			
			
			// Reset z
			if (transform.position.z != 0)
			{
				amountToMove.z = -transform.position.z;
				//man.SetActive(true);
				//manJump.SetActive(false);
				
			}
			
			// Set amount to move
			amountToMove.x = currentSpeed;
			
			if(amountToMove.x != 0)
				Body.localScale = new Vector2(Mathf.Sign(amountToMove.x) * Mathf.Abs(Body.localScale.x), Body.localScale.y);
			
			_characterController.Move(amountToMove * Time.deltaTime);

	/*

			//   var targetSpeed = Input.GetAxis("Horizontal") * runSpeed;
			currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);


            // Reset z
            if (transform.position.z != 0)
            {
                amountToMove.z = -transform.position.z;
				//man.SetActive(true);
				//manJump.SetActive(false);
            
			}
		
            // Set amount to move
            amountToMove.x = currentSpeed;

            if(amountToMove.x != 0)
                Body.localScale = new Vector2(Mathf.Sign(amountToMove.x) * Mathf.Abs(Body.localScale.x), Body.localScale.y);

            _characterController.Move(amountToMove * Time.deltaTime);

*/
        }


		void MovePlayer()
		{
			//   var targetSpeed = Input.GetAxis("Horizontal") * runSpeed;
			currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);
			
			
			// Reset z
			if (transform.position.z != 0)
			{
				amountToMove.z = -transform.position.z;
				//man.SetActive(true);
				//manJump.SetActive(false);
				
			}
			
			// Set amount to move
			amountToMove.x = currentSpeed;
			
			if(amountToMove.x != 0)
				Body.localScale = new Vector2(Mathf.Sign(amountToMove.x) * Mathf.Abs(Body.localScale.x), Body.localScale.y);
			
			_characterController.Move(amountToMove * Time.deltaTime);
			
		}
	
        // Increase n towards target by speed
        private float IncrementTowards(float n, float target, float a)
        {
            if (n == target)
            {
                return n;	
            }
            else
            {
                float dir = Mathf.Sign(target - n); 
                n += a * Time.deltaTime * dir;
                return (dir == Mathf.Sign(target - n)) ? n : target;
            }
        }
    }
}
