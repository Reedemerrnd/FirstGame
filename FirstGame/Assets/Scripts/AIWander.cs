using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWander : MonoBehaviour
{
    [SerializeField] private float _health;
    Animator animator;
    [SerializeField]private float _speed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _obstacleRange;
    public bool playerSpotted = false;
    public GameObject player;
    Vector3 _movement = Vector3.forward;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (_health > 0)
        {
            
            _movement.z = _speed * Time.deltaTime;
            transform.Translate(_movement);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
                if (hit.distance < _obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
                else if (playerSpotted)
                {
                    transform.LookAt(new Vector3(player.transform.position.x,0,player.transform.position.z));
                    _speed = _runSpeed;
                    animator.SetBool("PlayerSpot", true);
                }
        }
    }

    public void Hit(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            animator.SetBool("Death", true);
            
            Destroy(gameObject, 2);
        }
    }
}
