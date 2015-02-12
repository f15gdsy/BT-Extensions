using UnityEngine;
using System.Collections;

namespace BT.Ex.Movement {

	public class CheckOnGround : BTPrecondition {

		private LayerMask _groundLayer;
		private Vector3 _direction;
		private bool _onGroundAsTrue;
		private float _raycastDistance;
		private Vector3 _raycastOffset;
		private Vector2 _extents;

		private Transform _trans;


		public CheckOnGround (LayerMask groundLayer, Direction direction, Vector2 extents, bool onGroundAsTrue = true) : base () {
			_groundLayer = groundLayer;
			_onGroundAsTrue = onGroundAsTrue;
			_extents = extents;

			switch (direction) {
			case Direction.Left:
				_direction = new Vector3(-1, 0, 0);
				break;
			case Direction.Right:
				_direction = new Vector3(1, 0, 0);
				break;
			case Direction.Up:
				_direction = new Vector3(0, 1, 0);
				break;
			case Direction.Down:
				_direction = new Vector3(0, -1, 0);
				break;
			}
		}

		public override void Activate (Database database) {
			base.Activate (database);

			_trans = database.transform;
			Collider colliderTemp = database.collider;

			if (_direction.x == 0 && _direction.y != 0) {
				_raycastDistance = colliderTemp.bounds.size.y / 2 * _extents.y;
				_raycastOffset = new Vector3(colliderTemp.bounds.size.x / 2, 0, 0) / _extents.y;
			}
			else if (_direction.x != 0 && _direction.y == 0){
				_raycastDistance = colliderTemp.bounds.size.x / 2 * _extents.x;
				_raycastOffset = new Vector3(0, colliderTemp.bounds.size.y / 2, 0) / _extents.x;
			}
		}

		public override bool Check () {
			RaycastHit hit;

			if (Physics.Raycast(_trans.position, _direction, out hit, _raycastDistance, _groundLayer) ||
			    Physics.Raycast(_trans.position - _raycastOffset, _direction, out hit, _raycastDistance, _groundLayer) ||
			    Physics.Raycast(_trans.position + _raycastOffset, _direction, out hit, _raycastDistance, _groundLayer)) {
				return _onGroundAsTrue;
			}

			return !_onGroundAsTrue;
		}
	}
}