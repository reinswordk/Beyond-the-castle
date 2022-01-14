using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    public GameObject Vcam;
    Animator vcamAnim;
    // Start is called before the first frame update
    void Start()
    {
        vcamAnim = Vcam.GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraZoomIn()
    {
        vcamAnim.SetTrigger ("IsZoomIn");
    }

    public void CameraZoomOut()
    {
        vcamAnim.SetTrigger ("isZoomOut");
    }
}
