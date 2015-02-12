using UnityEngine;
using System.Collections;

namespace BT.Ex.Movement {

	public class MoveToDirection : BTAction {

		private float _speed;
		private string _directionName;
		private int _directionId;
		private GeneralDirection _moveDirection;
//		private Rigidbody _rigid;
		private Transform _trans;


		public MoveToDirection (string directionName, GeneralDirection moveDirection, float speed, BTPrecondition precondition = null) : base (precondition) {
			_directionName = directionName;
			_moveDirection = moveDirection;
			_speed = speed;
		}

		public override void Activate (Database database) {
			base.Activate (database);

			_directionId = database.GetDataId(_directionName);
//			_rigid = database.rigidbody;
			_trans = database.transform;
		}

		protected override BTResult Execute () {
			Vector3 direction = database.GetData<Vector3>(_directionId);
			Vector3 position = _trans.position;

			float speed = _speed;

			if (_moveDirection == GeneralDirection.Horizontal) {
				if (direction.x != 0) {
					position.x += speed * direction.x * Time.deltaTime;
				}
				else {
					position.x += speed * Mathf.Abs(direction.y) * Time.deltaTime;
				}
			}
			else if (_moveDirection == GeneralDirection.Vertical) {
				if (direction.x != 0) {
					position.y += speed * Mathf.Abs(direction.x) * Time.deltaTime;
				}
				else {
					position.y += speed * direction.y * Time.deltaTime;
				}
			}
			else if (_moveDirection == GeneralDirection.Both) {
				position.x += speed * direction.x * Time.deltaTime;
				position.y += speed * direction.y * Time.deltaTime;
			}

				
			_trans.position = position;

//			Vector3 velocity = _rigid.velocity;
//
//			if (_moveDirection == GeneralDirection.Horizontal || _moveDirection == GeneralDirection.Both) {
//				velocity.x += _speed * direction.x;
//
//				if (Mathf.Abs(velocity.x) > _speed) {
//					int sign = velocity.x > 0 ? 1 : -1;
//					velocity.x = _speed * sign;
//				}
//			}
//			if (_moveDirection == GeneralDirection.Vertical || _moveDirection == GeneralDirection.Both) {
//				velocity.y += _speed * direction.y;
//
//				if (Mathf.Abs(velocity.y) > _speed) {
//					int sign = velocity.y > 0 ? 1 : -1;
//					velocity.y = _speed * sign;
//				}
//			}
//
//			_rigid.velocity = velocity;

			return BTResult.Running;
		}
	}

}