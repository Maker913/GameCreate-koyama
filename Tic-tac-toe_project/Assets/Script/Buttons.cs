using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Button button;
    public Text buttonText;
    private Board board;
    private CPU CPU;
    public void SetGameControllerReference(Board boards)
    {
        board = boards;
    }
    public void SetGameControllerReferences(CPU cpu)
    {
        CPU = cpu;
    }
    public void SetSpace()
    {
        buttonText.text = board.GetPlayerSide();
        button.interactable = false;
        board.TurnEnd();
    }
    public void SetSpaceOne()
    {
        buttonText.text = CPU.GetPlayerSide();
        button.interactable = false;
        CPU.TurnEnd();
    }
}
