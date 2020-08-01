using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public GameObject trunk;
    public GameObject leftBranch;
    public GameObject rightBranch;
    public int treeHeight;

    void Start()
    {

        if (GameObject.FindGameObjectWithTag("Seed").transform.position.y < 0 ) 
        {
            float x = GameObject.FindGameObjectWithTag("Seed").transform.position.x;
            float y = (GameObject.FindGameObjectWithTag("Future").transform.position.y)+(float)1.8;

            for (int i = 0; i < treeHeight; i++)
            {
                Vector2 treePos = new Vector2(x, y);
                Instantiate(trunk, treePos, Quaternion.identity);

                if (i <= 4 || i > 5) // stops player from climbing too high
                {
                    Vector2 rightBranchPos = new Vector2(x + (float)1.5, y);
                    Instantiate(rightBranch, rightBranchPos, Quaternion.identity);
                }

                if (i < 4 || i >= 5) // stops player from climbing too high
                { 
                    Vector2 leftBranchPos = new Vector2(x - (float)1.5, y + (float)1.0);
                    Instantiate(leftBranch, leftBranchPos, Quaternion.identity);
                }   

                y += (float)2.5;
            }
        }   
    }
}
