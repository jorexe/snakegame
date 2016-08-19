using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SnakeController : MonoBehaviour {

    public enum Direction {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    public float speed = 1;
    public int headX = 5;
    public int headY = 5;
    public int snakeSize = 0;

    public Direction currentDirection;

    public GameGrid gameGrid;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        gameGrid.Initialize();
        gameGrid.SetBlockAtPost(headX, headY);
        gameGrid.GeneratePowerUp();
        StartCoroutine("move");
	}
	
	// Update is called once per frame
	void Update () {
        updateDirection();
	}

    private void updateDirection() {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        if (hor > 0) {
            currentDirection = Direction.RIGHT;
        }
        else if (hor < 0) {
            currentDirection = Direction.LEFT;
        }
        else if (ver > 0) {
            currentDirection = Direction.UP;
        }
        else if (ver < 0) {
            currentDirection = Direction.DOWN;
        }
    }

    private IEnumerator move()
    {
        while(true)
        {
            gameGrid.RemoveBlockAtPost(headX, headY);
            switch (currentDirection)
            {
                case Direction.UP:
                    headY--;
                    break;
                case Direction.DOWN:
                    headY++;
                    break;
                case Direction.LEFT:
                    headX--;
                    break;
                case Direction.RIGHT:
                    headX++;
                    break;
            }
            if (gameGrid.HasPowerUpAtPos(headX, headY))
            {
                increaseScore();
                gameGrid.GeneratePowerUp();
            } else if (gameGrid.HasBlockAtPos(headX, headY))
            {
                Debug.Log("You Lose!! Points:" + snakeSize);
                yield break;
            }
            gameGrid.SetBlockAtPost(headX, headY);
            yield return new WaitForSeconds(1/speed);
        }
    }

    private void increaseScore()
    {
        snakeSize++;
        scoreText.text = "Score: " + snakeSize;
    }
}
