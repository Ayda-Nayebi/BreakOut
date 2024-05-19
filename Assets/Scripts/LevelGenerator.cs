using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;
    public Vector2Int size;
    public Vector2 offset;

    public BrickController brickPrefab;

    public int specialBricksCount = 10;

    public int doubleBallBricksCount = 10;

    public int lifeBricksCount = 10;

    public int loseScoreBriksCount = 10;

    public int brickLiveCount = 10;

    public int bricksCount;

    private void Awake()
    {
        Instance = this;
        FixBricksCount();

        GenerateLevel();

        
    }

    private void FixBricksCount()
    {
        bricksCount = size.x * size.y;

        if (specialBricksCount > bricksCount)
            specialBricksCount = bricksCount;

        if (doubleBallBricksCount > bricksCount - specialBricksCount)
            doubleBallBricksCount = bricksCount - specialBricksCount;

        if (lifeBricksCount > bricksCount - specialBricksCount - doubleBallBricksCount)
            lifeBricksCount = bricksCount - specialBricksCount - doubleBallBricksCount;

        if (loseScoreBriksCount > bricksCount - doubleBallBricksCount - lifeBricksCount)
            loseScoreBriksCount = bricksCount - doubleBallBricksCount - loseScoreBriksCount;

        if (brickLiveCount > bricksCount - specialBricksCount - doubleBallBricksCount - lifeBricksCount - loseScoreBriksCount)
            brickLiveCount = bricksCount - specialBricksCount - doubleBallBricksCount - lifeBricksCount - loseScoreBriksCount;

    }

    private void GenerateLevel()
    {
        CreateBreaks();
    }

    private void CreateBreaks()
    {
        List<BrickController> bricks = new List<BrickController>();

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                BrickController newbrick = Instantiate(brickPrefab, transform);
                newbrick.transform.position = transform.position + new Vector3((float)((size.x - 1) * .5f - i) * offset.x, j * offset.y, 0);
                newbrick.SetGradiant((float)j / (size.y - 1));

                bricks.Add(newbrick);
            }
        }

        MakeSpecialBricks(bricks);
        MakeDoubleBallBrick(bricks);
        MakeLifeBricks(bricks);
        MakeLoseScoreBricks(bricks);
        MakeLiveBricks(bricks);
    }


    private void MakeSpecialBricks(List<BrickController> bricks)
    {
        int counter = specialBricksCount;

        while (counter > 0)
        {
            int randomIndex = Random.Range(0, bricks.Count);

            if (bricks[randomIndex].IsSpecial == true)
            {
                continue;
            }

            bricks[randomIndex].SpecialMe();

            counter--;
        }
    }


    private void MakeDoubleBallBrick(List<BrickController> bricks)
    {
        int counter = doubleBallBricksCount;

        while (counter > 0)
        {
            int randomIndex = Random.Range(0, bricks.Count);

            if (bricks[randomIndex].IsSpecial == true)
            {
                continue;
            }

            if (bricks[randomIndex].IsDouble == true)
            {
                continue;
            }

            bricks[randomIndex].DoubleBallMe();

            counter--;
        }
    }

    private void MakeLifeBricks(List<BrickController> bricks)
    {
        int counter = lifeBricksCount;

        while (counter > 0)
        {
            int randomIndex = Random.Range(0, bricks.Count);

            if (bricks[randomIndex].IsSpecial == true)
            {
                continue;
            }

            if (bricks[randomIndex].IsDouble == true)
            {
                continue;
            }

            if (bricks[randomIndex].IsLife == true)
            {
                continue;
            }

            bricks[randomIndex].LifeMe();

            counter--;
        }
    }

    private void MakeLoseScoreBricks(List<BrickController> bricks)
    {
        int counter = loseScoreBriksCount;

        while (counter > 0)
        {
            int randomIndex = Random.Range(0, bricks.Count);

            if (bricks[randomIndex].IsSpecial == true)
            {
                continue;
            }

            if (bricks[randomIndex].IsDouble == true)
            {
                continue;
            }

            if (bricks[randomIndex].IsLife == true)
            {
                continue;
            }
            if (bricks[randomIndex].isScoreLose == true)
            {
                continue;
            }

            bricks[randomIndex].LoseScoreMe();
            counter--;
        }

    }

    private void MakeLiveBricks(List<BrickController> bricks)
    {
        int counter = brickLiveCount;
        while (counter > 0)
        {
            int randomIndex = Random.Range(0, bricks.Count);

            if (bricks[randomIndex].IsSpecial == true)
            {
                continue;
            }

            if (bricks[randomIndex].IsDouble == true)
            {
                continue;
            }

            if (bricks[randomIndex].IsLife == true)
            {
                continue;
            }
            if (bricks[randomIndex].isScoreLose == true)
            {
                continue;
            }

            if (bricks[randomIndex].isBrickLive == true)
            {
                continue;
            }
            bricks[randomIndex].LifeBrickMe();
            counter--;
        }
    }
}
    

