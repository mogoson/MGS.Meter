/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PointerClockEditor.cs
 *  Description  :  Editor for PointerClock component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEditor;

namespace MGS.Meter.Editors
{
    [CustomEditor(typeof(Clock), true)]
    [CanEditMultipleObjects]
    public class ClockEditor : MeterEditor
    {
        #region Field and Property 
        protected new Clock Target { get { return target as Clock; } }
        #endregion

        #region Protected Method
        protected override void OnSceneGUI()
        {
            DrawPointer(Target.hour);
            DrawPointer(Target.minute);
            DrawPointer(Target.second);
        }
        #endregion
    }
}