using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private float cloudMinMaxPosition = 10f;
    public bool isCloud = false;
    public float Speed = 1f;
    private float realSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        realSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * realSpeed * Time.deltaTime;
        if (isCloud)
        {
            
            if (transform.position.x <= -cloudMinMaxPosition)
            {
                var rng = Random.Range(-1f, 1f);
                transform.position = new Vector3(cloudMinMaxPosition, Random.Range(1f, 4f), 0);
                realSpeed = Speed + rng;
                transform.localScale = Vector3.one + new Vector3(rng/3, rng/3);
            }
        }
        else
        {
            if (transform.position.x < -18)
            {
                transform.position = new Vector2(34.9f, -2.582948f);
            }
        }
    }
}
