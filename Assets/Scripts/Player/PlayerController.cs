using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float lookSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 mousePosition;
    [Header("Shooting")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Rotate();
            Move();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Rotate()
    {
        //Get the mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0);

        //Rotate the sprite to the mouse point
        Vector3 diff = mousePos - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    public void Move()
    {
        //Move the sprite towards the mouse
        transform.position += transform.up * moveSpeed * Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject a = Instantiate(bullet, firePoint.position, firePoint.rotation) as GameObject;
        a.transform.SetParent(GameObject.Find("Clones").transform);
    }

}
