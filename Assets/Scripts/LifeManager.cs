using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance;

    public LifeUI lifePrefab;

   
    [SerializeField]private int MaxLife = 10;

    private int PlayerLife;
    private LifeUI[] liveUI;
    private Transform liveContainer;


    private void Awake()
    {
        Instance = this;

          liveContainer = GameObject.FindGameObjectWithTag("Live Container").GetComponent<Transform>();

        CreateLives();
     
    }

    public void InitializeLife()
    {
        PlayerLife = MaxLife;
    }

    public void CreateLives()
    {
        liveUI = new LifeUI[MaxLife];

        for (int i = 0; i < MaxLife; i++)
        {
            LifeUI newLife = Instantiate(lifePrefab, liveContainer);
            liveUI[i] = newLife;
        }
    }

    public void LoseLife()
    {
        if (PlayerLife == 0)
        {
            print("Invalid LoseLife");
            return;
        }

        PlayerLife--;

        DecreaseLifeUI();

        if (PlayerLife == 0)
            GameManager.Instance.GameOver();
    }

    public void AddLife()
    {
        if (PlayerLife == MaxLife)
        {
            print("Invalid AddLife");
            return;
        }

        PlayerLife++;

        IncreaseLifeUI();
    }


    public void DecreaseLifeUI()
    {
        for (int i = MaxLife - 1; i >= 0; i--)
        {
            if (liveUI[i].IsFull())
            {
                liveUI[i].ShowAsEmpty();
                break;
            }
        }
    }

    public void IncreaseLifeUI()
    {
        for (int i = 0; i < 10; i++)
        {
            if (!liveUI[i].IsFull())
            {
                liveUI[i].ShowAsFull();
                break;
            }
        }
    }


}
