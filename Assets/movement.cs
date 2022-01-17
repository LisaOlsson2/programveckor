using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    KeyCode left;

    [SerializeField]
    KeyCode left2;

    [SerializeField]
    KeyCode right;

    [SerializeField]
    KeyCode right2;

    [SerializeField]
    KeyCode up;

    [SerializeField]
    KeyCode up2;

    [SerializeField]
    KeyCode shoot;

    Rigidbody2D rb;

    [SerializeField]
    private GameObject gooper;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject enemy;

    float gooped = 0;

    public int death = 0;

    float deathTimer;

    float gooperSpawnerTimer;

    float bulletSpawnerTimer;

    float enemySpawnerTimer;

    public int direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (death == 0)
        {
            gooperSpawnerTimer += Time.deltaTime;
            bulletSpawnerTimer += Time.deltaTime;
            enemySpawnerTimer += Time.deltaTime;

            if (gooperSpawnerTimer > 5)
            {
                int random = Random.Range(1, 8);
                if (random == 1)
                {
                    Instantiate(gooper, new Vector3(-5, -3, 0), Quaternion.identity);
                }
                if (random == 2)
                {
                    Instantiate(gooper, new Vector3(4, -2, 0), Quaternion.identity);
                }
                if (random == 3)
                {
                    Instantiate(gooper, new Vector3(7, 1, 0), Quaternion.identity);
                }
                if (random == 4)
                {
                    Instantiate(gooper, new Vector3(-7, 3, 0), Quaternion.identity);
                }
                if (random == 5)
                {
                    Instantiate(gooper, new Vector3(-8, -1, 0), Quaternion.identity);
                }
                if (random == 6)
                {
                    Instantiate(gooper, new Vector3(0, 0, 0), Quaternion.identity);
                }
                if (random == 7)
                {
                    Instantiate(gooper, new Vector3(1, 3, 0), Quaternion.identity);
                }
                gooperSpawnerTimer = 0;
            }

            if (enemySpawnerTimer > 10)
            {
                int random = Random.Range(1, 8);
                if (random == 1)
                {
                    Instantiate(enemy, new Vector3(-5, -3, 0), Quaternion.identity);
                }
                if (random == 2)
                {
                    Instantiate(enemy, new Vector3(4, -2, 0), Quaternion.identity);
                }
                if (random == 3)
                {
                    Instantiate(enemy, new Vector3(7, 1, 0), Quaternion.identity);
                }
                if (random == 4)
                {
                    Instantiate(enemy, new Vector3(-7, 3, 0), Quaternion.identity);
                }
                if (random == 5)
                {
                    Instantiate(enemy, new Vector3(-8, -1, 0), Quaternion.identity);
                }
                if (random == 6)
                {
                    Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity);
                }
                if (random == 7)
                {
                    Instantiate(enemy, new Vector3(1, 3, 0), Quaternion.identity);
                }
                enemySpawnerTimer = 0;
            }

            if (bulletSpawnerTimer > 0.5)
            {
                if (Input.GetKey(shoot))
                {
                    if (direction == 1)
                    {
                        Instantiate(bullet, transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
                    }
                    if (direction == 2)
                    {
                        Instantiate(bullet, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                    }

                    if (direction == 3)
                    {
                        Instantiate(bullet, transform.position + new Vector3(0, -1, 0), Quaternion.identity);
                    }
                    bulletSpawnerTimer = 0;
                }
            }

            if (gooped > 0)
            {
                gooped -= Time.deltaTime;
            }

            if (transform.position.x < 11)
            {
                if (Input.GetKey(right) || Input.GetKey(right2))
                {
                    if (direction != 3)
                    {
                        direction = 2;
                    }
                    transform.position += new Vector3(5, 0, 0) * Time.deltaTime;
                }
            }
            if (transform.position.x > -11)
            {
                if (Input.GetKey(left) || Input.GetKey(left2))
                {
                    if (direction != 3)
                    {
                        direction = 1;
                    }
                    transform.position += new Vector3(-5, 0, 0) * Time.deltaTime;
                }
            }
        }
        if (death == 1)
        {
            deathTimer += Time.deltaTime;
            if (deathTimer > 5)
            {
                death = 0;
                deathTimer = 0;
            }
        }
        if (transform.position.y < -6 || transform.position.y > 6)
        {
            gooped = 0;
            death = 1;
            bulletSpawnerTimer = 0;
            enemySpawnerTimer = 0;
            gooperSpawnerTimer = 0;
            transform.position = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (death == 0)
        {
            if (collision.gameObject.tag == "ground")
            {
                if (Input.GetKey(up) || Input.GetKey(up2))
                {
                    if (gooped <= 0)
                    {
                        rb.AddForce(transform.up * 4, ForceMode2D.Impulse);
                    }
                    else
                        rb.AddForce(transform.up * 2, ForceMode2D.Impulse);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "gooper")
        {
            gooped = 10;
        }

        if (collision.gameObject.tag == "enemy")
        {
            gooped = 0;
            death = 1;
            bulletSpawnerTimer = 0;
            enemySpawnerTimer = 0;
            gooperSpawnerTimer = 0;
            transform.position = new Vector3(0, 0, 0);
        }

        if (collision.gameObject.tag == "ground")
        {
            direction = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            direction = 3;
        }
    }
}