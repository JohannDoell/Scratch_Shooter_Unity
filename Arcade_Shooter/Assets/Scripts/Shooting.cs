using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private Transform firepoint;
    [SerializeField]
    private GameObject bulletPrefab;

    Vector2 mousePos;

    public float bulletForce = 20f;

    [SerializeField]
    private float timer;
    [SerializeField]
    private float maxTimer;

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate() {

        if (Input.GetButton("Fire1")) {
            timer -= 1f;
            if (timer < 0) {
                Shoot();
                timer = maxTimer;
            }
        } else {
            timer = maxTimer;
        }

        Vector2 firepoint2D = new Vector2(firepoint.position.x, firepoint.position.y);
        Vector2 lookDir = mousePos - firepoint2D;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
