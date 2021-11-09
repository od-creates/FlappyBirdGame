using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_UI_Manager : MonoBehaviour
{
    
    


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void m_startgame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void m_quitgame()
    {
        Application.Quit();
    }

    public void m_scoreboard()
    {
        SceneManager.LoadScene("Score");
    }

    public void m_pause()
    {
        Time.timeScale = 0;
    }

    public void m_play()
    {
        Time.timeScale = 1;
    }

    public void m_startscene()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void m_howtoplay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    
}
