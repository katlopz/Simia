using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityStandardAssets._2D
{
    

    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class MKeyController : MonoBehaviour
    {   
        private PlatformerCharacter2D mKey;
        private GameObject player;
        private bool isOnPatrol = false;
        private bool isPunching = false;
        private bool m_Jump = false;

        public GameObject fallingMonty;

        private void Start()
        {
            mKey = GetComponent<PlatformerCharacter2D>();
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {            
            if(Time.timeScale < 0.1)
            {   
                mKey.gameObject.GetComponent<AudioSource>().Pause();
                return;
            }


        }

        private void FixedUpdate()
        {  
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if(!isPunching && distance < 5.0f)
            {
                StopPatrol(); 
                GetComponent<Animator>().SetTrigger("PunchT");
                isPunching = true;
                StartCoroutine(MKeyPunch());
            }
            else if(!isPunching && distance < 10.0f)
            {
                StopPatrol();
                if(player.transform.position.x < transform.position.x)
                {
                    mKey.Move(-1.0f,false,false,false,false,false,false);
                }
                else if(player.transform.position.x > transform.position.x)
                {
                    mKey.Move(1.0f,false,false,false,false,false,false);
                }
            }
            else if(distance > 30.0f)
            {
                StopPatrol();
                mKey.Move(0.0f,false,false,false,false,false,false);
            }  
            else if(!isOnPatrol)
            {   
                isOnPatrol = true;
                StartCoroutine(MKeyPatrol(1.0f)); 
            }   

            m_Jump = false;

            //k
            //if monty on top of acid            
            GameObject hole = GameObject.FindGameObjectWithTag("UnstableGround");
            if(hole != null)
            {
                float minDist = (float)3.0;
                float xDist = System.Math.Abs(hole.transform.localPosition.x - transform.localPosition.x);
                float yDist = System.Math.Abs(hole.transform.localPosition.y - transform.localPosition.y);

                float dist = (float)System.Math.Sqrt((xDist * xDist) + (yDist * yDist));

                if (dist <= minDist)
                {
                    // trigger falling, and stop this stage, spawn Monty of water tower
                    //move the barrel
                    Vector3 barPos = GameObject.Find("barrel").transform.localPosition;

                    barPos.x = 37.37f;
                    barPos.y = -4.24f;

                    GameObject.Find("barrel").transform.localPosition = barPos;

                    // falling monty
                    Vector2 pos = new Vector2(transform.localPosition.x, transform.localPosition.y);
                    Instantiate(fallingMonty, pos, Quaternion.identity);

                    Destroy(gameObject);
                }
            }
            //k
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            GameObject check = other.collider.gameObject;
            if(check.tag == "Crate")
            {
                StopPatrol();
                
                StartCoroutine(MKeyWait());
            }    
        }
                
        IEnumerator MKeyPunch()
        {      
            yield return new WaitForSeconds(0.4f);
                if(Vector3.Distance(player.transform.position, transform.position) < 6.9f && player.transform.position.x < transform.position.x)
                {
                    player.transform.GetComponent<PlayerRemote>().hitLeftCutsceneStartNow = true;
                    //Debug.Log(player.transform.GetComponent<PlayerRemote>());
                } 
                else if(Vector3.Distance(player.transform.position, transform.position) < 6.9f && player.transform.position.x > transform.position.x)
                {
                    player.transform.GetComponent<PlayerRemote>().hitRightCutsceneStartNow = true;
                    //Debug.Log(player.transform.GetComponent<PlayerRemote>());
                }
            isPunching = false; 
            
        }

        IEnumerator MKeyWait()
        {            
            mKey.Move(0.0f,false,false,false,false,false,false);
            yield return new WaitForSeconds(2f);
        }

        IEnumerator MKeyPatrol(float startDirection)
        {
            yield return new WaitForSeconds(2f);
            mKey.Move(startDirection*4,false,false,false,false,false,false);
            yield return new WaitForSeconds(2f);
            mKey.Move(0.0f,false,false,false,false,false,false);
            yield return new WaitForSeconds(2f);
            mKey.Move(-startDirection*4,false,false,false,false,false,false);
            yield return new WaitForSeconds(2f);
            mKey.Move(0.0f,false,false,false,false,false,false);
            isOnPatrol = false;
        }

        private void StopPatrol()
        {     
            isPunching = false;       
            isOnPatrol = false;
            StopAllCoroutines();
        }
    }
}

    