using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle : MonoBehaviour
{
    LeverRiddle _lever_1;
    LeverRiddle _lever_2;
    LeverRiddle _lever_3;
    bool _stage1 = false;
    bool _stage2 = false;
    bool _stage3 = false;
    Transform _bonusDoor;
    Transform _mainDoor;

    // Start is called before the first frame update
    void Start()
    {
        DeactivateAll();
        _lever_1 = transform.Find("Lever_1").GetComponent<LeverRiddle>();
        _lever_2 = transform.Find("Lever_2").GetComponent<LeverRiddle>(); 
        _lever_3 = transform.Find("Lever_3").GetComponent<LeverRiddle>(); 
        _bonusDoor = transform.Find("Bonus");
        _mainDoor = transform.Find("Main");
    }

    // Update is called once per frame
    void Update()
    {
        if (_lever_1.Avtivated)
        {
            _stage1 = true;
            Debug.Log("stage1");

        }
        if(_stage1 && _lever_3.Avtivated && !_lever_2.Avtivated)
        {
            _stage2 = true;
            Debug.Log("stage2");

        }
        else if (_stage1 && _lever_2.Avtivated && !_lever_3.Avtivated)
        {
            _stage1 = false;
            DeactivateAll();
        }
        if(_stage2 && _lever_2.Avtivated)
        {
            _mainDoor.GetComponent<OpenDoor>().Activate();
            DeactivateAll();
            _stage3 = true;
            _stage1 = false;
            _stage2 = false;
            Debug.Log("stage3");
        } 
        if (_stage3 && _lever_3.Avtivated)
        {
            _bonusDoor.GetComponent<OpenDoor>().Activate();
        }
        else if (_stage3 && (_lever_1.Avtivated || _lever_2.Avtivated))
        {
            DeactivateAll();
            
            _stage3 = false;
        }




    }
    private void DeactivateAll()
    {
        _lever_1.Deactivate();
        _lever_2.Deactivate();
        _lever_3.Deactivate();
    }
}
