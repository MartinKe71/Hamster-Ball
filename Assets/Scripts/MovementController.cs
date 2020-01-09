using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update
    Transform cam;
    Rigidbody rb;

    Vector3 force;
    public float power;
    void Start()
    {
        cam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Mouse X");
        float v = Input.GetAxisRaw("Mouse Y");

        Vector3 forward = transform.position - cam.position;
        forward.y = 0;
        forward = forward.normalized;

        Vector3 right = Quaternion.Euler(0, 90, 0) * forward;

        force = forward * v + right * h;
    }

    public void ClearForce()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
    private void FixedUpdate()
    {
        rb.AddForce(force * power);
    }
}
