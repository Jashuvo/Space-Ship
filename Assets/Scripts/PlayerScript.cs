using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject[] enemys;
    public Rigidbody2D rigid;
    public GameObject bullet1;
    public Transform rightPos, leftPos;
    private int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("createEnemy",1f,3f);
        rigid = GetComponent<Rigidbody2D>();
        playerHealth = 5;
    }

    // Update is called once per frame
    void Update()
    {

        float H = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(H*2, 0);
        if (Input.GetMouseButtonDown(0))
        {
            shooting();
        }
        rigid.position = new Vector2(Mathf.Clamp(rigid.position.x, -1.85f, 1.85f), -4.03f);
        if (playerHealth < 1)
        {
            Destroy(gameObject);
        }

    }

    private void createEnemy() {

        float randomX = Random.Range(-1.22f, 1.23f);
        int randomIndex = Random.Range(0, 3);
        Instantiate(enemys[randomIndex], new Vector3(randomX, 6.28f,0), Quaternion.identity);
    }
    public void shooting()
    {
        Instantiate(bullet1, new Vector3(rightPos.transform.position.x,rightPos.transform.position.y,0), Quaternion.identity);
        Instantiate(bullet1, new Vector3(leftPos.transform.position.x, leftPos.transform.position.y, 0), Quaternion.identity);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "enemyBullet")
        {
            playerHealth--;
            Destroy(col.gameObject);
        }
    }
}
