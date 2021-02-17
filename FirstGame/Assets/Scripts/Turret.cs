using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Transform _target;
    bool _playerSpotted = false;
    [SerializeField] float _speed;
    // Start is called before the first frame update
    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _target = other.transform;
            _playerSpotted = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerSpotted = false;
        }
    }
    void Update()
    {
        if (_playerSpotted)
        {
            var dir = _target.position - transform.position;
            dir.y += 3;
            var newDir = Vector3.RotateTowards(transform.forward, dir, _speed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }
}
