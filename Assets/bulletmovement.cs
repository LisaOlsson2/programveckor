using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletmovement : MonoBehaviour
{
    float bulletspeed = 7;
    movement a;
    int direction;

    // Start is called before the first frame update
    void Start()
    {
        a = FindObjectOfType<movement>();
        direction = a.direction;
    }

    // Update is called once per frame
    void Update()
    {
        if (a.death == 1)
        {
            Destroy(gameObject);
        }

        if (direction == 1)
        {
            transform.position += new Vector3(-bulletspeed, 0, 0) * Time.deltaTime;
        }
        if (direction == 2)
        {
            transform.position += new Vector3(bulletspeed, 0, 0) * Time.deltaTime;
        }
        if (direction == 3)
        {
            transform.position += new Vector3(0, -bulletspeed, 0) * Time.deltaTime;
        }

        if (transform.position.x > 11)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -11)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
