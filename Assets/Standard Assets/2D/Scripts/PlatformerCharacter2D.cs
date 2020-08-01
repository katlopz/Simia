using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 9.6076f; // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 15f; // Amount of force added when the player jumps.
        public float m_fallMultiplier = 3f; // amount of increasing speed of player after apex of jump
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f; // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false; // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround; // A mask determining what is ground to the character

        private Transform m_GroundCheck; // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded; // Whether or not the player is grounded.
        private Transform m_CeilingCheck; // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim; // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true; // For determining which way the player is currently facing.

        private GameObject moveable = null;
        private bool coll = false;
        // audio
        public AudioClip StepClip;
        public AudioClip JumpClip;
        public AudioClip TimeTravelClip;
        public AudioSource SoundSource;

        public int grabbedSide = 0;

        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
        }

        public void Move(float move, bool crouch, bool jump, bool timeTravel, bool inFuture, bool interact, bool latch)
        {
            if (!timeTravel)
            {
                // If running, play sounds
                if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                {
                    SoundSource.clip = StepClip;
                    if (!SoundSource.isPlaying)
                        SoundSource.Play();
                }
                else if (SoundSource.isPlaying && SoundSource.clip == StepClip)
                {
                    SoundSource.Stop();
                }

                // If crouching, check to see if the character can stand up
                // if (!crouch && m_Anim.GetBool ("Crouch")) {
                //     // If the character has a ceiling preventing them from standing up, keep them crouching
                //     if (Physics2D.OverlapCircle (m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround)) {
                //         crouch = true;
                //     }
                // }

                // Set whether or not the character is crouching in the animator
                // m_Anim.SetBool ("Crouch", crouch);

                //only control the player if grounded or airControl is turned on
                if (m_Grounded && !timeTravel || m_AirControl && !timeTravel)
                {
                    float prevX = transform.localPosition.x;

                    // Reduce the speed if crouching by the crouchSpeed multiplier
                    // move = (crouch ? move * m_CrouchSpeed : move);

                    float pushpullSpeed = 2f;
                    move = (latch ? move / pushpullSpeed : move);

                    // The Speed animator parameter is set to the absolute value of the horizontal input.
                    m_Anim.SetFloat("Speed", Mathf.Abs(move));

                    // Move the character
                    m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);

                    // If the input is moving the player right and the player is facing left...
                    if (move > 0 && !m_FacingRight)
                    {
                        // ... flip the player.
                        Flip();
                    }
                    // Otherwise if the input is moving the player left and the player is facing right...
                    else if (move < 0 && m_FacingRight)
                    {
                        // ... flip the player.
                        Flip();
                    }

                    //float nextX = transform.localPosition.x;
                    //float diffX = nextX - prevX;

                    if (moveable != null)
                    {
                        //p  
                        if (Input.GetKey(KeyCode.R)){
                            transform.GetChild(3).gameObject.SetActive(true);
                            if(moveable.transform.position.x < transform.position.x)
                                grabbedSide = 1;
                            else
                                grabbedSide = -1;
                        }
                        else
                        {
                            transform.GetChild(3).gameObject.SetActive(false);
                            grabbedSide = 0;
                        }
                        Vector3 pushpullColliderScale = transform.GetChild(3).gameObject.transform.localScale;
                        pushpullColliderScale.x = -1;
                        transform.GetChild(3).gameObject.transform.localScale = pushpullColliderScale;

                        /*Vector3 thePos = moveable.transform.localPosition;
                        thePos.x += move*0.001f;
                        moveable.transform.localPosition = thePos;
                        Debug.Log("X: " + thePos.x);*/
                    }
                    else if (!Input.GetKey(KeyCode.R))
                    {
                        transform.GetChild(3).gameObject.SetActive(false); //this turns the pull/push colliders off
                            grabbedSide = 0;
                    }
                    //p
                }
                // If the player should jump...
                if (m_Grounded && jump && m_Anim.GetBool("Ground"))
                {
                    Jump();
                }

                // If the player should interact...
                if (interact)
                {
                    //actual interactables
                    GameObject[] interactables = GameObject.FindGameObjectsWithTag("Interactable");

                    float minDist = (float)2.0;
                    GameObject closest = null;

                    //find closest interactable
                    for (int i = 0; i < interactables.Length; i++)
                    {
                        float x = interactables[i].transform.position.x;
                        float y = interactables[i].transform.position.y;
                        float xDist = x - transform.localPosition.x;
                        float yDist = y - transform.localPosition.y;

                        float dist = (float)Math.Sqrt((xDist * xDist) + (yDist * yDist));

                        if (dist <= minDist)
                        {
                            minDist = dist;
                            closest = interactables[i];
                        }
                    }

                    if (closest != null)
                    {
                        //interact with it
                        Interactable other = (Interactable)closest.GetComponent(typeof(Interactable));
                        other.Interact();
                    }
                }

                //k 
                // if player should push/pull
                if (latch)
                {
                    if (moveable == null)
                    {
                        //find the closest moveable object
                        GameObject[] moveables = GameObject.FindGameObjectsWithTag("Moveable");

                        float maxDist = (float)1.5;
                        float minDist = (float)1.0;
                        GameObject closest = null;

                        //find closest interactable
                        for (int i = 0; i < moveables.Length; i++)
                        {
                            float x = moveables[i].transform.position.x;
                            float y = moveables[i].transform.position.y;
                            float xDist = x - transform.localPosition.x;
                            float yDist = y - transform.localPosition.y;

                            float dist = (float)Math.Sqrt((xDist * xDist) + (yDist * yDist));

                            if (dist <= maxDist && dist > minDist)
                            {
                                maxDist = dist;
                                closest = moveables[i];
                            }
                        }
                        moveable = closest;
                    }
                    else
                    {
                        moveable = null;
                    }
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Stairs")
            {
                Debug.Log("STAIRS");
                m_Grounded = true;
            }
            if (collision.gameObject.tag == "BadSpace")
            {
                coll = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "BadSpace")
            {
                coll = false;
            }
        }

        public void TimeTravel(bool timeTravel, bool postTravel, bool inFuture)
        {
            //J Check for collisions
           
            Vector3 currentPos = transform.localPosition, ttPos = transform.localPosition; // current and destination positions   
            if (inFuture)
            {
                ttPos.y += GameObject.FindGameObjectWithTag("Past").transform.position.y;
            }
            else
            {
                ttPos.y -= GameObject.FindGameObjectWithTag("Past").transform.position.y;
            }

            if (timeTravel && coll == false) // start animation
            {
                if (SoundSource.isPlaying && SoundSource.clip != TimeTravelClip)
                {
                    SoundSource.Stop();
                }
                // freeze player

                m_Anim.SetTrigger("IsTravelling");
                moveable = null; // should not be able to move an object when timetravelling

                SoundSource.clip = TimeTravelClip;
                SoundSource.Play();
            }
            else if (timeTravel && coll == true)
            {
                Dialogue dialogue = new Dialogue("Monicka", new string[]{"I can't time travel here for some reason.", "Something must be in my way."});
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }

            if (postTravel && coll == false)
            {
                // Change Y position...
                //currentPos.y += 1; //so that they float a little when travelling //*************** Interrupts the time travel animation atm

                Platformer2DUserControl.inFuture = !inFuture; //I realise this is probably not 
                //the best to have a public field

                transform.localPosition = ttPos;
                coll = false;
            }
        }

        private void Jump()
        {
            if (SoundSource.isPlaying && SoundSource.clip != JumpClip)
            {
                SoundSource.Stop();
            }

            //always hear after see so sound goes first
            SoundSource.clip = JumpClip;
            if (!SoundSource.isPlaying)
            {
                SoundSource.Play();
            }

            //set grounded variables
            m_Grounded = false;
            //set animation variables
            m_Anim.SetBool("Ground", false);

            //add force and add gravity when hit half way throuh jump
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, m_JumpForce);
            if (m_Rigidbody2D.velocity.y < 0)
            {
                m_Rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (m_fallMultiplier - 1) * Time.deltaTime;
            }
        }

        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        public void Speak(String text)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(new Dialogue("Monicka", text));
            GameObject.Find("Player").GetComponent<Platformer2DUserControl>().freeze = false;
        }

        public void GroundPlayer(){
            m_Anim.SetBool("Ground", true);
            m_Grounded = true;
        }
    }
}