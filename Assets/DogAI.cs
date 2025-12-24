using UnityEngine;
using UnityEngine.AI;

public enum DogState
{
    Idle,        // ждёт
    Searching,   // бежит к мячу
    Carrying,    // несёт мяч
    Returning    // возвращается к игроку
}

public class DogAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public Transform ball;

    public DogState currentState;

    void Update()
    {
        switch (currentState)
        {
            case DogState.Idle:
                break;

            case DogState.Searching:
                agent.SetDestination(ball.position);

                if (Vector3.Distance(transform.position, ball.position) < 1.2f)
                {
                    PickUpBall();
                }
                break;

            case DogState.Carrying:
                agent.SetDestination(player.position);

                if (Vector3.Distance(transform.position, player.position) < 1.5f)
                {
                    DropBall();
                }
                break;
        }
    }

    public void GoFetch()
    {
        currentState = DogState.Searching;
    }

    void PickUpBall()
    {
        ball.SetParent(transform);
        ball.localPosition = new Vector3(0, 0.5f, 0.5f);

        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        currentState = DogState.Carrying;
    }

    void DropBall()
    {
        ball.SetParent(null);

        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        currentState = DogState.Idle;
    }
}
