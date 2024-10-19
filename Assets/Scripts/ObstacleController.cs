using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour //-2.1 -1.91 -1.5 0 
{
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
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
