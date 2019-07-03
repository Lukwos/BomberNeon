using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject fragPrefab;
    public float timer;
    public int numberOfFrags;
    public Gradient color;

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
        if (time > timer)
        {
            Detonate();
        }
        GetComponent<SpriteRenderer>().color = color.Evaluate(time / timer);
    }

    public void Detonate()
    {
        for (int i = 0; i < numberOfFrags; i++)
        {
            float angle = 360.0f * i / numberOfFrags;
            Instantiate(fragPrefab, transform.position, Quaternion.Euler(0, 0, angle));
        }
        Destroy(gameObject);
    }
}
