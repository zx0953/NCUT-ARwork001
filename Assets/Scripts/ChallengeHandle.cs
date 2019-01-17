using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChallengeHandle : MonoBehaviour
{
    int TextCount = 0;

    public Button BtnLeft;
    public Button BtnRight;
    public Button BtnUp;
    public Button BtnDown;
    public Button BtnBig;
    public Button BtnSmall;
    public Button BtnBack;
    public Button BtnOK;
    public Button BtnC1;
    public Button BtnC2;
    public Button BtnC3;
    public Button BtnNext;

    public GameObject C1;
    public GameObject C2;
    public GameObject C3;
    private GameObject CC;

    public GameObject Post;
    public GameObject panel2;
    public GameObject BtnCho;
    public GameObject BtnPlay;
    public Text Pass;
    public Text passtell;

    // Start is called before the first frame update
    void Start()
    {
        BtnBack.onClick.AddListener(BtnBackOnClick);
        BtnBig.onClick.AddListener(BtnBigOnClick);
        BtnDown.onClick.AddListener(BtnDownOnClick);
        BtnLeft.onClick.AddListener(BtnLeftOnClick);
        BtnRight.onClick.AddListener(BtnRigthOnClick);
        BtnSmall.onClick.AddListener(BtnSmallOnClick);
        BtnUp.onClick.AddListener(BtnUpOnClick);
        BtnOK.onClick.AddListener(BtnOKOnClick);
        BtnC1.onClick.AddListener(BtnC1OnClick);
        BtnC2.onClick.AddListener(BtnC2OnClick);
        BtnC3.onClick.AddListener(BtnC3OnClick);
        BtnNext.onClick.AddListener(BtnNextOnClick);
        Pass.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Pass.text == "阿瑞大人是宇宙最強")
        {
            BtnCho.SetActive(false);
            panel2.SetActive(true);
        }

    }
    void BtnLeftOnClick()
    {        
        CC.transform.Rotate(0, 15, 0);
        Debug.Log("BtnLeft onClick");       
        
    }
    void BtnRigthOnClick()
    {
        CC.transform.Rotate(0, -15, 0);
    }
    void BtnUpOnClick()
    {
        CC.transform.Rotate(15, 0, 0);
    }
    void BtnDownOnClick()
    {
        CC.transform.Rotate(-15, 0, 0);
    }
    void BtnBigOnClick()
    {
        Vector3 vec3 = CC.transform.localScale;
        vec3.x += 0.1f;
        vec3.y += 0.1f;
        vec3.z += 0.1f;
        CC.transform.localScale = vec3;
    }
    void BtnSmallOnClick()
    {
        Vector3 vec3 = CC.transform.localScale;
        vec3.x -= 0.1f;
        vec3.y -= 0.1f;
        vec3.z -= 0.1f;
        CC.transform.localScale = vec3;
    }
    void BtnBackOnClick()
    {
        BtnPlay.SetActive(false);
        C1.SetActive(false);
        C2.SetActive(false);
        C3.SetActive(false);
        BtnCho.SetActive(true);
    }
    void BtnOKOnClick()
    {
        Post.SetActive(false);
        BtnCho.SetActive(true);
    }
    void BtnC1OnClick() {
        CC = C1;
        BtnCho.SetActive(false);
        BtnPlay.SetActive(true);
        C1.SetActive(true);
        C2.SetActive(false);
        C3.SetActive(false);
        
    }
    void BtnC2OnClick()
    {
        CC = C2;
        BtnCho.SetActive(false);
        BtnPlay.SetActive(true);
        C2.SetActive(true);
        C1.SetActive(false);
        C3.SetActive(false);

    }
    void BtnC3OnClick()
    {
        CC = C3.transform.GetChild(0).gameObject;
        BtnCho.SetActive(false);
        BtnPlay.SetActive(true);
        C3.SetActive(true);
        C1.SetActive(false);
        C2.SetActive(false);
    }
    void BtnNextOnClick()
    {
        if (TextCount == 1)
        {
            SceneManager.LoadScene("IDKScene", LoadSceneMode.Single);
        }
        if (TextCount == 0)
        {
            passtell.text = "不愧是世界之王後補\n那麼就接下反應力挑戰吧!!";
            TextCount++;
        }
        
    }
}
