using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSize : MonoBehaviour
{
    //起動時の画面サイズを640*480にする
    static void Size()
    {
        Screen.SetResolution(640, 480, false, 60);
    }
}
