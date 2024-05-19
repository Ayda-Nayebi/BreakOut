using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Clamp Function
// input: 10 -> Clamp(0,5) -> outout: 5
// input: -2 -> Clamp(0,5) -> outout: 0
// input: 3 -> Clamp(0,5) -> outout: 3


// Vector2 (x,y) 
// exmple1: x=3, y=4 -> length: radical(3*3+4*4)=5
// exmple2: x=6, y=8 -> length: 10
// Clamp Velocity Length (10) up tp max 5 ?

public class BallController : MonoBehaviour
{
    public static BallController Instance;
    public float speed = 10f;

    [HideInInspector] public SpriteRenderer spriteRenderer;

    [SerializeField] private float minY = -5.5f;
    
    [SerializeField] private Color mainColor;
    [SerializeField] private Color otherColor;


    private static BallController MainBall;

    private Rigidbody2D rigidbody2D;
    private Transform initialPoint;
    private AudioSource hitSFX;

    private void Awake()
    {
        Instance = this;

        CheckMainBall();
        FindComponent();
        ResetBallPosition();
    }
    

    private void FixedUpdate()
    {
        SetLimitVelocity();

        CheckBallFall();
    }
    private void FindComponent()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        hitSFX = GetComponent<AudioSource>();
  

        initialPoint = GameObject.FindGameObjectWithTag("Initial Point").GetComponent<Transform>();
    }

    private void CheckMainBall()
    {
        if (MainBall == null)
        {
            MainBall = this;

            spriteRenderer.color = mainColor;
        }

        else
        {
            spriteRenderer.color = otherColor;
        }

    }

    private void SetLimitVelocity()
    {
        rigidbody2D.velocity = rigidbody2D.velocity.normalized * speed;
    }

    private void CheckBallFall()
    {
       
        if (transform.position.y >= minY)
            return;

        if (MainBall == this)
        {
            LifeManager.Instance.LoseLife();

            ResetBallPosition();
        }

        else 
        {
            Destroy(gameObject);
        }
    }

    private void ResetBallPosition()
    {
        transform.position = initialPoint.position;
        rigidbody2D.velocity = Vector2.down * speed;
        //rigidbody2D.simulated = false;
    }
   
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            BrickController brickController = collision.gameObject.GetComponent<BrickController>();

            brickController.BreakMe();
            hitSFX.Play();
        }

      //  if (collision.gameObject.CompareTag("Paddle"))
     //   {
     //   }
    }

   
}

