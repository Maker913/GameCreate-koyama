using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Button button;
    public Text buttonText;
    private Board board;
    public void SetGameControllerReference(Board boards)
    {
        board = boards;
    }
    public void SetSpace()
    {
        buttonText.text = board.GetPlayerSide();
        button.interactable = false;
        board.TurnEnd();
    }
}
