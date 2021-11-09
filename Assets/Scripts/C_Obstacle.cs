using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_Obstacle : MonoBehaviour
{
    public float obstaclespeed;
    //Text score;
    // Start is called before the first frame update
    void Start()
    {
       
       
        
    }

    // Update is called once per frame
    void Update()
    {
        m_move();
        
    }

    void m_move()
    {
        this.transform.Translate(Vector3.left * obstaclespeed * Time.deltaTime);

        if (this.transform.position.x < -4)
        {
            Destroy(this.gameObject);
        }
        
    }

    

    
}
