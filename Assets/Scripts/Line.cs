using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public float speed = 2f;
    float bound = 9;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        SpawnManager turnPos = FindObjectOfType<SpawnManager>();
        if (turnPos.turnPos)
        {
            transform.Translate(Vector3.down * GameManager.Instance.gameSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.up * GameManager.Instance.gameSpeed * Time.deltaTime);
        }
        

        if (transform.position.y > bound || transform.position.y < -bound)
        {
            Destroy(gameObject);
        }

        if (GameManager.Instance.isDead)
        {
            Destroy(gameObject);
        }
    }
}
