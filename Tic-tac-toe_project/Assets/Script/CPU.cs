using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class Your
{
    public Image panel;
    public Text text;
}
public class YourColor
{
    public Color panelColor;
    public Color textColor;
}

public class CPU : MonoBehaviour
{
    public Text[] ButtonList;
    public GameObject Panel;
    public Text WinText;
    public GameObject restartButton;
    public GameObject TitleButton;
    private Button button;
    private Text buttonText;
    private int NumberOfMoves;
    private string PlayerSides;
    private void Awake()
    {
        SetGameControllerReferenceOnButton();
        PlayerSides = "X";
        Panel.SetActive(false);
        NumberOfMoves = 0;
        restartButton.SetActive(false);
        TitleButton.SetActive(false);
    }
    //
    private void SetGameControllerReferenceOnButton()
    {
        for (int i = 0; i < ButtonList.Length; i++)
        {
            ButtonList[i].GetComponentInParent<Buttons>()
             .SetGameControllerReferences(this);
        }
    }
    //
    public string GetPlayerSide()
    {
        return PlayerSides;
    }
    //駒を置いた後3つ並んでいるか確認
    public void TurnEnd()
    {
        NumberOfMoves++;
        if (//横軸のチェック
            (ButtonList[0].text == PlayerSides && ButtonList[1].text == PlayerSides && ButtonList[2].text == PlayerSides) ||
            (ButtonList[3].text == PlayerSides && ButtonList[4].text == PlayerSides && ButtonList[5].text == PlayerSides) ||
            (ButtonList[6].text == PlayerSides && ButtonList[7].text == PlayerSides && ButtonList[8].text == PlayerSides)
            ) { GameOver(PlayerSides); return; }
        if (//縦軸のチェック
            (ButtonList[0].text == PlayerSides && ButtonList[3].text == PlayerSides && ButtonList[6].text == PlayerSides) ||
            (ButtonList[1].text == PlayerSides && ButtonList[4].text == PlayerSides && ButtonList[7].text == PlayerSides) ||
            (ButtonList[2].text == PlayerSides && ButtonList[5].text == PlayerSides && ButtonList[8].text == PlayerSides)
            ) { GameOver(PlayerSides); return; }
        if (//斜め軸のチェック
            (ButtonList[0].text == PlayerSides && ButtonList[4].text == PlayerSides && ButtonList[8].text == PlayerSides) ||
            (ButtonList[2].text == PlayerSides && ButtonList[4].text == PlayerSides && ButtonList[6].text == PlayerSides)
            ) { GameOver(PlayerSides); return; }
        //揃っていない
        if (NumberOfMoves == 9)//引き分け
        {
            GameOver(null);
        }
        else//ターンチェンジ
        {
            ChangeSides();
        }
    }
    //ターンの切り替え処理
    private void ChangeSides()
    {
        PlayerSides = (PlayerSides == "X") ? "〇" : "X";

        if (PlayerSides != "X")
        {
            //button.enabled = false;//CPUが置き終わるまで何も置かせない
            CPUSet();
        }
    }
    private void CPUSet()
    {
        /*
        if (ButtonList[4] == null)
        {
            Debug.Log("呼んだ？");
            ExecuteEvents.Execute
                (target: button.gameObject,
                 eventData: new PointerEventData(EventSystem.current),
                 functor:ExecuteEvents.pointerClickHandler
                 );
        }
        //button.interactable = false;
        button.enabled = true;//プレイヤーの操作解禁*/
        TurnEnd();
    }
    //ゲームオーバー時の勝敗判定
    private void GameOver(string winner)
    {
        SetBoardInteractable(false);
        if (winner == null) SetGameOverText("引き分け");
        else SetGameOverText(winner + "の勝ち");
        restartButton.SetActive(true);
        TitleButton.SetActive(true);
    }  
    //ゲームオーバー時のテキスト
    private void SetGameOverText(string value)
    {
        Panel.SetActive(true);
        WinText.text = value;
    }

    //リセット後のボタンを押せるようにする
    private void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < ButtonList.Length; i++)
        {
            ButtonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
    //再試合準備
    public void Restart()
    {
        PlayerSides = "X";
        NumberOfMoves = 0;
        Panel.SetActive(false);
        TitleButton.SetActive(false);
        restartButton.SetActive(false);
        SetBoardInteractable(true);
        for (int i = 0; i < ButtonList.Length; i++)
        {
            ButtonList[i].text = "";
        }
    }
    //タイトルに戻る
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
}
