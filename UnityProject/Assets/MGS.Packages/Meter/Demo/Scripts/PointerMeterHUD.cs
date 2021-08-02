﻿/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PointerMeterHUD.cs
 *  Description  :  Draw slider UI in scene to control meter.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Meter.Demo
{
    public class PointerMeterHUD : MonoBehaviour
    {
        #region Field and Property 
        [Multiline]
        public string title;
        public float top = 10;
        public float left = 10;
        public float min = 0;
        public float max = 360;
        public PointerMeter meter;

        private float slider = 0;
        private float lastSlider = 0;
        #endregion

        #region Private Method
        private void OnGUI()
        {
            GUILayout.Space(top);
            GUILayout.BeginHorizontal();
            GUILayout.Space(left);
            GUILayout.BeginVertical();

            GUILayout.Label(title);
            slider = GUILayout.HorizontalSlider(slider, min, max, GUILayout.Width(250));
            if (slider != lastSlider)
            {
                lastSlider = slider;
                meter.MainAngle = slider;
            }

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }
        #endregion
    }
}