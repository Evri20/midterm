using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonManager : MonoBehaviour
{
    public Canvas startCanvas;
    public Canvas cardCanvas;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void StartGame()
    {
       
        StartCoroutine("playerCard");
    
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator playerCard()
    {
        startCanvas.enabled = false;
        yield return new WaitForSeconds(2f);
        cardCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
       
    }


}
