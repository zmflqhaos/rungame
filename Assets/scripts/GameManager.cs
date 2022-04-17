using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float scrollSpeed;

    private void Start()
    {
        StartCoroutine(SpeedUp());   
    }

    private IEnumerator SpeedUp()
    {
        while(true)
        {
            scrollSpeed += 0.005f;
            yield return new WaitForSeconds(10f);
        }
    }
}
