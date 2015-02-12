using UnityEngine;
using System.Collections;

namespace BT.Ex.Movement {

	public class ClearVelocity : BTAction {

		private Rigidbody _rigid;


		public override void Activate (Database database) {
			base.Activate (database);

			_rigid = database.rigidbody;
		}

		protected override BTResult Execute () {
			_rigid.velocity = Vector3.zero;

			return BTResult.Ended;
		}
	}

}