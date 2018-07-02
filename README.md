# Tic_Tac_Toe
3*3 井字棋小游戏

## 核心算法（位操作）
当然算法不止这一种，本算法是基于《C#6.0本质论》一书中讲解的算法在 Unity 中的实现。写此小游戏是为了总结此书 1~3 章的内容。

### 位置选择  

    public void OnButtonClick()
    {
        if (isSelect)
        {
            GameView.instance.ShowTips("已被选...");
            return;
        }

        isSelect = true;
        GameManager.instance.SetPostion(playerPos);

        //贴图
        image.material = GameView.instance.GetMaterial(GameManager.instance.player);

        //判断游戏是否结束
        if (GameManager.instance.GameOver(playerPos))
        {
            GameView.instance.ShowTipsAllTimes("游戏结束\n恭喜 " + GameManager.instance.player.ToString() +" 获胜！！！");
            return;
        }

        //更换玩家
        GameManager.instance.player = (GameManager.instance.player == Player.O)
            ? GameManager.instance.player = Player.X
            : Player.O;

        GameView.instance.SetPlayer(GameManager.instance.player);
    }

### 记录玩家已选的位置

    private int postionX; //记录 X 玩家已选择的位置
    private int postionO; //记录 O 玩家已选择的位置
    public void SetPostion( int _position)
    {
        //每次玩家选择的位置
        int position = 1 << _position;

        //判断是哪个玩家选择了该位置
        if (player == Player.O)
        {
            //通过 |= 操作来记录玩家所有选择的位置 （0 为未选择 ， 1 位已选择）
            postionO |= position;
        }
        else
        {
            postionX |= position;
        }
    }

### 判断游戏结束

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

### Texture
![图片](https://github.com/Lenzan/Tic_Tac_Toe/blob/master/Texture/1.jpg)

![图片](https://github.com/Lenzan/Tic_Tac_Toe/blob/master/Texture/1.jpg)

![图片](https://github.com/Lenzan/Tic_Tac_Toe/blob/master/Texture/1.jpg)

![图片](https://github.com/Lenzan/Tic_Tac_Toe/blob/master/Texture/1.jpg)

![图片](https://github.com/Lenzan/Tic_Tac_Toe/blob/master/Texture/1.jpg)

