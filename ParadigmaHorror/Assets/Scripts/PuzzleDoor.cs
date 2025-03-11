using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{
    public GameObject door;
    private string tagObjectActive = "Item";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagObjectActive))
        {
            Destroy(door);
        }
    }
}