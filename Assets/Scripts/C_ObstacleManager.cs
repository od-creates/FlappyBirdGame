using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ObstacleManager : MonoBehaviour
{
    public GameObject obsa, obsb, obsc;
    public float obsStartPosX,obsspeed,spawninterval;
    GameObject[] obsarray;
    GameObject obscopy;
    int startflag;
    float lastspawntime,starttime;
    // Start is called before the first frame update
    void Start()
    {
        lastspawntime = 0;
        starttime = Time.time;
        startflag = 1;
        m_storeObstacles();
        //score = GameObject.Find("UIManager").transform.Find("ScoreBoard").GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnObstacles();
    }

    void m_storeObstacles()
    {
        obsarray = new GameObject[3];
        /*obsarray[0] = obsa;
        obsarray[0].SetActive(false);
        obsarray[1] = obsb;
        obsarray[2] = obsc;*/
        
        
        obsarray[0] = obsa;
       
        obsarray[1] = obsb;
        
        obsarray[2] = obsc;


        //obsarray[0].SetActive(false);
        //print("start");
    }

    void m_spawnObstacles()
    {
        
        if((Time.time-lastspawntime>=spawninterval && lastspawntime!=0)|| (Time.time-starttime>=4.7 && startflag!=0))
        {
            //obscopy.SetActive(true);
            //obscopy=obsarray[0];
            obscopy = Instantiate(obsarray[Random.Range(0, 3)]);
            obscopy.transform.position = new Vector3(obsStartPosX, obscopy.transform.position.y,0);
            obscopy.GetComponent<C_Obstacle>().obstaclespeed = obsspeed;
            lastspawntime = Time.time;
            startflag = 0;
            //print("hi");
            
        }

       

    }

    

}
