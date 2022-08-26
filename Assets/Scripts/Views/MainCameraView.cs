using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraView : MonoBehaviour
{
    public Transform followTransform;
    public float changeCam = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y + changeCam, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
