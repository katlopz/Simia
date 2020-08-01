using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    
    public static bool isJournalOn = false;

    public GameObject journalMenu;
    public int pageTotal;
    int pageNum = 0;
    bool bookStart = true;
    bool bookEnd = false;
    GameObject closedGui;
    GameObject openGui;

    void Start() 
    {
        closedGui = transform.GetChild(0).GetChild(8).gameObject;
        openGui = transform.GetChild(0).GetChild(9).gameObject;   
    }

    // Update is called once per frame
    void Update()
    {
        if(!isJournalOn && Input.GetKeyDown(KeyCode.Tab)){
            isJournalOn = true;
            openGui.SetActive(true);
            closedGui.SetActive(false);
            BringUpJournal();
        }
        else if(isJournalOn && Input.GetKeyDown(KeyCode.Tab)){
            isJournalOn = false;
            closedGui.SetActive(true);
            openGui.SetActive(false);
            PutDownJournal();
        }

        
        if(pageNum == 0)
            bookStart = true;
        else if(pageNum == pageTotal)
            bookEnd = true;
        else
        {
            bookStart = false;
            bookEnd = false;
        }
        
        if(isJournalOn)
        {
            if(isJournalOn && Input.GetKeyDown(KeyCode.RightArrow) && !bookEnd)
            {  
                journalMenu.transform.GetChild(pageNum).gameObject.SetActive(false);
                journalMenu.transform.GetChild(pageNum+1).gameObject.SetActive(true);
                pageNum++;
            }

            if(isJournalOn && Input.GetKeyDown(KeyCode.LeftArrow) && !bookStart)
            {  
                journalMenu.transform.GetChild(pageNum).gameObject.SetActive(false);
                journalMenu.transform.GetChild(pageNum-1).gameObject.SetActive(true);
                pageNum--;
            }
        }
    }

    public void BringUpJournal(){
        journalMenu.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void PutDownJournal(){
        journalMenu.SetActive(false);
        Time.timeScale = 1f;

    }
}
