using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour 
{
    Rigidbody m_rigidBody = null;
    GameObject m_attackableObject = null;
    // Constructor: called when object is first enabled
    void Awake()
    {
        // Constructor
        // Initialising this object
        m_rigidBody = GetComponent<Rigidbody>();
    }

    // Called after awake but before first update
    void Start() 
	{
		// Initialising interactions with other objects
	}
	
	// Update is called once per frame
	void Update() 
	{
        Vector3 force = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            force.z += 5;//600
        }
        if (Input.GetKey(KeyCode.S))
        {
            force.z -= 5;
        }
        if (Input.GetKey(KeyCode.A))
        {
            force.x -= 5;
        }
        if (Input.GetKey(KeyCode.D))
        {
            force.x += 5;
        }

        float rotation = 0.0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotation -= 100;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotation += 100;
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    m_rigidBody.AddForce(new Vector3(-400, 0, 0));
        //}

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (m_attackableObject)
            {
                Rigidbody otherRigidBody = m_attackableObject.GetComponent<Rigidbody>();
                if (otherRigidBody)
                {
                    Vector3 knockback = m_attackableObject.transform.position - transform.position;
                    knockback.Normalize();
                    knockback *= 300;
                    otherRigidBody.AddForce(knockback);
                }
            }
        }

        //m_rigidBody.AddForce(force * 3 * Time.deltaTime);
        m_rigidBody.MovePosition(transform.position + (force * Time.deltaTime));
        m_rigidBody.AddTorque(0, rotation * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Vector3 knockback = m_rigidBody.position - collision.collider.attachedRigidbody.position;
        //knockback.Normalize();
        //knockback *= 400;
        //m_rigidBody.AddForce(knockback);
    }

    private void OnTriggerEnter(Collider other)
    {
        m_attackableObject = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        m_attackableObject = null;
    }
}
