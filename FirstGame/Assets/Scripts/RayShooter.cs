using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _cam;
    public Texture cross;
    public float damage = 2.0f;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        _cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {


            
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObj = hit.transform.gameObject;
                
                AIHealth target = hitObj.GetComponent<AIHealth>();
                if (target != null)
                {
                    target.Hit(damage, gameObject);

                }
                else
                {
                    //HitPoint(hit.point);
                    Instantiate(particle, hit.point, hit.transform.rotation);
                    Debug.Log(hitObj);
                }
                
                //Debug.DrawRay(Input.mousePosition, hit.point, Color.red);
            }
        }
    }
    private void HitPoint(Vector3 point)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = point;
        Destroy(sphere, 3);
    }
    private void OnGUI()
    {
        int size = 30;
        float x = _cam.pixelWidth / 2 - size / 4;
        float y = _cam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(x, y, size, size),cross);
    }
}
