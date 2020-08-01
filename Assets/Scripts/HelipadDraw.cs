using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class HelipadDraw : MonoBehaviour
{
    private bool complete;
    Image[] steps = new Image[9];
    int index = 0;
    public GameObject helicopter;

    void Start()
    {
        steps[0] = this.transform.Find("1").GetComponent<Image>();
        steps[1] = this.transform.Find("2").GetComponent<Image>();
        steps[2] = this.transform.Find("3").GetComponent<Image>();
        steps[3] = this.transform.Find("4").GetComponent<Image>();
        steps[4] = this.transform.Find("5").GetComponent<Image>();
        steps[5] = this.transform.Find("6").GetComponent<Image>();
        steps[6] = this.transform.Find("7").GetComponent<Image>();
        steps[7] = this.transform.Find("8").GetComponent<Image>();
        steps[8] = this.transform.Find("9").GetComponent<Image>();
    }

    void Update()
    {
        if (complete) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index < 9)
            {
                steps[index].enabled = true;
                index++;
            }
            else
            {
                complete = true;
                // spawn the helicopter
                Vector2 playerPos = new Vector2(72.7f, 0.12f);
                Instantiate(helicopter, playerPos, Quaternion.identity);
                GameObject.FindWithTag("Helicopter").transform.eulerAngles = new Vector3(0, 0, 21.361f);
            }
        }
    }

    public bool completed()
    {
        return complete;
    }
    
    
}
