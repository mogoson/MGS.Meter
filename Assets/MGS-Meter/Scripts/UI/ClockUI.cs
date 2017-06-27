/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson tech. Co., Ltd.
 *  FileName: ClockUI.cs
 *  Author: Mogoson   Version: 1.0   Date: 4/5/2016
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.            ClockUI               Ignore.
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

    [AddComponentMenu("Developer/Meter/ClockUI")]
    public class ClockUI : MonoBehaviour
    {
        #region Property and Field
        public float xOffset = 10;
        public float yOffset = 10;
        public Clock clock;
        #endregion

        #region Private Method
        void OnGUI()
        {
            GUILayout.Space(yOffset);
            GUILayout.BeginHorizontal();
            GUILayout.Space(xOffset);
            GUILayout.BeginVertical();

            if (GUILayout.Button("TurnOn"))
                clock.TurnOn();
            if (GUILayout.Button("TurnOff"))
                clock.TurnOff();

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }//OnGUI()_end
        #endregion
    }//class_end
}//namespace_end