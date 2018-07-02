using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Player
{
    X,
    O,
    None
}

public class GameManager : MonoBehaviour
{
    public Player player;
    
    public static GameManager instance;

    private int[] winningMasks = {7, 56, 448, 73, 146, 292, 84, 273};

    private bool isOver = false;
    private int postionX;
    private int postionO;
    // Use this for initialization
    void Awake ()
	{
	    instance = this;
    }
  
    void Start()
    {
        GameView.instance.SetPlayer(player);
    }

    public bool GameOver(int _playerPos)
    {
        foreach (int mask in winningMasks)
        {
            if ((mask & postionX) == mask)
            {
                isOver = true;
                break;
            }
            else if ((mask & postionO) == mask)
            {
                isOver = true;
                break;
            }
        }
        if (!GameView.instance.items.Any(item => item.IsSelect == false))
        {
            isOver = false;
            GameView.instance.ShowTipsAllTimes("平局");
        }

        return isOver;
    }

    public void SetPostion( int _position)
    {
        int position = 1 << _position;

        if (player == Player.O)
        {
            postionO |= position;
        }
        else
        {
            postionX |= position;
        }
        
    }

    public void Reset()
    {
        postionO = 0;
        postionX = 0;
        isOver = false;
    }
	
}
