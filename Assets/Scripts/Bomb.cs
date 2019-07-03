using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject fragPrefab;
    public float timer;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > timer)
        {
            Detonate();
        }
    }

    public void Detonate()
    {
        Instantiate(fragPrefab, transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(fragPrefab, transform.position, Quaternion.Euler(0, 0, 90));
        Instantiate(fragPrefab, transform.position, Quaternion.Euler(0, 0, 180));
        Instantiate(fragPrefab, transform.position, Quaternion.Euler(0, 0, 270));
        Destroy(gameObject);
    }
}
