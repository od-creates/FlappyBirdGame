using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class C_BirdMovement : MonoBehaviour
{
    public float upwardforce,grav,minclampX,maxclampX,minclampY,maxclampY;
    public AudioClip gameplaymusic, gameovermusic, scoremusic;
    int tap, gameovercheck,pausecheck;
    public static int totalcurrentscore;
    public Text scoreboard;
    public GameObject g_gameover,g_pauseplay;
    float clampx, clampy;
    //Rigidbody2D rb_bird;
    //Vector2 bird_pos;
    // Start is called before the first frame update

    AudioSource birdaudio;
    void Start()
    {
        totalcurrentscore = 0;
        tap = 1;
        birdaudio = GetComponent<AudioSource>();
        birdaudio.clip = gameplaymusic;
        birdaudio.loop = true;
        birdaudio.Play();
        gameovercheck = 0;
        pausecheck = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        m_applygrav();
        //m_applyClamp();
        m_checkGameOver();
        m_checkPauseOrPlay();
    }

    
    void m_applygrav()
    {
       
        this.transform.Translate(Vector3.down * grav* Time.deltaTime);
    }
    
    public void m_birdmovement()
    {
        if(tap==1)
        {
            this.transform.Translate(Vector3.up * upwardforce );
        }
        
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        totalcurrentscore++;
        scoreboard.text = "" + totalcurrentscore;
        
        birdaudio.PlayOneShot(scoremusic);
        //g_gamescoreui.GetComponent<C_UI_Manager>().currentscore = score;
       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        g_gameover.SetActive(true);
        Time.timeScale = 0;
        tap = 0;
        g_pauseplay.SetActive(false);
        birdaudio.Stop();
        birdaudio.PlayOneShot(gameovermusic);
        gameovercheck = 1;
    }

    void m_applyClamp()
    {
        clampx = Mathf.Clamp(transform.position.x, minclampX, maxclampX);//clamp x
        clampy = Mathf.Clamp(transform.position.y, minclampY, maxclampY);//clamp z

        transform.position = new Vector2(clampx, clampy);//apply clamp
    }

    void m_checkGameOver()
    {
        if(transform.position.y<minclampY && gameovercheck==0)//if bird falls on ground
        {
            g_gameover.SetActive(true);
            Time.timeScale = 0;
            tap = 0;
            g_pauseplay.SetActive(false);
            birdaudio.Stop();
            birdaudio.PlayOneShot(gameovermusic);
            gameovercheck = 1;
        }
    }

    void m_checkPauseOrPlay()
    {
        if(Time.timeScale==0 && gameovercheck == 0)
        {
            birdaudio.Stop();
            pausecheck = 1;
        }
        else if(Time.timeScale == 1 && pausecheck==1)
        {
            birdaudio.clip = gameplaymusic;
            birdaudio.loop = true;
            birdaudio.Play();
            pausecheck = 0;
        }
    }
}
