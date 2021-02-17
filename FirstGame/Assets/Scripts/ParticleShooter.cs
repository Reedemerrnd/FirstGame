using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShooter : MonoBehaviour
{
    [SerializeField] float _damage = 2.0f;
    public float Damage { get => _damage;}
    public ParticleSystem shots;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            //shots.Emit(10);
            if (!shots.isPlaying)
            {
                shots.Play();
            }
        }
        
    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("collide");
    }

    // Update is called once per frame
}
