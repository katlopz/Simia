using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool m_TimeTravel = false; // The time the animation starts
        private bool m_PostTravel = false; // The time inbetween the animation and time swap
        private bool m_PostTravelStart = false; // The time swap starts
        private bool m_Interact;
        private bool m_Latch = false;
        public static bool inFuture = true;
        private float timeStart = 0f;
        private float travelTime = 0.655f;

        public bool freeze = false;
        public bool isPickingUp = false;
        public bool isDropping1 = false;
        public bool isDropping2 = false;
        public bool isDropping3 = false;

        private bool timeTravelling = false;
        private float timeTravelTimer = 0f;
        private float timeTravelTimerLimit = 0.9f;

        private Animator m_Animator;
        private Rigidbody2D m_Rigidbody;
        private void Awake()
        {
            m_Rigidbody = GetComponent<Rigidbody2D>();
            m_Animator = GetComponent<Animator>();
            m_Character = GetComponent<PlatformerCharacter2D>();
            if (m_Character.transform.position.y < 0) inFuture = false;
        }

        private void Update()
        {
            if(Time.timeScale < 0.1)
            {   
                m_Character.gameObject.GetComponent<AudioSource>().Pause();
                return;
            }

            if (!m_Jump && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)))
            {
                m_Jump = true;
            }

            if (!m_TimeTravel && Input.GetKeyDown(KeyCode.Q) && m_Rigidbody.velocity.y == 0f)
            {
                m_TimeTravel = true;
                m_PostTravel = false;
                timeTravelling = true;
                timeTravelTimer = timeTravelTimerLimit;
            }

            if (!m_Interact && Input.GetKeyDown(KeyCode.W))
            {
                m_Interact = true;
            }

            //p E is placeholder key
            if(!isPickingUp && Input.GetKeyDown(KeyCode.E))
            {
                isPickingUp = true;
            }
            else if(isPickingUp && Input.GetKeyUp(KeyCode.E))
            {
                isPickingUp = false;
            }

            if(!isDropping1 && (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))){
                isDropping1 = true;
            }
            if(!isDropping2 && (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2)))
            {
                isDropping2 = true;
            }
            if(!isDropping3 && (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3)))
            {
                isDropping3 = true;
            }

            //p

            //k Q is latching onto an object in order to push/pull it 
            if(Input.GetKeyDown(KeyCode.R))
            {
                m_Latch = true;
            }
            if (freeze)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    freeze = false;
                }
            }
        }


        private void FixedUpdate()
        {
            // J
            if (freeze)
            {
                return;
            }
            // Collisions checked in PlatformerCharacter2D.cs before time-travel
            
            // Read the inputs.
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, false, m_Jump, timeTravelling, inFuture, m_Interact, m_Latch);
            m_Character.TimeTravel(m_TimeTravel, m_PostTravelStart, inFuture);
            
            if(m_Character.grabbedSide == 0 || h == 0)
                m_Animator.SetTrigger("StopPushPull");
            else if(m_Character.grabbedSide == 1 && h > 0 || m_Character.grabbedSide == -1 && h < 0)
                m_Animator.SetTrigger("Pull");
            else if(m_Character.grabbedSide == 1 && h < 0 || m_Character.grabbedSide == -1 && h > 0)
                m_Animator.SetTrigger("Push");

            m_Jump = false;
            m_PostTravelStart = false;
            if (m_TimeTravel)
            {
                m_TimeTravel = false;
                m_PostTravel = true;
                timeStart = Time.time;
            }
            
            if (m_PostTravel && Time.time - timeStart >= travelTime) 
            {
                m_PostTravel = false;
                m_PostTravelStart = true;
            }

            timeTravelTimer -= Time.deltaTime;
		    if(timeTravelTimer < 0){
                timeTravelling = false;
		    }

            m_Interact = false;
            m_Latch = false;
        }
    }
}
