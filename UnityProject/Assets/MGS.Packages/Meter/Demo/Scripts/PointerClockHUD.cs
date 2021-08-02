/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PointerClockHUD.cs
 *  Description  :  Draw UI in scene to control clock.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Meter.Demo
{
    public class PointerClockHUD : MonoBehaviour
    {
        #region Field and Property
        public float top = 10;
        public float left = 10;
        public PointerClock clock;
        #endregion

        #region Private Method
        private void OnGUI()
        {
            GUILayout.Space(top);
            GUILayout.BeginHorizontal();
            GUILayout.Space(left);
            GUILayout.BeginVertical();

            if (GUILayout.Button("Turn On"))
            {
                clock.TurnOn();
            }
            if (GUILayout.Button("Turn Off"))
            {
                clock.TurnOff();
            }

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }
        #endregion
    }
}