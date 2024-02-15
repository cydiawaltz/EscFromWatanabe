using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnermyControll : MonoBehaviour {

    public NavMeshAgent player;
    public GameObject target;

    void Start () {
        player  = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update () {
        if (target != null) {
            player.destination  = target.transform.position;
        }
    }
}
//https://qiita.com/aimy-07/items/d1fea617ab9cbb3bd1ed 