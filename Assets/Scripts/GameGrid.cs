using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameGrid : MonoBehaviour {

    public GameObject block;

    public int rows;
    public int cols;

    private Block[][] blocks;

	public void Initialize () {
        //Setting grid size
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 10 * (cols + 2));
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 10 * (rows + 2));

        //Initializing grid matrix
        blocks = new Block[rows + 2][];
        for (int i = 0; i < rows + 2; i++)
        {
            blocks[i] = new Block[cols + 2];
        }

        //Initializing grid blocks
        for (int i = 0; i < rows + 2; i++)
        {
            for (int j = 0; j < cols + 2; j++)
            {
                Block curr = ((GameObject) Instantiate(block, this.transform)).GetComponent<Block>();
                if ( i == 0 || i == rows + 1 || j == 0 || j == cols + 1)
                {
                    curr.SetBlock(true);
                }
                blocks[i][j] = curr;
            }
        }
    }

    public bool HasBlockAtPos(int x, int y)
    {
        return blocks[y][x].IsBlock();
    }

    public bool HasPowerUpAtPos(int x, int y)
    {
        return blocks[y][x].IsPowerUp();
    }

    public void SetBlockAtPost(int x, int y)
    {
        blocks[y][x].SetBlock(true);
    }

    public void RemoveBlockAtPost(int x, int y)
    {
        blocks[y][x].SetBlock(false);
    }

    public void GeneratePowerUp()
    {
        int y = Random.Range(1, rows);
        int x = Random.Range(1, cols);
        Debug.Log("Generating powerUp at:" + x + "," + y);
        blocks[y][x].SetPowerUp();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
