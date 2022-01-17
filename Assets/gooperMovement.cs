using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gooperMovement : MonoBehaviour
{
    movement a;
    float border;
    float direction;
    float gooperSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        border = transform.position.x;
        a = FindObjectOfType<movement>();
        float random = Random.Range(1, 3);
        direction = random;
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
            transform.position += new Vector3(gooperSpeed, 0, 0) * Time.deltaTime;
        }
        else
            transform.position += new Vector3(-gooperSpeed, 0, 0) * Time.deltaTime;

        if (transform.position.x < border - 2 || transform.position.x > border + 2)
        {
            gooperSpeed = -gooperSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
