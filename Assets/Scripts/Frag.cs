using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Frag : MonoBehaviour
{
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        Destroy(gameObject, 10);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.transform.tag;

        if (tag == "Player")
        {
            // Kill Player
            //collision.gameObject.GetComponent<Player>();
        }
        else if (tag == "Bomb")
        {
            // Detonate or Push Bomb
            collision.gameObject.GetComponent<Bomb>().Detonate();
        }
        else if (tag == "Brick")
        {
            // Destroy Brick
            var tilemap = collision.gameObject.GetComponent<Tilemap>();
            tilemap.SetTile(tilemap.WorldToCell(collision.contacts[0].point), null);
        }

        Destroy(gameObject, 0.3f);
    }
}
