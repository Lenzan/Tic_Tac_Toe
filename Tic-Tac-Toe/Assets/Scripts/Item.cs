using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private Button itemButton;
    private Image image;
    private bool isSelect = false;
    public int playerPos;
    public bool IsSelect
    {
        get { return isSelect; }
    }
	// Use this for initialization
	void Start ()
	{
	    image = transform.GetChild(0).GetComponent<Image>();
	    itemButton = GetComponent<Button>();
        itemButton.onClick.AddListener(OnButtonClick);
	}

    void OnButtonClick()
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

    public void Reset()
    {
        image.material = null;
        isSelect = false;
        GameManager.instance.Reset();
    }
   
}
