using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public static int totalBrokenBricks = 0;

    public BallController ballPrefab;
    public Sprite specialSprite;
    public Sprite doubleBallSprite;
    public Sprite lifeSprite;
    public Sprite scoreLoseSprite;
    public Sprite liveBrick;

    [HideInInspector] public bool IsSpecial = false;
    [HideInInspector] public bool IsDouble = false;
    [HideInInspector] public bool IsLife = false;
    [HideInInspector] public bool isScoreLose = false;
    [HideInInspector] public bool isBrickLive = false;

    [SerializeField] private float specialRaduis;

    private static int id = 0;

    private SpriteRenderer spriteRenderer;
    private LayerMask brickLayer;
    private int scoreLosePerBrick = 10;
    private int scorePerBreak = 10; 
    private int specialScore = 20;
    private int brickLive = 2;
   


    private void Awake()
    {
        SetIDToBricks();
        FindComponents();
     
    }

    private void FindComponents()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
    }
  
    private void SetIDToBricks()
    {
        gameObject.name = "Brick" + id;
        id++;

    }

    public void SetGradiant(float gradiant)
    {
        // spriteRenderer.color = Gradient.Evaluate(gradiant);
    }

    public void SpecialMe()
    {
        spriteRenderer.sprite = specialSprite;
        scorePerBreak = specialScore;

        IsSpecial = true;
    }

    public void LifeMe()
    {
        spriteRenderer.sprite = lifeSprite;

        IsLife = true;
    }

    public void DoubleBallMe()
    {
        spriteRenderer.sprite = doubleBallSprite;

        IsDouble = true;
    }

    public void LoseScoreMe()
    {
        spriteRenderer.sprite = scoreLoseSprite;
        scorePerBreak -= scoreLosePerBrick;
       
        isScoreLose = true;
    }

    public void LifeBrickMe()
    {

        spriteRenderer.sprite = liveBrick;
        scorePerBreak -= scoreLosePerBrick;
        isBrickLive = true;
    } 

    private void OnDrawGizmos()
    {
        if (IsSpecial) 
        {
            Gizmos.DrawWireSphere(transform.position, specialRaduis);
        }
    }

    public void BreakMe() 
    {
      
        if (IsDouble)
        {
            Instantiate(ballPrefab);
        }

        if (IsLife)
        {
            LifeManager.Instance.AddLife();
        }

        if (IsSpecial) 
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, specialRaduis, brickLayer);

            foreach (Collider2D colider in colliders)
                Destroy(colider.gameObject);
        }
     
        if (isBrickLive && brickLive==2)
        {
            brickLive--;  
        }
        else
        {
            Destroy(gameObject);

            totalBrokenBricks++;

            ScoreManager.Instance.AddScore(scorePerBreak);

            GameManager.Instance.CheckWin();
        }
        
    }

    
}
