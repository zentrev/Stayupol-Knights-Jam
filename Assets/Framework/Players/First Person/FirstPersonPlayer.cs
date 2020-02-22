using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using StayupolKnights.ExtensionMethods;
using Photon.Pun;

namespace StayupolKnights
{
	public class FirstPersonPlayer : Player, IPunObservable
	{
		FirstPersonInput input;
		Rigidbody rb;

		[Header("Camera Settings")]
		public float lookSensitivity = 3.0f;
		private bool _cameraZoomed; public bool cameraZoomed {
			get { return _cameraZoomed; }
			set {
				Camera playerCameraComponent = playerCamera.GetComponent<Camera>();
				if (value) { playerCameraComponent.fieldOfView = zoomFOV; }
				else { playerCameraComponent.fieldOfView = normalFOV; }
				_cameraZoomed = value;
			}
		}
		public float normalFOV = 60f, zoomFOV = 30f;
		Transform playerCamera;

		[Header("Movement Settings")]
		public float moveSpeed = 5.0f;
		public float gravity = 15.0f;
		public float jumpForce = 5.0f;
		public float airMovePercent = 0.35f;
		public bool grounded;

		[Header("Componets")]
		[SerializeField] SkinnedMeshRenderer m_characterModel = null;

		#region Input Variables
		Vector3 moveInput;
		Vector2 lookInput;
		#endregion

		private bool inControl = true;


		#region MonoBehavior

		void Awake()
		{
			input = new FirstPersonInput();
			TryGetComponent(out rb);
			playerCamera = GetComponentInChildren<Camera>().transform;

			// Set vars if my photonView
			if (photonView.IsMine)
			{
				Debug.Log("Hide player");
				m_characterModel.enabled = false;
			}
			else
			{
				Destroy(playerCamera.gameObject);
			}

			photonView.RPC("AddPlayerToGM", RpcTarget.MasterClient);

		
			input.Default.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>().ConvertXYVectorToXZVector();
			input.Default.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
			input.Default.Jump.performed += ctx => Jump();
		}

		void Update()
		{
			if (photonView.IsMine && inControl)
			{
				Look();
				Move();
			}

			// if (player.GetButtonDown("ToggleZoom")) { Zoom(); }
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Ground")
			{
				grounded = true; velocityAtJump = Vector3.zero;
			}
		}

		void OnTriggerStay(Collider other)
		{
			if (other.gameObject.tag == "Ground")
			{
				grounded = true;
			}
		}

		void OnTriggerExit(Collider other)
		{
			if (other.gameObject.tag == "Ground")
			{
				grounded = false;
			}
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


		float verticalClamp = 0.0f;
		Vector2 deltaLook = Vector2.zero;
		void Look()
		{
			deltaLook = lookInput;
			deltaLook = deltaLook * lookSensitivity;

			verticalClamp += deltaLook.y;

			if (verticalClamp > 90.0f)
			{
				verticalClamp = 90.0f;
				deltaLook.y = 0;
				ClampCamera(270.0f);
			}
			if (verticalClamp < -90.0f)
			{
				verticalClamp = -90.0f;
				deltaLook.y = 0;
				ClampCamera(90.0f);
			}

			playerCamera.Rotate(Vector3.left, deltaLook.y);
			transform.Rotate(Vector3.up, deltaLook.x, Space.Self);
		}

		void Zoom()
		{
			cameraZoomed = !cameraZoomed;
		}

		Vector3 velocityAtJump = Vector3.zero;
		void Move()
		{
			if (moveInput != Vector3.zero)
			{
				Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);

				if (grounded)
				{
					localVelocity.x = moveInput.x * moveSpeed;
					localVelocity.z = moveInput.z * moveSpeed;
				}
				else
				{
					localVelocity.x = (velocityAtJump.x * (1.0f - airMovePercent)) + ((moveInput.x * moveSpeed) * airMovePercent);
					localVelocity.z = (velocityAtJump.z * (1.0f - airMovePercent)) + ((moveInput.z * moveSpeed) * airMovePercent);
				}

				rb.velocity = (transform.TransformDirection(localVelocity));
			}

			rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));
		}

		void Jump()
		{
			if (grounded)
			{
				rb.AddForce(new Vector3(0, jumpForce * 100, 0));
				velocityAtJump = transform.InverseTransformDirection(rb.velocity);
			}
		}

		void ClampCamera(float clampValue)
		{
			Vector3 clampedRotation = playerCamera.eulerAngles;
			clampedRotation.x = clampValue;
			playerCamera.eulerAngles = clampedRotation;
		}

		public void FreezePlayer(bool freeze)
		{
			rb.isKinematic = freeze;
			inControl = !freeze;
		}

		#region Network

		public static void RefreshInstance(ref FirstPersonPlayer agent, FirstPersonPlayer Prefab, Transform spawn)
		{
			if (agent != null)
			{
				spawn.position = agent.transform.position;
				spawn.rotation = agent.transform.rotation;
				PhotonNetwork.Destroy(agent.gameObject);
			}

			agent = PhotonNetwork.Instantiate(Prefab.gameObject.name, spawn.position, spawn.rotation).GetComponent<FirstPersonPlayer>();
		}

		public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
		{
			if (stream.IsWriting)
			{
			}
			else
			{

			}
		}

		[PunRPC]
		void AddPlayerToGM()
		{
			if(PhotonNetwork.IsMasterClient)
			{
				GameManager.Instance.players.Add(this);
			}
		}

		#endregion
	}
}
