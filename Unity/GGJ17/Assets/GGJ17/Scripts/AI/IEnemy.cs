using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy  {

    void GoTo (Transform trans_);

    void EvaluateAction ();

    void Attack ();

}
