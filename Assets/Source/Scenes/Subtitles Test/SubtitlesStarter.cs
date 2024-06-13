using UnityEngine;

public class SubtitlesStarter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<AudioManager>().Play("Nick4");
        }
    }
}
