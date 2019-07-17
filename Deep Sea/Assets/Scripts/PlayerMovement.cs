using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	
	private Rigidbody2D m_Rigidbody2D;
	
	float horizontalMove = 0f;
	public float m_RunSpeed = 10f;
	public float m_JumpForce = 50f;
	private bool jump = false;
	public float m_MaxJump = 1f;
	
	private bool m_FacingRight = true;
	
	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

	}
	
	void Update()
    {
		horizontalMove =  Input.GetAxisRaw("Horizontal") * m_RunSpeed;
		 
		if(Input.GetButtonDown("Jump"))	
		{
			jump = true;
		}
	}
	
    void FixedUpdate()
    {
	   move(horizontalMove * Time.fixedDeltaTime, jump);
	   jump = false;
	}
	
	private void move(float move, bool jump)
	{
		Vector3 zero = Vector3.zero;
			// Mueve al personaje
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// Suaviza el movimiento
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref zero , .05f);
			
			// Si el personaje se mueve a la derecha entonce ve hacia la izquierda
			if (move > 0 && !m_FacingRight)
			{
				// Voltea al jugador
				Flip();
			}
			// Si no ...
			else if (move < 0 && m_FacingRight)
			{	
				Flip();
			}
			
			if(jump && m_Rigidbody2D.velocity.y < m_MaxJump )
			{
				// Añade fuerza vertical al jugador(salto)			
				m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			}
			
			
		
	}

	private void Flip()
	{
		m_FacingRight = !m_FacingRight;

		// Multiplica la escala del jugador por -1
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
