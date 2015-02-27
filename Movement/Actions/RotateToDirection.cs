using UnityEngine;
using System.Collections;

namespace BT.Ex.Movement {

	public class RotateToDirection : BTAction {

		protected string _directionName;
		protected int _directionId;
		protected bool _continuous;
		protected Transform _trans;


		public RotateToDirection (string directionName, Transform targetToRotate, bool continuous, BTPrecondition precondition = null) : base (precondition) {
			_directionName = directionName;
			_continuous = continuous;
			_trans = targetToRotate;
		}

		public override void Activate (Database database) {
			base.Activate (database);

			_directionId = database.GetDataId(_directionName);
		}

		protected override BTResult Execute () {
			Vector3 direction = database.GetData<Vector3>(_directionId);

			float degree = SMath.VectorToDegree(direction);
			Vector3 angles = _trans.localEulerAngles;
			angles.z = degree;
			_trans.localEulerAngles = angles;

			return _continuous ? BTResult.Running : BTResult.Ended;
		}
	}

}