using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject bombPrefab;
    public GameObject kickPart;
    public float kickForce;

    private Vector3 direction;
    private List<GameObject> bombInSight = new List<GameObject>();

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        GetComponent<Rigidbody2D>().velocity = new Vector2(h, v) * speed;

        MoveKick();

        if (Input.GetMouseButtonDown(0))
        {
            Kick();
        }
        if (Input.GetMouseButtonDown(1))
        {
            PlantBomb();
        }
    }

    void PlantBomb()
    {
        Instantiate(bombPrefab, transform.position + 2f * direction.normalized, Quaternion.identity);
    }

    void Kick()
    {
        foreach(GameObject bomb in bombInSight)
        {
            bomb.GetComponent<Rigidbody2D>().AddForce(direction.normalized * kickForce);
        }
    }

    void MoveKick()
    {
        kickPart.transform.eulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, direction));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bomb")
        {
            bombInSight.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bombInSight.Remove(collision.gameObject);
    }
}
