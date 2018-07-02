using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    public static GameView instance;
    [SerializeField]
    private Material[] materials;
    private Text warning;
    private CanvasGroup canvasGroup;
    private Image playerImage;
    public List<Item> items;
    void Awake()
    {
        instance = this;
        warning = transform.Find("Warning").GetComponent<Text>();
        canvasGroup = warning.GetComponent<CanvasGroup>();
        playerImage = transform.Find("Player").GetComponent<Image>();
    }

    public void SetPlayer(Player player)
    {
        playerImage.material = GetMaterial(player);
    }

    public Material GetMaterial(Player player)
    {
        return player == Player.O ? materials[0] : materials[1];
    }


    #region Tips
    public void ShowTipsAllTimes(string msg)
    {
        warning.text = msg;
    }
    public void ShowTips(string msg)
    {
        StopAllCoroutines();
        StartCoroutine(Show(msg));
    }
    IEnumerator Show(string msg)
    {
        warning.text = msg;
        canvasGroup.alpha = 1;
        yield return new WaitForSeconds(2);
        while (canvasGroup.alpha > 0)
        {
            yield return new WaitForSeconds(0.02f);
            canvasGroup.alpha -= 0.02f;
        }
    }
    #endregion

    public void Reset()
    {
        warning.text = "";
        foreach (Item item in items)
        {
            item.Reset();
        }
    }
}
