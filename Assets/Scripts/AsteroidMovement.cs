using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float destroyDistance;
    private Vector2 screenBounds;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void FixedUpdate()
    {
        MovingAsteroid(Vector2.right);

        if (transform.position.x > screenBounds.x * destroyDistance)
        {
            Destroy(this.gameObject);
        }
    }

    private void MovingAsteroid(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
