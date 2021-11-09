using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_UI_GamePlay : MonoBehaviour
{
    public GameObject g_bird,g_getready,g_platform,g_title,g_gameover;
    public float countertime;
    public Text countdowntext,scoreboardtext;
    float starttime,count3,count2,count1;
    int tapflag,pausecheck;
    AudioSource timermusic;
    //igidbody2D rb_bird;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        g_gameover.SetActive(false);
        starttime = Time.time;
        count1 = 0;
        count2 = 0;
        count3 = 0;
        g_getready.SetActive(true);
        countdowntext.enabled = false;
        scoreboardtext.enabled = false;
        g_bird.GetComponent<C_BirdMovement>().enabled = false;
        tapflag = 0;
        timermusic = GetComponent<AudioSource>();
        pausecheck = 0;
        
        
        
        //rb_bird.GetComponent<Rigidbody2D>();

        //g_getready = this.transform.GetChild(0).Find("GameStart").Find("GetReady").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        m_getready();
        m_checkPauseOrPlay();
    }

    public void m_taparea()
    {
        if(tapflag==1)
        {
            g_bird.GetComponent<C_BirdMovement>().m_birdmovement();
        }
        
    }

    void m_getready()
    {
        if(Time.time-starttime>=countertime && count3==0)
        {
            g_getready.SetActive(false);
            countdowntext.enabled = true;
            countdowntext.text = "3";
            count3 = Time.time;
            timermusic.Play();

        }

        if(Time.time-count3>=1 && count2==0 && count3!=0)
        {
            countdowntext.text = "2";
            count2 = Time.time;
        }

        if(Time.time-count2>=1 && count1==0 && count2!=0)
        {
            countdowntext.text = "1";
            count1 = Time.time;
        }

        if (Time.time - count1 >= 1 && count1!=0)
        {
            countdowntext.enabled = false;
            g_bird.GetComponent<C_BirdMovement>().enabled = true;
            g_platform.GetComponent<Animator>().SetBool("plat_move", true);
            g_title.SetActive(false);
            tapflag = 1;
            scoreboardtext.enabled=true;
            timermusic.Stop();
            
        }
    }

    void m_checkPauseOrPlay()
    {
        if (Time.timeScale == 0 )
        {
            timermusic.Stop();
            pausecheck = 1;
        }
        else if (Time.timeScale == 1 && pausecheck == 1)
        {
            timermusic.Play();
            pausecheck = 0;
        }
    }
}
