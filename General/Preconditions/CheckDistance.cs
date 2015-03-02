using UnityEngine;
using System.Collections;

namespace BT.Ex.General {

	public class CheckDistance : BTPreconditionUseDB {

		private float _distance;
		private CompareOperator _op;
		private Transform _trans;
		private Transform _targetTrans;

		public CheckDistance (string nameOfTargetTrans, float distance, CompareOperator op) : base (nameOfTargetTrans) {
			_distance = distance;
			_op = op;
		}

		public override void Activate (Database database) {
			base.Activate (database);

			_trans = database.transform;
		}

		public override bool Check () {
			_targetTrans = database.GetData<Transform>(_dataIdToCheck);
			Vector3 offset = _targetTrans.position - _trans.position;

			if (_op == CompareOperator.GreaterEqualTo) {
				return offset.sqrMagnitude >= _distance * _distance;
			}
			else if (_op == CompareOperator.GreaterThan) {
				return offset.sqrMagnitude > _distance * _distance;
			}
			else if (_op == CompareOperator.EqualTo) {
				return offset.sqrMagnitude == _distance * _distance;
			}
			else if (_op == CompareOperator.LessThan) {
				return offset.sqrMagnitude < _distance * _distance;
			}
			else if (_op == CompareOperator.LessEqualTo) {
				return offset.sqrMagnitude <= _distance * _distance;
			}

			return false;
		}
	}

}