using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    [SerializeField]
    public Animator anim;

    [SerializeField]
    private NavMeshAgent nav;
    private Vector3 target;
    [SerializeField]
    private Transform player;
    NavMeshAgent agent;
    
    private GameManager gm;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        gm = GameManager.Instance;
    }

    void Setup()
    {
        
    }

    public void pauseNav()
    {
        nav.isStopped = true;
    }

    public void resumeNav()
    {
        nav.isStopped = false;
    }

    void FixedUpdate()
    {

        SetTargetPosition();
        SetAgentPosition();

        Vector3 normalizedMovement = nav.desiredVelocity.normalized;

        Vector3 forwardVector = Vector3.Project(normalizedMovement, transform.forward);

        Vector3 rightVector = Vector3.Project (normalizedMovement, transform.right);
        // Dot(direction1, direction2) = 1 if they are in the same direction, -1 if they are opposite

        float forwardVelocity = forwardVector.magnitude * Vector3.Dot(forwardVector, transform.forward);

        float rightVelocity = rightVector.magnitude * Vector3.Dot(rightVector, transform.right);
        float max = Mathf.Max(Mathf.Abs(forwardVelocity), Mathf.Abs(rightVelocity));
        anim.SetInteger("walkDirection", 1);
        if(Mathf.Approximately(max, Mathf.Abs(forwardVelocity))){
            if(forwardVelocity > 0)
                setDirection("walkF");
            else setDirection("walkB");
        } else {
            if(rightVelocity > 0)
                setDirection("walkR");
            else setDirection("walkL");
        }
    }

    private void setDirection(string d)
    {
        anim.SetBool("walkF", false);
        anim.SetBool("walkR", false);
        anim.SetBool("walkB", false);
        anim.SetBool("walkL", false);
        anim.SetBool(d, true);
    }

    void SetTargetPosition()
    {
        target = player.position;
    }

    void SetAgentPosition()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }
}
