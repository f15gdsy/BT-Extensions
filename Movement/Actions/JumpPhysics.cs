using UnityEngine;
using System.Collections;

namespace BT.Ex.Movement {
	

	public class JumpPhysics : BTAction {

		private string _directionName;
		private int _directionId;
		private float _jumpVelocity;
		private GeneralDirection _jumpDirection;
		private float _timeSinceLastJump;
		private float _jumpInterval = 0.1f;
		private Rigidbody _rigid;


		public JumpPhysics (string directionName, GeneralDirection jumpDirection, float jumpForce, BTPrecondition precondition = null) : base (precondition) {
			_directionName = directionName;
			_jumpDirection = jumpDirection;
			_jumpVelocity = jumpForce;
		}

		public override void Activate (Database database) {
			base.Activate (database);

			_directionId = database.GetDataId(_directionName);
			_rigid = database.rigidbody;
		}

		protected override void Enter () {
			base.Enter ();

			if (Time.time - _timeSinceLastJump >= _jumpInterval) {
				_timeSinceLastJump = Time.time;

				Vector3 direction = database.GetData<Vector3>(_directionId);
				Vector3 force = Vector3.zero;

				if (_jumpDirection == GeneralDirection.Horizontal || _jumpDirection == GeneralDirection.Both) {
					force.x = _jumpVelocity * direction.x;	
				}
				if (_jumpDirection == GeneralDirection.Vertical || _jumpDirection == GeneralDirection.Both) {
					force.y = _jumpVelocity * direction.y;
				}

				_rigid.velocity = force;
			}
		}
	}

}