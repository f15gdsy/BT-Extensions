using UnityEngine;
using System.Collections;

namespace BT.Ex.Debugging {

	public class DebugLog : BTAction {

		private string _enterMessage;
		private string _executeMessage;
		private string _exitMessage;


		public DebugLog (string enterMessage, string executeMessage, string exitMessage, BTPrecondition precondition = null) : base (precondition) {
			_enterMessage = enterMessage;
			_executeMessage = executeMessage;
			_exitMessage = exitMessage;
		}

		protected override void Enter () {
			base.Enter ();

			Debug.Log(_enterMessage);
		}

		protected override BTResult Execute () {
			Debug.Log(_executeMessage);

			return BTResult.Running;
		}

		protected override void Exit () {
			base.Exit ();

			Debug.Log(_exitMessage);
		}
	}

}