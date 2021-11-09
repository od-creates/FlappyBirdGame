using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_ScoreManager : MonoBehaviour
{

    public GameObject bronze,silver,gold,platinum;
    public Text currentscore;
    public AudioClip clapmusic, startmusic;
    AudioSource music;
    int clapcheck;
    
    
    // Start is called before the first frame update
    void Start()
    {
        bronze.SetActive(false);
        silver.SetActive(false);
        gold.SetActive(false);
        platinum.SetActive(false);
        music = GetComponent<AudioSource>();
        clapcheck = 0;
        music.PlayOneShot(startmusic);
    }

    // Update is called once per frame
    void Update()
    {
        m_updatescoreAndMedal();
        
    }

    void m_updatescoreAndMedal()
    {
        
       currentscore.text=""+ C_BirdMovement.totalcurrentscore;

        if(C_BirdMovement.totalcurrentscore >= 10 && clapcheck==0)
        {
            music.Stop();
            music.PlayOneShot(clapmusic);
            clapcheck = 1;
        }
        else
        {

        }

       if(C_BirdMovement.totalcurrentscore >=10 && C_BirdMovement.totalcurrentscore<20)
        {
            bronze.SetActive(true);
        }
       else if(C_BirdMovement.totalcurrentscore >= 20 && C_BirdMovement.totalcurrentscore < 30)
        {
            bronze.SetActive(false);
            silver.SetActive(true);
        }
        else if (C_BirdMovement.totalcurrentscore >= 30 && C_BirdMovement.totalcurrentscore < 40)
        {
            silver.SetActive(false);
            gold.SetActive(true);
        }
        else if (C_BirdMovement.totalcurrentscore >= 40 )
        {
            gold.SetActive(false);
            platinum.SetActive(true);
        }
    }

    
}
