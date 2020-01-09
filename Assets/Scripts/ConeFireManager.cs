using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeFireManager : MonoBehaviour
{
    [SerializeField] float shootRange;
    [SerializeField] float repeatTime;
    [SerializeField] Rigidbody bullet;
    [SerializeField] Transform target;

    private Rigidbody fire;
    private Vector3 forward;
    private Vector3 currentAngle;
    private Quaternion currentRotation;

    private void Start()
    {
        InvokeRepeating("Fire", 0.0f, repeatTime);
    }

    void Fire()
    {
        if (Vector3.Distance(target.position, transform.position) <= shootRange)
        {
            transform.LookAt(target);
            currentAngle = new Vector3(0, 90, 0) + transform.rotation.eulerAngles;
            currentRotation = Quaternion.Euler(currentAngle);
            transform.rotation = currentRotation;

            forward = target.position - transform.position;
            fire = Instantiate(bullet, transform.position + forward * 0.05f, currentRotation);
            fire.velocity = forward * 3;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootRange);
    }

}
