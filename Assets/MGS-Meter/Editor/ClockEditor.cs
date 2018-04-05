/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ClockEditor.cs
 *  Description  :  Editor for Clock component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEditor;

namespace Mogoson.Meter
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
            DrawPointer(Target.pointer.hour);
            DrawPointer(Target.pointer.minute);
            DrawPointer(Target.pointer.second);
        }
        #endregion
    }
}