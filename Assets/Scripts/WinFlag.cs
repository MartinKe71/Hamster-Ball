using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlag : MonoBehaviour
{
    private MeshRenderer meshRand;
    private ParticleSystem effect;
    private bool saved = false;

    // Start is called before the first frame update
    void Start()
    {
        meshRand = GetComponent<MeshRenderer>();
        meshRand.material.color = Color.red;

        effect = GetComponent<ParticleSystem>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!saved)
        {
            meshRand.material.color = Color.green;
            effect.Play();
            other.GetComponent<PlayManager>().OnWinFlag();
            saved = true;
        }
    }
}
