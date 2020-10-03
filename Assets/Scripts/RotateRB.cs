using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RotateRB : MonoBehaviour
{
    [SerializeField] Vector3 rotation = Vector3.zero;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float speedChange = (Input.GetKey(KeyCode.UpArrow) ? -1 : 0) + (Input.GetKey(KeyCode.DownArrow) ? 1 : 0);
        speedChange *= Time.deltaTime * 25f;
        rotation.y = Mathf.Clamp(rotation.y + speedChange, -90f, 90f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation * Time.deltaTime));
    }
}
