using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
public abstract class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float stopTime = 43F;

    private bool hasFastRun=false;
    private bool hasCoat = false;

    private bool isInteractable = true;

    public NavMeshAgent agent { get; set; }

    public bool IsTagged { get; set; }
    public bool IsInteractable { get => isInteractable; set => isInteractable = value; }
    public bool HasFastRun { get => hasFastRun; set => hasFastRun = value; }
    public bool HasCoat { get => hasCoat; set => hasCoat = value; }

    public void SwitchRoles()
    {
        IsTagged = !IsTagged;

        if (IsTagged)
        {
            GameController.taggedScore[name] += 1;
        }

        // Pause all logic and restart after
    }

    public void GoToLocation(Vector3 location)
    {
        agent.SetDestination(location);
    }

    public virtual IEnumerator StopLogic()
    {
        // Stop BT runner if AI player, else stop movement.
        isInteractable = false;

        gameObject.GetComponent<BehaviourRunner>().enabled = false;

        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        
        yield return new WaitForSeconds(stopTime);

        gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        gameObject.GetComponent<BehaviourRunner>().enabled = true;
        isInteractable = true;



        // Restart stuff.
    }

    protected abstract Vector3 GetLocation();

    // Start is called before the first frame update
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsInteractable)
        {
            IsTagged = !IsTagged;

            if (IsTagged)
            {
                StopLogic();
            }
        }


         
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))

        {
            if (GetComponent<HumanController>())
            {
                agent.SetDestination(GetComponent<HumanController>().GetLocation());
            }
        }
    }
}