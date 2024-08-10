using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Transform target;
    private pointsManager pointsManager;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        pointsManager = GameObject.FindWithTag("pointsManager").GetComponent<pointsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    // void onDestroy() not working
    // {
    //     pointsManager.AddPoints(10);
    // }
}
