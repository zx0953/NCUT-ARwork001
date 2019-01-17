using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAudioHandle : MonoBehaviour
{

    public GameObject MenuBGM;
    private AudioSource m_BGM;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        m_BGM = MenuBGM.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("IDKScene") ||
            SceneManager.GetActiveScene() == SceneManager.GetSceneByName("tryScene") 
           )
        {
            m_BGM.Pause();
        }

        else 
        {
            m_BGM.UnPause();
        }
    }
}
