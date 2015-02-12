using UnityEngine;
using System.Collections;

namespace BT.Ex.Movement {

	public class MoveOffset : BTAction {

		private float _offset;
		private Vector3 _direction;
		private bool _executeWhenClear;
		private Transform _trans;


		public MoveOffset (float offset, Vector3 direction, bool executeOnClear = false, BTPrecondition precondition = null) : base (precondition) {
			_offset = offset;
			_direction = direction;
			_executeWhenClear = executeOnClear;
		}

		public override void Activate (Database database) {
			base.Activate (database);

			_trans = database.transform;
		}

		protected override BTResult Execute () {
			Vector3 position = _trans.position;
			position += _offset * _direction;
			_trans.position = position;
			return BTResult.Ended;
		}

		public override void Clear () {
			base.Clear ();
			Execute();
		}
	}

}