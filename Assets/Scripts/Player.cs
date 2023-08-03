using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float bound = 2.4f;
    float horizontalInput;
    Vector2 movement;
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.isDead)
        {
            return;
        }
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
    private void LateUpdate()
    {
        OutOfBound();
    }
    void PlayerMove()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        movement.x = horizontalInput;
    }
    void OutOfBound()
    {
        if (transform.position.x >= bound)
        {
            transform.position = new Vector3(bound, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -bound)
        {
            transform.position = new Vector3(-bound, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BlueLine") && horizontalInput == 0) // mau xanh player phai chuyen dong
        {
            GetHit();
        }

        if (collision.gameObject.CompareTag("RedLine") && horizontalInput != 0) // mau do player phai dung yen
        {
            GetHit();
        }

        if (collision.gameObject.CompareTag("GreyLine"))
        {
            GetHit();      
        }
    }
    void GetHit()
    {
        GameManager.Instance.healthPoint--;
        if (GameManager.Instance.healthPoint == 0)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.death);
            AudioManager.Instance.musicSource.Stop();
        }
        AudioManager.Instance.PlaySFX(AudioManager.Instance.hit);

        StartCoroutine(IFrame());
    }
    IEnumerator IFrame()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        anim.enabled = true;

        yield return new WaitForSeconds(3f);

        Physics2D.IgnoreLayerCollision(6, 7, false);
        anim.enabled = false;
    }
}
