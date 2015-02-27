using UnityEngine;
using System.Collections;

namespace BT.Ex.Movement {

	public class RotateOverTime : BTAction {

		private float _interval;
		private float _startTime;
		private float _toAngle;
		private float _angle;
		private float _originalAngle;
		private Transform _trans;


		public RotateOverTime (GameObject go, float toAngle, float interval, BTPrecondition precondition = null) : base (precondition) {
			_toAngle = toAngle;
			_interval = interval;

			_trans = go.transform;
		}

		protected override void Enter () {
			base.Enter ();
			_originalAngle = _trans.eulerAngles.z;
			_angle = _toAngle - _originalAngle;
			_startTime = Time.time;
		}

		protected override BTResult Execute () {


			_trans.Rotate(Vector3.forward * _angle * Time.deltaTime / _interval);

			if (Time.time - _startTime < _interval) {
				return BTResult.Running;
			}
			else {
				return BTResult.Ended;
			}
		}

		protected override void Exit () {
			base.Exit ();
		}

		public override void Clear ()
		{
			base.Clear ();
			_trans.eulerAngles = new Vector3 (0, 0, _toAngle);
		}
		
	}



}