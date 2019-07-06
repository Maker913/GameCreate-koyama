using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Button button;
    public Text buttonText;
    private Board board;
    private CPU cpu;
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
    public void SetGameControllerReference(CPU cpus)
    {
        cpu = cpus;
    }
    public void SetCPUSpace()
    {
        buttonText.text = cpu.GetPlayerSide();
        button.interactable = false;
        cpu.TurnEnd();
    }
}
