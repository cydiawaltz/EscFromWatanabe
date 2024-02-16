using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(SphereCollider))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float searchAngle = 45f;
    [SerializeField] private float searchLength = 10f;

    private NavMeshAgent _navMeshAgent;

    private bool _isChasing = false;

    [SerializeField] private float _rotationSpeed = 10.0f;

    /*[SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletPower;
    [SerializeField] private float _bulletLifeTime;
    [SerializeField] private float _bulletInterval;
    */

    [SerializeField] private float _minDistance;

    //private float _bulletShotRemaingTime;

    private void Awake()
    {
        GetComponent<SphereCollider>().radius = searchLength;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    /*private void ShotBullet()
    {
        var bulletInstance = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * _bulletPower);
        Destroy(bulletInstance, _bulletLifeTime);
    }*/

    void Update()
    {
        if (!_isChasing) return;
        /*_bulletShotRemaingTime -= Time.deltaTime;
        if (_bulletShotRemaingTime < 0 )
        {
            ShotBullet();
            _bulletShotRemaingTime = _bulletInterval;
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 direction = other.transform.position - this.transform.position;
            float angle = Vector2.Angle(
                new Vector2(this.transform.forward.x, this.transform.forward.z), 
                new Vector2(direction.x, direction.z));
            if (angle < searchAngle)
            {
                Ray ray = new Ray(this.transform.position, direction);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~(1 << 7) ))
                {
                    if (hit.collider == other)
                    {
                        if (!_isChasing)
                        {
                            _isChasing = true;
                            //_bulletShotRemaingTime = 0;
                            Debug.Log("???E????????c");
                        }

                        if (new Vector3(direction.x, 0.0f, direction.z).sqrMagnitude <= _minDistance)
                        {
                            if (!_navMeshAgent.isStopped) _navMeshAgent.isStopped = true;
                        }
                        else
                        {

                            if (_navMeshAgent.isStopped) _navMeshAgent.isStopped = false;
                        }

                        _navMeshAgent.destination = other.transform.position;

                        transform.LookAt(other.transform);
                    }
                    else if (_isChasing)
                    {
                        _isChasing = false;
                        _navMeshAgent.isStopped = true;
                        Debug.Log("??Q??????????E????O???c");
                    }
                }
            }
            else if (_isChasing)
            {
                _isChasing = false;
                _navMeshAgent.isStopped = true;
                Debug.Log("??????p?x????O???c");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && _isChasing)
        {
            _isChasing = false;
            _navMeshAgent.isStopped = true;
            Debug.Log("??????????á{???c");
        } 
    }
}

