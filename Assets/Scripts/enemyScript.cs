using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    private Rigidbody2D enemyRigid;
    public int health;
    public Transform bulletPos;
    public GameObject enemyBullet;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
        InvokeRepeating("createShooting", 1f,2f);
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        enemyRigid.velocity = new Vector2(0,-0.5f);
        if(health < 1)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "bullet1")
        {
            health--;
            Destroy(col.gameObject);
        }
    }
    private void createShooting()
    {
        Instantiate(enemyBullet, new Vector3(bulletPos.transform.position.x, bulletPos.transform.position.y, 0), Quaternion.identity);
    }
}
