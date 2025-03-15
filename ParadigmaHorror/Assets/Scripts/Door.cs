using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();           
    }

    private void OnMouseDown()
    {
        if (animator != null)
        {
            isOpen = !isOpen;
            animator.SetBool("doorOpen", isOpen);
        }
    }
}
