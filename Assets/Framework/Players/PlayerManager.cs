using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

// https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/api/UnityEngine.InputSystem.Users.InputUser.html

namespace StayupolKnights
{
	public class PlayerManager : MonoBehaviour
	{
		public InputControlList<InputDevice> unpairedDevices;
		List<InputUser> connectedUsers = new List<InputUser>();

		void Awake()
		{

		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				InputUser newUser = SetupNewUser();

				if (newUser.id == InputUser.InvalidId) { Debug.Log("Couldn't create player, no input devices left."); }
				else { connectedUsers.Add(newUser); }
			}
		}

		InputUser SetupNewUser()
		{
			unpairedDevices = InputUser.GetUnpairedInputDevices();
			if (unpairedDevices.Count == 0) { return new InputUser(); }

			InputUser newUser = new InputUser();

			newUser = InputUser.PerformPairingWithDevice(unpairedDevices[0], newUser);
			Debug.Log($"Paired device to new user: {newUser.pairedDevices[0].displayName}");
			unpairedDevices = InputUser.GetUnpairedInputDevices();

			return newUser;
		}
	}
}
