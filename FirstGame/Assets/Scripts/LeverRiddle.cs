using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverRiddle : MonoBehaviour
{
    [SerializeField]bool _isActive = false;
    public bool Avtivated { get=> _isActive;}
    private void OnTriggerEnter(Collider other)
    {
        _isActive = true;
    }
    public void Deactivate()
    {
        _isActive = false;
    }

}
