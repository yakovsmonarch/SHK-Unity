using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 Target;

    private void Start()
    {
        Target = Random.insideUnitCircle * 4;
    }


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, 2 * Time.deltaTime);
        if (transform.position == Target)
            Target = Random.insideUnitCircle * 4    ;
    }
}
