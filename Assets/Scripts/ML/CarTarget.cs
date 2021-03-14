using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTarget : MonoBehaviour
{
    public float forceMulitplier = 10;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.AddForce(Vector2.down * forceMulitplier);
    }

	public void Reset()
	{
        transform.localPosition = new Vector2(Random.Range(-60.0f, 60.0f), 0);
        rb.velocity = Vector2.zero;
    }
}
