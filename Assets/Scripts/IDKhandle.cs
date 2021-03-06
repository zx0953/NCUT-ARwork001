﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IDKhandle : MonoBehaviour {
    float timer_f;
    int timer_i;
    int timer_c = 197;
    int Point = 0;
    int correct = 0;
    int incorrect = 0;
    int chance = 0;

    public GameObject announcement;
    public GameObject playBtn;
    public GameObject Audio;
    public GameObject pamel2;

    public Button BtnCube;
    public Button BtnSphere;
    public Button BtnTriangle;
    public Button BtnTemp;
    public Button BtnCheat;
    public Button a_BtnYes;
    public Button a_BtnNo;
    public Button BtnNext;

    public Text pointShow;
    public Text timeShow;
    public Text passTell;

    public GameObject PoolRoot = null;
    public GameObject DispRoot = null;

    AudioSource m_MyAudioSource;
    AudioClip clip;
    string[] SongPath = new string[2] { "Sounds/Invisible",
                                        "Sounds/Awakening" };

    private List<GameObject> ModelList = new List<GameObject>();
    private int CurrentPosition = 0; //目前model的位置

    bool play = false;
    bool cheat = false;
    

    // Use this for initialization
    void Start () {        
        a_BtnYes.onClick.AddListener(A_btnYesOnClick);
        a_BtnNo.onClick.AddListener(A_btnNoOnClick);
        BtnCube.onClick.AddListener(BtnCubeOnClick);
        BtnSphere.onClick.AddListener(BtnSphereOnClick);
        BtnTriangle.onClick.AddListener(BtnTriangleOnClick);
        BtnNext.onClick.AddListener(BtnNextOnClick);
        BtnCheat.onClick.AddListener(BtnCheatOnClick);
        m_MyAudioSource = Audio.GetComponent<AudioSource>();

        if (PoolRoot != null)
        {
            int childCount = PoolRoot.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                ModelList.Add(PoolRoot.transform.GetChild(i).gameObject);
            }
        }
        AudioControl();
    }
	
	// Update is called once per frame
	void Update () {
        int time_ne =1;
        if(Point >= 1000)
        {            
            pamel2.SetActive(true);
            play = false;
        }
        if(cheat == true){correct = 200;  incorrect = 20; time_ne = 20; }
        else { correct = 10; incorrect = -10; }
        
        if (play == true)
        {            
            timer_f += Time.deltaTime;
            timer_i = (int)timer_f;
            if(timer_i == 1)
            {
                timer_c = timer_c - time_ne;
                AutoChange();
                timer_f = 0.0f;
            }            
            pointShow.text = ""+ Point;
            timeShow.text = "" + timer_c;

            if(timer_c <= 0 && chance ==0)
            {
                chance = chance + 1;
                timer_c = 214;
                AudioControl();
            }
            if(timer_c <=0 && chance == 1)
            {
                SceneManager.LoadScene("tryScene", LoadSceneMode.Single);
            }
            
        }
        
    }
    private void Display()
    {
        foreach (GameObject g in ModelList)
        {
            g.transform.parent = PoolRoot.transform; //all reset
        }
        ModelList[CurrentPosition].transform.parent = DispRoot.transform; //瞬移
        //ModelList[CurrentPosition].transform.localPosition = Vector3.zero; //reset
    }

    void AutoChange()
    {
        int r =Random.Range(0,3);
        
        CurrentPosition = r;        
        Display();
    }

    void A_btnYesOnClick()
    {
        Debug.Log("a_btnYesOnClick");
        announcement.SetActive(false);
        playBtn.SetActive(true);
        play = true;
    }
    void A_btnNoOnClick()
    {
        Text text = announcement.transform.GetChild(0).GetComponent<Text>();
        text.text = "不用按了...\n就是給老子衝呀!!!";
    }
    void BtnCubeOnClick()
    {
        if (CurrentPosition == 2)
        {
            
            Point = Point + correct;            
            Debug.Log(Point);
            BtnTemp.transform.localPosition = BtnCube.transform.localPosition;
            BtnCube.transform.localPosition = BtnTriangle.transform.localPosition;
            BtnTriangle.transform.localPosition = BtnTemp.transform.localPosition;
        }
        else
        {
            Point = Point + incorrect;
            Debug.Log(Point);
        }
    }
    void BtnSphereOnClick()
    {
        if (CurrentPosition == 0)
        {
            
            Point = Point + correct;
            Debug.Log(Point);
            BtnTemp.transform.localPosition = BtnSphere.transform.localPosition;
            BtnSphere.transform.localPosition = BtnCube.transform.localPosition;
            BtnCube.transform.localPosition = BtnTemp.transform.localPosition;
        }
        else
        {
            Point = Point + incorrect;
            Debug.Log(Point);
        }
    }
    void BtnTriangleOnClick()
    {
        if (CurrentPosition == 1)
        {
            
            Point = Point + correct;
            Debug.Log(Point);
            BtnTemp.transform.localPosition = BtnTriangle.transform.localPosition;
            BtnTriangle.transform.localPosition = BtnSphere.transform.localPosition;
            BtnSphere.transform.localPosition = BtnTemp.transform.localPosition;
        }
        else
        {
            Point = Point + incorrect;
            Debug.Log(Point);
        }
    }
    void BtnCheatOnClick()
    {
        cheat = true;
    }
    void BtnNextOnClick()
    {
        if (Point < 2000) { Point = 2000; }
        if (Point >= 2002)
        {
            SceneManager.LoadScene("winScene", LoadSceneMode.Single);
        }
        if(Point == 2001)
        {
            passTell.text = "果然你就是世界之王了!!\n 那麼已經有資格覲見\n至高無上的神了\n走吧!! 王呀!!";
            Point++;
        }
        if(Point == 2000)
        {
            passTell.text = "什麼!? 居然沒走?!\n......\n這就是三大項測驗了";
            Point++;
        }
        
    }
    void AudioControl()
    {
        clip = Resources.Load<AudioClip>(SongPath[chance]);
        m_MyAudioSource.clip = clip;
        m_MyAudioSource.Play();
    }
}
