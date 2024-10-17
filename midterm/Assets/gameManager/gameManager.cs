using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class gameManager : MonoBehaviour
{
    
    //variables
    public static gameManager instance;
    
    public TextMeshProUGUI p1score;
    public int p1_num;


    public TextMeshProUGUI p2score;
    public int p2_num;
    
    
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this; 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        p1_num = 0;
        p1score.text = "P1 Score: " + p1_num;
        p2_num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        p1score.text = "P1 Score: " + p1_num;
        p2score.text = "P2 Score: " + p2_num;
    }
}
