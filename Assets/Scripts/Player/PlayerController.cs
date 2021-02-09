using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float RollSpeed;

	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

    private void Update()
    {
		Vector3 input = Input.acceleration;

		input = (Quaternion.Euler(90, 0, 0) * input) * RollSpeed;

        rb.AddForce(input, ForceMode.Acceleration);
    }
}
