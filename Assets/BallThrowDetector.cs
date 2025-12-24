using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallThrowDetector : MonoBehaviour
{
    public DogAI dog;

    void OnDisable()
    {
        dog.GoFetch();
    }
}
