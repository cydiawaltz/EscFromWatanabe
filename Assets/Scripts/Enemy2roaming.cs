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
    var randomPos = new Vector3(Random.Range(0,100),Random.Range(0,100),Random.Range(0,100));
    agent.destination = randomPos;
    }
    
    // Update is called once per frame
    void Update()
    {
        // Debug.Log(agent.remainingDistance);
        if(agent.remainingDistance < 2f){
        nextGoal();
        }
        
    }
}
//https://chamucode.com/unity-enemy-haikai/ 