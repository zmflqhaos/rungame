using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer sprite;
    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private int HP;
    [SerializeField]
    private Text hp;
    [SerializeField]
    private Text gameOver;
    [SerializeField]
    private Text score;


    private float point = 0;
    private bool canJump;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        hp.text = string.Format("HP : {0}", HP);
        gameOver.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(HP>0)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                canJump = false;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.125f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.localScale = new Vector2(1, 0.25f);
                rigid.velocity = new Vector2(0, -jumpPower * 1.5f);
            }
            else
            {
                gameObject.transform.localScale = new Vector2(0.5f, 0.5f);
            }
            if (rigid.velocity.y > jumpPower)
            {
                rigid.velocity = new Vector2(0, jumpPower);
            }
            score.text = string.Format("Score : {0}", (int)(point * 10));
            point += Time.deltaTime;
        }
        else
        {
            gameOver.gameObject.SetActive(true);
            gameOver.text = string.Format("Game Over\nScore : {0}", (int)(point*10));
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Object")
        {
            StartCoroutine(Hit());
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        canJump = true;
    }

    private IEnumerator Hit()
    {
        HP--;
        hp.text = string.Format("HP : {0}", HP);
        for (int i = 0; i < 3; i++)
        {
            sprite.color = new Color(1, 1, 1, 0.3f);
            yield return new WaitForSeconds(0.15f);
            sprite.color = new Color(1, 1, 1, 1f);
            yield return new WaitForSeconds(0.15f);
        }
    }
}
