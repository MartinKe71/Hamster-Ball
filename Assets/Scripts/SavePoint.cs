using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    //public GameObject text;

    private MeshRenderer meshRand;
    private ParticleSystem effect;
    private bool saved = false;

    // Start is called before the first frame update
    void Start()
    {
        meshRand = GetComponent<MeshRenderer>();
        meshRand.material.color = Color.red;
        //text.SetActive(false);
        effect = GetComponent<ParticleSystem>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!saved)
        {
            meshRand.material.color = Color.green;
            effect.Play();
            other.GetComponent<PlayManager>().OnSavePoint();
            saved = true;

            //text.SetActive(true);
        }        
    }
}
