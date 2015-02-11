using UnityEngine;
using System.Collections;

namespace BT.Ex.Platformer {

	public class MovePhysics : BTAction {

		private static string _directionName = "Move Direction";
		private int _directionId;


		public override void Activate (Database database) {
			base.Activate (database);

			_directionId = database.GetDataId(_directionName);
		}

		protected override void Enter () {
			base.Enter ();


		}

		protected override BTResult Execute () {
			Vector3 direction = database.GetData<Vector3>(_directionId);

			

			return BTResult.Running;
		}

		protected override void Exit () {
			base.Exit ();
		}
	}

}