/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  SliderUI.cs
 *  Description  :  Draw slider UI in scene to control meter.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/5/2016
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Developer.Meter
{
    [AddComponentMenu("Developer/Meter/SliderUI")]
    public class SliderUI : MonoBehaviour
    {
        #region Property and Field
        [Multiline]
        public string title;
        public float xOffset = 10;
        public float yOffset = 10;
        public float min = 0;
        public float max = 360;
        public Meter meter;

        private float slider = 0;
        private float last = 0;
        #endregion

        #region Private Method
        private void OnGUI()
        {
            GUILayout.Space(yOffset);
            GUILayout.BeginHorizontal();
            GUILayout.Space(xOffset);
            GUILayout.BeginVertical();

            GUILayout.Label(title);
            slider = GUILayout.HorizontalSlider(slider, min, max, GUILayout.Width(250));
            if (slider != last)
            {
                last = slider;
                meter.MainAngle = slider;
            }

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }
        #endregion
    }
}