using UnityEngine;
using UnityEngine.AI;

public class DogAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform ball;
    public Transform player;

    private enum State
    {
        Idle,
        GoToBall,
        ReturnToPlayer
    }

    private State state = State.Idle;

    void Update()
    {
        if (state == State.GoToBall)
        {
            agent.SetDestination(ball.position);

            if (Vector3.Distance(transform.position, ball.position) < 1.2f)
                PickUpBall();
        }

        if (state == State.ReturnToPlayer)
        {
            agent.SetDestination(player.position);

            if (Vector3.Distance(transform.position, player.position) < 1.5f)
                DropBall();
        }

        if (state == State.ReturnToPlayer)
        {
            ball.transform.localPosition = new Vector3(0,0.7f,0);
        }
    }

    public void GoFetch()
    {
        state = State.GoToBall;
    }

    void PickUpBall()
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        ball.SetParent(transform);
        //ball.localPosition = new Vector3(0, 0.4f, 0.6f);

        state = State.ReturnToPlayer;
    }

    void DropBall()
    {
        ball.SetParent(null);

        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        state = State.Idle;
    }
}
