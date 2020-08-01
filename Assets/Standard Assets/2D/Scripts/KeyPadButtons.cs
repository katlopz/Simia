using UnityEngine;
using UnityEngine.UI;

public class KeyPadButtons : MonoBehaviour
{
    private int[] input = new int[4];
    private int code1 = 1;
    private int code2 = 9;
    private int code3 = 7;
    private int code4 = 1;
    private int index = 0;

    private Image x1, x2, x3, x4;

    public AudioClip CorrectClip;
    public AudioClip WrongClip;
    public AudioSource SoundSource;

    void Start() 
    {
        x1 = this.transform.Find("x1").GetComponent<Image>();
        x2 = this.transform.Find("x2").GetComponent<Image>();
        x3 = this.transform.Find("x3").GetComponent<Image>();
        x4 = this.transform.Find("x4").GetComponent<Image>();
        FindObjectOfType<DialogueManager>().nameText.text = "KeyPad";
        FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
            add0();
        if(Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
            add1();
        if(Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
            add2();
        if(Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
            add3();
        if(Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
            add4();
        if(Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
            add5();
        if(Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
            add6();
        if(Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
            add7();
        if(Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
            add8();
        if(Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
            add9();

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            confirm();
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (index == 0) return;
            input[index] = 0;
            index--;
            drawX();
        }
    }

    public void confirm()
    {
        if (input[0] == code1 && input[1] == code2 && input[2] == code3 && input[3] == code4)
        {
            FindObjectOfType<DialogueManager>().dialogueText.text = ("CODE CORRECT");
            
            
            //something to trigger door open
            //GameObject openDoor = GameObject.FindGameObjectWithTag("OpenDoor");
            //Vector2 pos = new Vector2(201.24f, -47.6f);
            //Instantiate(openDoor, pos, Quaternion.identity);

          //  SoundSource.clip = CorrectClip;

            //open door
            var door = GameObject.Find("end_door_close").GetComponent<KeypadDoor>();
            door.open();

            Destroy(GameObject.Find("Keydoor"));
            Destroy(gameObject);
            FindObjectOfType<DialogueManager>().animator.SetBool("active", false);
        }
        else
        {
            SoundSource.clip = WrongClip;
            SoundSource.Play();
            clear();
        }
    }

    public void clear()
    {
        index = 0;
        for (int i = 0; i < input.Length; i++) input[i] = -1;

        x1.enabled = false;
        x2.enabled = false;
        x3.enabled = false;
        x4.enabled = false;
    }

    private void drawX()
    {
        string inputSoFar = "";
        for (int i = 0; i < index; i++) inputSoFar += input[i];

        if (index == 4) {
            x4.enabled = true;
        } 
        if (index == 3) {
            x4.enabled = false;
            x3.enabled = true;
        }
        if (index == 2) {
            x4.enabled = false;
            x3.enabled = false;
            x2.enabled = true;
        }
        if (index == 1) {
            x4.enabled = false;
            x3.enabled = false;
            x2.enabled = false;
            x1.enabled = true;
        }
        if (index == 0) {
            x4.enabled = false;
            x3.enabled = false;
            x2.enabled = false;
            x1.enabled = false;
        }

        FindObjectOfType<DialogueManager>().dialogueText.text = inputSoFar;
    }

    public void add0()
    {
        if (index >= 4) return;
        input[index] = 0;
        index++;
        drawX();
    }

    public void add1()
    {
        if (index >= 4) return;
        input[index] = 1;
        index++;
        drawX();
    }

    public void add2()
    {
        if (index >= 4) return;
        input[index] = 2;
        index++;
        drawX();
    }

    public void add3()
    {
        if (index >= 4) return;
        input[index] = 3;
        index++;
        drawX();
    }

    public void add4()
    {
        if (index >= 4) return;
        input[index] = 4;
        index++;
        drawX();
    }

    public void add5()
    {
        if (index >= 4) return;
        input[index] = 5;
        index++;
        drawX();
    }

    public void add6()
    {
        if (index >= 4) return;
        input[index] = 6;
        index++;
        drawX();
    }

    public void add7()
    {
        if (index >= 4) return;
        input[index] = 7;
        index++;
        drawX();
    }

    public void add8()
    {
        if (index >= 4) return;
        input[index] = 8;
        index++;
        drawX();
    }

    public void add9()
    {
        if (index >= 4) return;
        input[index] = 9;
        index++;
        drawX();
    }

}
