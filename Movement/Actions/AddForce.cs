using UnityEngine;
using System.Collections;

namespace BT.Ex.Movement {
	
	public class AddForce : BTAction {

		private float _force;
		private Vector3 _direction;
		private bool _continuous;
		private Rigidbody _rigid;


		public AddForce (float force, Vector3 direction, bool continuous, BTPrecondition precondition = null) : base (precondition) {
			_force = force;
			_direction = direction.normalized;
			_continuous = continuous;
		}

		public override void Activate (Database database) {
			base.Activate (database);

			_rigid = database.rigidbody;
		}

		protected override BTResult Execute () {
			_rigid.AddForce(_direction * _force);

			return _continuous ? BTResult.Running : BTResult.Ended;
		}
	}

}