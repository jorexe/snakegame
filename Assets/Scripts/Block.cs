using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Block : MonoBehaviour {

    public Color blockColor;
    public Color emptyColor;

    private bool isBlock = false;
    private bool isPowerUp = false;

	public void SetBlock(bool isBlock)
    {
        this.isBlock = isBlock;
        this.isPowerUp = false;
        updateColor();
    }

    public void SetPowerUp()
    {
        isPowerUp = true;
        isBlock = false;
        updateColor();
    }

    private void updateColor()
    {
        RawImage image = GetComponent<RawImage>();
        if (isBlock || isPowerUp)
        {
            image.color = blockColor;
        }
        else
        {
            image.color = emptyColor;
        }
    }

    public bool IsBlock()
    {
        return isBlock;
    }

    public bool IsPowerUp()
    {
        return isPowerUp;
    }
}
