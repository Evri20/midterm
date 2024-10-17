using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ball_code : MonoBehaviour
{
    //variables
    private Rigidbody2D ball;
    public float speed = 5f;
    float bounceForce = 1;
    private Vector2 randomDirection;
    private Vector2 startPos;
    public GameObject bl;
    private int dir;
    // Start is called before the first frame update
    void Awake()
    {
        dir = Random.Range(-1, 1);

        ball = GetComponent<Rigidbody2D>();
        if (dir < 0)
        {
            randomDirection = new Vector2(Random.Range(-0.2f, -1f), Random.Range(-1f, 1f));
            randomDirection.Normalize();
            ball.velocity = randomDirection * bounceForce * speed;
        }else
        {
            randomDirection = new Vector2(Random.Range(0.2f, 1f), Random.Range(-1f, 1f));
            randomDirection.Normalize();
            ball.velocity = randomDirection * bounceForce * speed;
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "walls")
        {
           randomDirection *= new Vector2(1, -1);
            ball.velocity = randomDirection * bounceForce * speed;
            randomDirection.Normalize();
        }
        
        if (collision.transform.tag == "players")
        {
            randomDirection *= new Vector2(-1, 1);
            ball.velocity = randomDirection * bounceForce * speed;
            randomDirection.Normalize();
        }
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //points
        if (collision.transform.tag == "redWall")
        {
            gameManager.instance.p1_num ++;

            var pos = new Vector2(0, 0);
            Instantiate(bl, pos, Quaternion.identity);
            Destroy(this.gameObject);
        }


        if (collision.transform.tag == "blueWall")
        {
            gameManager.instance.p2_num ++;

            var pos = new Vector2(0, 0);
            Instantiate(bl, pos, Quaternion.identity);
            Destroy(this.gameObject);
        }














    }








}
