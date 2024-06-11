using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitlesStarter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<AudioManager>().Play("Nick4");
            Debug.Log("dafd");
        }
    }
}
