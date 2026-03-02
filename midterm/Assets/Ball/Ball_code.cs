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

    private bool canHit = true;
    // Start is called before the first frame update
    void Awake()
    {
        dir = Random.Range(-1, 1);

        ball = GetComponent<Rigidbody2D>();
        if (dir < 0)
        {
            randomDirection = new Vector2(Random.Range(-0.2f, -1f), Random.Range(-1f, 1f));
            randomDirection.Normalize();
            ball.linearVelocity = randomDirection * bounceForce * speed;
        }else
        {
            randomDirection = new Vector2(Random.Range(0.2f, 1f), Random.Range(-1f, 1f));
            randomDirection.Normalize();
            ball.linearVelocity = randomDirection * bounceForce * speed;
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.tag);
        if (collision.transform.tag == "walls" && canHit)
        {
           randomDirection *= new Vector2(1, -1);
            ball.linearVelocity = randomDirection * bounceForce * speed;
            randomDirection.Normalize();
            StartCoroutine(HitCooldown());
        }

        if (collision.collider.CompareTag("bodyZone") && canHit)
        {
            Debug.Log("hit");
            randomDirection *= new Vector2(-1, 1);
            ball.linearVelocity = randomDirection * bounceForce * speed;
            randomDirection.Normalize();
            StartCoroutine(HitCooldown());
        }

        if ((collision.collider.CompareTag("topZone") || collision.collider.CompareTag("bottomZone")) && canHit)
        {
            Debug.Log("hittop");
            randomDirection *= new Vector2(1, -1);
            ball.linearVelocity = randomDirection * bounceForce * speed;
            randomDirection.Normalize();
            StartCoroutine(HitCooldown());
        }
        
    
    }

    

    IEnumerator HitCooldown()
    {
        canHit = false;
        yield return new WaitForSeconds(0.05f);
        canHit = true;
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
