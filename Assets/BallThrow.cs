using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallThrow : MonoBehaviour
{
    public DogAI dog;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;

    void Awake()
    {
        grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grab.selectExited.AddListener(OnReleased);
    }

    void OnReleased(SelectExitEventArgs args)
    {
        // игрок отпустил мяч → бросок
        dog.GoFetch();
    }
}
