using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public CharacterController cc = null;

    private float m_knockbackDistance = 5;
    private float m_drag = 20;
    private Vector3 m_velocity = Vector3.zero;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_velocity /= 1 + m_drag * Time.deltaTime;   
        cc.Move(m_velocity * Time.deltaTime);
    }

    public void TakeDamage(GameObject attacker)
    {
        Vector3 direction = transform.position - attacker.transform.position;
        m_velocity += Vector3.Scale(direction, m_knockbackDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * m_drag + 1)) / -Time.deltaTime),
                                                                  0,
                                                                  (Mathf.Log(1f / (Time.deltaTime * m_drag + 1)) / -Time.deltaTime)));
    }
}
