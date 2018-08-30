using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject m_collidingObject = null;
	// Use this for initialization
	void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        m_collidingObject = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        m_collidingObject = null;
    }
}
