using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D.Platformer
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerInput : MonoBehaviour
    {
        public Transform Body;

        // Player Handling
        public float gravity = 15;
        public float runSpeed = 12;
        public float acceleration = 30;
        public float jumpHeight = 12;
        public int jumpsAllowed = 2;
        public bool facingRight = true;

        private float currentSpeed;
        private Vector3 amountToMove;


		// 0 : stationnary
		// 1 : right
		// -1 : left
		public int direction = 0;

        public bool isJumping = false;

        public Transform objectToDestroy = null;

        int totalJumps;

        CharacterController _characterController;

        private Animator robotAnimator = null;
        private Animator maxAnimator = null;

        void Start()
        {
            _characterController = GetComponent<CharacterController>();
            robotAnimator = GameObject.Find("Robot").GetComponent<Animator>();
            maxAnimator = GameObject.Find("Human").GetComponent<Animator>();
            Debug.Log("animator:"+robotAnimator);
        }

        void FixedUpdate()
        {
			this.move();
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

	    private void move() {
            
			
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
                robotAnimator.SetBool("Jump", false);
                maxAnimator.SetBool("Jump", false);
            }
            else
            {
                amountToMove.y -= gravity * Time.deltaTime;
            }

            if (totalJumps < jumpsAllowed && isJumping)
            {
                Debug.Log("jump if");
                totalJumps++;
                amountToMove.y = jumpHeight;
                robotAnimator.SetBool("Jump", true);
                maxAnimator.SetBool("Jump", true);
            }
            isJumping = false;

            // Input
			var targetSpeed = direction * runSpeed;
			currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);
            Debug.Log("animator before call:" + robotAnimator);
            if(robotAnimator.gameObject.activeInHierarchy)
            {
                Debug.Log("animator go:" + robotAnimator);
                robotAnimator.SetFloat("Speed", Mathf.Abs(currentSpeed));
            }

            if (maxAnimator.gameObject.activeInHierarchy)
            {
                Debug.Log("animator go:" + maxAnimator);
                maxAnimator.SetFloat("Speed", Mathf.Abs(currentSpeed));
            }

            //Debug.Log("currentspeed :" + currentSpeed);
            if (currentSpeed > 0 && !facingRight)
                Flip();
            else if (currentSpeed < 0 && facingRight)
                Flip();

            // Reset z
            if (transform.position.z != 0)
			{
				amountToMove.z = -transform.position.z;
			}
			
			// Set amount to move
			amountToMove.x = currentSpeed;
			
			if(amountToMove.x != 0)
				Body.localScale = new Vector2(Mathf.Sign(amountToMove.x) * Mathf.Abs(Body.localScale.x), Body.localScale.y);
			
			_characterController.Move(amountToMove * Time.deltaTime);
		}

        public void destroy()
        {
            Debug.Log(objectToDestroy);
            if (objectToDestroy != null)
            {
                Destroy(objectToDestroy.gameObject);
            }
            objectToDestroy = null;
        }

        void Flip()
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }


    }
}
