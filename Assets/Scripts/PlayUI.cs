using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject player;


    // Update is called once per frame
    void Update()
    {
        text.text = "Remaining Lives:" + player.GetComponent<PlayManager>().lives;
    }
}
