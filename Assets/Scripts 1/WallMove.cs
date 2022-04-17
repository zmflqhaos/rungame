using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private int pase;

    private void Start()
    {
        RandomPosition();
    }

    void Update()
    {
        if (transform.position.x >= 14)
        {
            RandomShape();
        }
        transform.Translate(Vector2.left*Time.deltaTime*speed);
        if(transform.position.x<-14)
        {
            RandomPosition();
        }
    }

    private void RandomPosition()
    {
        transform.position = new Vector2(14, Random.Range(-2, 5));
    }

    private void RandomShape()
    {
        pase = Random.Range(0, 5);
        transform.localScale = pase switch
        {
            0 => new Vector3(3, 3, 1),
            1 => new Vector3(2, 4, 1),
            2 => new Vector3(4, 2, 1),
            3 => new Vector3(1, 5, 1),
            4 => new Vector3(5, 1, 1),
            _ => new Vector3(1, 1, 1),
        };
    }
}
