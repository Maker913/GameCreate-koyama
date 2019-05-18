using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Board : MonoBehaviour
{
    public Text[] ButtonList;
    private int NumberOfMoves;
    private string PlayerSide;
    private void Awake()
    {
        PlayerSide = "X";
    }
    private string GetPlayerSide()
    {
        return PlayerSide;
    }
    //3つ並んでいたら終了
    private void TurnEnd()
    {
        if(//横軸のチェック
            (ButtonList[0].text == PlayerSide && ButtonList[1].text == PlayerSide && ButtonList[2].text == PlayerSide)||
            (ButtonList[3].text == PlayerSide && ButtonList[4].text == PlayerSide && ButtonList[5].text == PlayerSide)||
            (ButtonList[6].text == PlayerSide && ButtonList[7].text == PlayerSide && ButtonList[8].text == PlayerSide)
            ){ GameOver(PlayerSide);return; }
        if(//縦軸のチェック
            (ButtonList[0].text == PlayerSide && ButtonList[3].text == PlayerSide && ButtonList[6].text == PlayerSide) ||
            (ButtonList[1].text == PlayerSide && ButtonList[4].text == PlayerSide && ButtonList[7].text == PlayerSide) ||
            (ButtonList[2].text == PlayerSide && ButtonList[5].text == PlayerSide && ButtonList[8].text == PlayerSide)
            ){ GameOver(PlayerSide); return; }
        if (//斜め軸のチェック
            (ButtonList[0].text == PlayerSide && ButtonList[4].text == PlayerSide && ButtonList[8].text == PlayerSide) ||
            (ButtonList[2].text == PlayerSide && ButtonList[4].text == PlayerSide && ButtonList[6].text == PlayerSide)
            ) { GameOver(PlayerSide); return; }
        //揃っていない
        if(NumberOfMoves == 9)
        {
            GameOver(null);//引き分け
        }
        else//ターンチェンジ
        {
            ChangeSides();
        }
    }
    private void ChangeSides()
    {
        PlayerSide = (PlayerSide == "X") ? "〇" : "X";
    }
    private void GameOver(string Winner)
    {
        if (Winner == null) SetGameOverText("引き分け");
    }
    private void SetGameOverText(string value)
    {

    }
    private void Restart()
    {
        PlayerSide = "X";
        NumberOfMoves = 0;
    }
}
