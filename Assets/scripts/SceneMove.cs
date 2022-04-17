using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public void MoveMain()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void MoveTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void Escape()
    {
        Application.Quit();
    }
}
