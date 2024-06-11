using UnityEngine;

public class NoseTrigger : MonoBehaviour
{
    [SerializeField] private InteractiveCommands _interactiveCommands;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stairs")
        {
            _interactiveCommands.ShowInteractiveMessage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Stairs")
        {
            _interactiveCommands.HideInteractiveMessage();
        }
    }
}
