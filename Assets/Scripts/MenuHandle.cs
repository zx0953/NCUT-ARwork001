using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandle : MonoBehaviour {
    public Button BtnStart;
    public Button BtnExit;
    public Button BtnOK;
    public Button BtnNo;

    public GameObject panel;
    public Text post;
    public GameObject Menu;

    // Use this for initialization
    void Start () {
        BtnStart.onClick.AddListener(BtnStartOnClick);
        BtnExit.onClick.AddListener(BtnExitOnClick);
        BtnOK.onClick.AddListener(BtnOKOnClick);
        BtnNo.onClick.AddListener(BtnNoOnClick);
       

       
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    void BtnStartOnClick()
    {
        Debug.Log("BtnStartOnClick");
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
    void BtnExitOnClick()
    {
        Debug.Log("BtnExitOnClick");
        Application.Quit();
    }
    void BtnOKOnClick()
    {
        panel.SetActive(false);
        Menu.SetActive(true);
    }
    void BtnNoOnClick()
    {
        post.text = "這是無法拒絕的挑戰!!\n除非你關掉我\n上吧! 少女(年)";
    }
}
