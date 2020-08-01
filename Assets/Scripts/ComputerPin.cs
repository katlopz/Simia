using UnityEngine;
using UnityEngine.UI;

public class ComputerPin : MonoBehaviour
{
    private int[] input = new int[4];

    private int code1 = 2;
    private int code2 = 5;
    private int code3 = 2;
    private int code4 = 6;

    private int index = 0;
    private bool correct = false;

    private Image reportScreen;

    private void Start()
    {
        reportScreen = this.transform.Find("reportScreen").GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
            add0();
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
            add1();
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
            add2();
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
            add3();
        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
            add4();
        if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
            add5();
        if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
            add6();
        if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
            add7();
        if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
            add8();
        if (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
            add9();

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            confirm();

        if(!correct) displayText("");
    }

    public void confirm()
    {
        if (input[0] == code1 && input[1] == code2 && input[2] == code3 && input[3] == code4)
        {
            correct = true;
            // should show next screen of M.Key going through monkey metamorphasis 
            //reportScreen.enabled = true;
            displayText("Subject: Monty Key\r\nMetamophasis rate: 32%\r\nEstimated time to completion: 18 hrs");

            GameObject.Find("Kid(Clone)").GetComponent<KidInteract>().knowsSubjectIdentity();
        }
        else
        {
            // clear computer
            clear();
        }
    }

    public void clear()
    {
        index = 0;
        for (int i = 0; i < index; i++) input[i] = -1;
        displayText("");
    }

    public void displayText(string s)
    {
        Text other = GetComponentInChildren<Text>();

        if (s.Equals(""))
        {
            string inputSoFar = "ENTER 4-DIGIT PIN: ";
            for (int i = 0; i < index; i++) inputSoFar += "X ";
            inputSoFar += "_";

            other.text = inputSoFar;
        }
        else
        {
            other.text = s;
        }

        
    }

    public void add0()
    {
        if (index >= 4) return;
        input[index] = 0;
        index++;
    }

    public void add1()
    {
        if (index >= 4) return;
        input[index] = 1;
        index++;
    }

    public void add2()
    {
        if (index >= 4) return;
        input[index] = 2;
        index++;
    }

    public void add3()
    {
        if (index >= 4) return;
        input[index] = 3;
        index++;
    }

    public void add4()
    {
        if (index >= 4) return;
        input[index] = 4;
        index++;
    }

    public void add5()
    {
        if (index >= 4) return;
        input[index] = 5;
        index++;
    }

    public void add6()
    {
        if (index >= 4) return;
        input[index] = 6;
        index++;
    }

    public void add7()
    {
        if (index >= 4) return;
        input[index] = 7;
        index++;
    }

    public void add8()
    {
        if (index >= 4) return;
        input[index] = 8;
        index++;
    }

    public void add9()
    {
        if (index >= 4) return;
        input[index] = 9;
        index++;
    }

}
