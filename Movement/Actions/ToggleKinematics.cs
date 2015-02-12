using UnityEngine;
using System.Collections;

namespace BT.Ex.Movement {

	public class ToggleKinematics : BTAction {
		private Rigidbody _rigid;


		public override void Activate (Database database) {
			base.Activate (database);

			_rigid = database.rigidbody;
		}

		protected override void Enter () {
			base.Enter ();

			_rigid.isKinematic = !_rigid.isKinematic;
		}

		protected override BTResult Execute () {
			return BTResult.Ended;
		}
	}

}