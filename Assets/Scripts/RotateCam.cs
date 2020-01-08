using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    public float radius = 2f;
    public float height = 2f;
    private Vector3 hVector;

    Vector3[] poses;
    private int posIdx = 0;

    void Start()
    {
        poses = new Vector3[]
        {
            new Vector3(0, 0, -radius),
            new Vector3(radius, 0, 0),
            new Vector3(0, 0, radius),
            new Vector3(-radius, 0, 0)
        };

        hVector = new Vector3(0, height, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q)) posIdx++;
        if (Input.GetKeyDown(KeyCode.E)) posIdx--;

        if (posIdx > 3) posIdx = 0;
        if (posIdx < 0) posIdx = 3;

        Vector3 offset = transform.position - target.position;
        offset.y = 0;
        Vector3 temp = poses[posIdx];
        offset = Vector3.Slerp(offset, temp, 0.1f);
        transform.position = offset + target.position + hVector;
        transform.LookAt(target.position);
    }
}
