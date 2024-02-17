using UnityEngine;
using UnityEngine.AI;

public class Enemy2roaming : MonoBehaviour
{
    private NavMeshAgent agent;
 
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        nextGoal();
    }
 
    void nextGoal(){
    var randomPos = new Vector3(Random.Range(0,10),Random.Range(0,5),Random.Range(0,10));
    agent.destination = randomPos;
    }
    
    // Update is called once per frame
    void Update()
    {
        // Debug.Log(agent.remainingDistance);
        if(agent.remainingDistance < 1f){
        nextGoal();
        }
        
    }
}
//https://chamucode.com/unity-enemy-haikai/ 