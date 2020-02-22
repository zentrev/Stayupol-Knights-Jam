using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

namespace StayupolKnights
{
	public abstract class Player : MonoBehaviour
	{
		public PlayerInput playerInput { get; set; }

		// Next step is to setup the character controllers, generate the c# file, then abstract this class and extend it into different classes that represent each of the character controllers. That way developers will be able to drag a single script onto a gameobject to turn it into a controlled character.
	}
}
