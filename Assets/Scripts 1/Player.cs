using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float jumpPower;
    private Rigidbody2D rigid;
    private RaycastHit2D ray_wall;
    private RaycastHit2D ray_floor;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&ray_floor.collider!=null)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        ray_floor = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Map"));
        Jump();
    }
}
