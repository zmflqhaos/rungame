using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float jumpower;
    private Rigidbody2D rigid;
    private RaycastHit2D ray_wall;
    private RaycastHit2D ray_floor;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ray_wall = Physics2D.Raycast(transform.position, Vector2.right, 0.7f, LayerMask.GetMask("Wall"));
        ray_floor = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, LayerMask.GetMask("Map"));
        if(ray_wall.collider!=null)
        {
            Debug.Log("충돌하였습니다!");
        }
        Jump();
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&ray_floor.collider!=null)
        {
            rigid.AddForce(Vector2.up * jumpower, ForceMode2D.Impulse);
        }
    }
}
