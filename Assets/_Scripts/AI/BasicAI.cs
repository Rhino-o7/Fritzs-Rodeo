using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Camera))]
public class BasicAI : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float wanderRange = 10f;
    Collider playerCol;
    NavMeshAgent agent;
    Camera cam;

    Plane[] aiCamPlanes;
    
    
    void Start(){
        playerCol = player.GetComponent<Collider>();
        agent = GetComponent<NavMeshAgent>();
        cam = GetComponent<Camera>();
    }

    void Update(){
        Physics.Linecast(transform.position, player.transform.position, out RaycastHit hit);
        print(hit.collider.gameObject);
        if (Chase() && hit.collider.gameObject == player){
            print("Chase");
            agent.SetDestination(player.transform.position);
        }else{
            print("Wander");
            if (agent.velocity == Vector3.zero){
                agent.SetDestination(RandomNavSphere(transform.position, wanderRange, 1));
            }
        }
    }

    bool Chase(){
        aiCamPlanes = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(aiCamPlanes, playerCol.bounds)){
            return true;
        }
        return false;
    }

    public static Vector3 RandomNavSphere (Vector3 origin, float distance, int layermask) {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);
        return navHit.position;
    }
}
