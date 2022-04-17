using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    private GameManager gameManager;
    private int a;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, Random.Range(-3, 4), 1);
        SwithShape();
    }
    private void Update()
    {
        gameObject.transform.position=new Vector3(gameObject.transform.position.x - (gameManager.scrollSpeed), gameObject.transform.position.y, 1);

        if(gameObject.transform.position.x<-12f)
        {
            gameObject.transform.position = new Vector2(14, Random.Range(-3, 4));
            SwithShape();
        }
    }

    private void SwithShape()
    {
        int rand = Random.Range(0, 5);

        switch (rand)
        {
            case 0:
                gameObject.transform.localScale = new Vector2(2, 4);
                break;
            case 1:
                gameObject.transform.localScale = new Vector2(1, 5);
                break;
            case 2:
                gameObject.transform.localScale = new Vector2(3, 3);
                break;
            case 3:
                gameObject.transform.localScale = new Vector2(4, 2);
                break;
        }
    }
}
