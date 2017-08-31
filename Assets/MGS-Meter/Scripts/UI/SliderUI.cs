/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson tech. Co., Ltd.
 *  FileName: SliderUI.cs
 *  Author: Mogoson   Version: 1.0   Date: 4/5/2016
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.           SliderUI               Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     4/5/2016       1.0        Build this file.
 *************************************************************************/

namespace Developer.Meter
{
    using UnityEngine;

    [AddComponentMenu("Developer/Meter/SliderUI")]
    public class SliderUI : MonoBehaviour
    {
        #region Property and Field
        [Multiline]
        public string title;
        public float xOffset = 10;
        public float yOffset = 10;
        public float min = 0;
        public float max = 720;
        public Meter[] meters;

        private float slider = 0;
        private float last = 0;
        #endregion

        #region Private Method
        void OnGUI()
        {
            GUILayout.Space(yOffset);
            GUILayout.BeginHorizontal();
            GUILayout.Space(xOffset);
            GUILayout.BeginVertical();

            GUILayout.Label(title);
            slider = GUILayout.HorizontalSlider(slider, min, max);
            if (slider != last)
            {
                last = slider;
                foreach (var meter in meters)
                {
                    meter.mainAngle = slider;
                }
            }

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }
        #endregion
    }
}