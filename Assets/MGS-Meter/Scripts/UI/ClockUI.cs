/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ClockUI.cs
 *  Description  :  Draw UI in scene to control clock.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.Meter
{
    public class ClockUI : MonoBehaviour
    {
        #region Field and Property 
        public float xOffset = 10;
        public float yOffset = 10;
        public Clock clock;
        #endregion

        #region Private Method
        private void OnGUI()
        {
            GUILayout.Space(yOffset);
            GUILayout.BeginHorizontal();
            GUILayout.Space(xOffset);
            GUILayout.BeginVertical();

            if (GUILayout.Button("Turn On"))
                clock.TurnOn();
            if (GUILayout.Button("Turn Off"))
                clock.TurnOff();

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }
        #endregion
    }
}