using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class gameManager : MonoBehaviour
{
    
    //variables
    public static gameManager instance;
    
    public TextMeshProUGUI p1score;
    public int p1_num;


    public TextMeshProUGUI p2score;
    public int p2_num;
    public Canvas scoreCanvas;
    
    
    
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
        scoreCanvas.enabled = true;
        p1score.enabled = true;
        p2score.enabled = true;
        p1_num = 0;
        p2_num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        p1score.text = "Max Score: " + p1_num;
        p2score.text = "Charles Score: " + p2_num;
    
        if (p1_num == 10)
        {
            SceneManager.LoadScene(2);   
            scoreCanvas.enabled = false;
            p1score.enabled = false;
            p2score.enabled = false; 
            p1_num = 0;
            p2_num = 0; 
        }
            
        if (p2_num == 10)
        {
            SceneManager.LoadScene(3);
            p1score.enabled = false;
            p2score.enabled = false;  
            scoreCanvas.enabled = false;  
            p1_num = 0;
            p2_num = 0;
        }

    }
    private void OnEnable()
    {
    SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
    SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1) // your game scene
        {
            scoreCanvas = GameObject.Find("Score Canvas").GetComponent<Canvas>();
            p1score = GameObject.Find("p1score").GetComponent<TextMeshProUGUI>();
            p2score = GameObject.Find("p2score").GetComponent<TextMeshProUGUI>();

            scoreCanvas.enabled = true;
            p1score.enabled = true;
            p2score.enabled = true;
        }
    }
}
