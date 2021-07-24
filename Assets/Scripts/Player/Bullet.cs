using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float maxDistance;

    private void Start()
    {
        firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // bullet is destroyed if it is far away from the fire point
        if (Vector3.Distance(firePoint.position, transform.position) > maxDistance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collider2D>().CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
