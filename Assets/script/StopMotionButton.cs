using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StopMotion : MonoBehaviour
{
    public Animator[] animators;
    public XRBaseInteractable interactable;

    private void OnEnable()
    {
        interactable.firstHoverEntered.AddListener(OnButtonPressed);
    }

    private void OnDisable()
    {
        interactable.firstHoverEntered.RemoveListener(OnButtonPressed);
    }

    private void OnButtonPressed(HoverEnterEventArgs args)
    {
        foreach (Animator animator in animators)
        {
            animator.SetBool("isLooping", false);
        }
    }
}
