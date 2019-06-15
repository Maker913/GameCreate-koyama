using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public GameObject onePlay;
    public GameObject twoPlay;
    private void Awake()
    {
        
    }
    public void OnePlay()
    {
        SceneManager.LoadScene("CPUGame");
    }
    public void TwoPlay()
    {
        //SceneManagement.Instance.TwoPlay();
        SceneManager.LoadScene("MainGame");
    }
}
