using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_code : MonoBehaviour
{
    //variables
    private Rigidbody2D p2;
    public float speed = 3f;
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        p2 = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        
        if (Input.GetKey(KeyCode.UpArrow) && pos.y < 3.790095)
        {
            pos.y += speed * Time.deltaTime; 
        }

        if (Input.GetKey(KeyCode.DownArrow) && pos.y > -3.800095)
        {
            pos.y -= speed * Time.deltaTime;
        }


        transform.position = pos;

        


    }
}
