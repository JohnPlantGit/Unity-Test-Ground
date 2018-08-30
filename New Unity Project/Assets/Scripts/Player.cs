using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController cc = null;
    public float m_speed = 7;
    public float m_dashDistance = 5;
    public float m_drag = 20;
    public GameObject m_enemy = null;

    private Vector3 m_velocity = Vector3.zero;
    private List<GameObject> m_targets = new List<GameObject>();
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 movement = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            movement.z += m_speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.z -= m_speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x -= m_speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x += m_speed;
        }

        float rotation = 0.0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotation -= 120 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotation += 120 * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // DASH
            m_velocity += Vector3.Scale(transform.forward, m_dashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * m_drag + 1)) / -Time.deltaTime),
                                                                  0,
                                                                  (Mathf.Log(1f / (Time.deltaTime * m_drag + 1)) / -Time.deltaTime)));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            foreach(GameObject current in m_targets)
            {
                current.GetComponent<Enemy>().TakeDamage(gameObject);
            }
        }

        m_velocity /= 1 + m_drag * Time.deltaTime;
        cc.Move(movement * Time.deltaTime);
        cc.Move(m_velocity * Time.deltaTime);
        transform.Rotate(0, rotation, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        m_targets.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        m_targets.Remove(other.gameObject);
    }
}
