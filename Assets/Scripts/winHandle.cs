using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winHandle : MonoBehaviour
{
    int c = 0;
    public GameObject panel1;
    public GameObject panel2;
    public Button BtnOK;
    public Button BtnHappy;
    public Button BtnExit;

    // Use this for initialization
    void Start()
    {
        BtnOK.onClick.AddListener(BtnOKOnClick);
        BtnHappy.onClick.AddListener(BtnHappyOnClick);
        BtnExit.onClick.AddListener(BtnExitOnClick);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void BtnOKOnClick()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
    void BtnHappyOnClick()
    { 
        if(c % 2 == 0) { BtnHappy.GetComponentInChildren<Text>().text = "(*´∀`)~♥"; }
        if(c % 2 == 1) { BtnHappy.GetComponentInChildren<Text>().text = "(´•ω•)♡"; }
        c++;
    }
    void BtnExitOnClick()
    {
        Application.Quit();
    }
}