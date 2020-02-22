using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StayupolKnights
{

	public class TopDown2DPlayer : MonoBehaviour
	{
		TopDown2DInput input;
		Rigidbody2D rb;

		#region Look Settings
		[Header("Look Settings")]
		public Transform directionHinge;
		#endregion

		#region Move Settings
		[Header("Move Settings")]
		public float acceleration;
		#endregion

		#region Input Variables
		Vector2 lookInput;
		Vector2 moveInput;
		#endregion


		#region MonoBehaviour

		void Awake()
		{
			input = new TopDown2DInput();
			rb = GetComponent<Rigidbody2D>();

			input.Default.Look.performed += ctx =>
			{
				if (ctx.ReadValue<Vector2>().magnitude > 5f)
				{
					Vector2 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
					lookInput = ctx.ReadValue<Vector2>() - playerScreenPosition;
				}
				else
				{
					lookInput = ctx.ReadValue<Vector2>();
				}
			};
			input.Default.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
			input.Default.Action.performed += ctx => Action();
		}

		void Update()
		{
			Look();
			Move();
		}

		void OnEnable()
		{
			input.Enable();
		}

		void OnDisable()
		{
			input.Disable();
		}

		#endregion


		void Look()
		{
			Debug.Log(Camera.main.WorldToScreenPoint(transform.position));

			float angle = Mathf.Atan2(lookInput.y, lookInput.x) * Mathf.Rad2Deg;
			directionHinge.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}

		void Move()
		{
			rb.AddForce(moveInput * acceleration);
		}

		void Action()
		{
			Debug.Log("Action!");
		}
	}
}
