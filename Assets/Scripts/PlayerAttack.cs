using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject atkCube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            atkCube.SetActive(true);
        }
        else
        {
            atkCube.SetActive(false);
        }
    }
}
