using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KidnapCutscene : MonoBehaviour
{
    private bool complete;
    Image[] steps = new Image[3];
    int index = 0;

    void Start()
    {
        steps[0] = this.transform.Find("1").GetComponent<Image>();
        steps[1] = this.transform.Find("2").GetComponent<Image>();
        steps[2] = this.transform.Find("3").GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index < 3)
            {
                steps[index].enabled = true;
                index++;
            }
            else if(index == 3)
            {
                //destroy kid
                GameObject.Find("Kid(Clone)").SetActive(false);
                //destroy this
                Destroy(gameObject);
            }
        }
    }
}
