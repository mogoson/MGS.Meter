/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson tech. Co., Ltd.
 *  FileName: LerpMeter.cs
 *  Author: Mogoson   Version: 1.0   Date: 4/4/2016
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.          LerpMeter               Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     4/4/2016       1.0        Build this file.
 *************************************************************************/

namespace Developer.Meter
{
    using UnityEngine;

    /// <summary>
    /// Meter Lerp Type.
    /// </summary>
    public enum LerpType
    {
        Lerp, Towards
    }

    /// <summary>
    /// Meter Lerp Event.
    /// </summary>
    public delegate void LerpEvent();

    [AddComponentMenu("Developer/Meter/LerpMeter")]
    public class LerpMeter : Meter
    {
        #region Property and Field
        /// <summary>
        /// Meter lerp type.
        /// </summary>
        public LerpType lerpType;

        /// <summary>
        /// Speed of main pointer.
        /// </summary>
        public float mainSpeed = 120;

        /// <summary>
        /// Min speed of main pointer.
        /// </summary>
        [HideInInspector]
        public float minSpeed = 30;

        /// <summary>
        /// Call on start lerp.
        /// </summary>
        public LerpEvent OnLerpStart;

        /// <summary>
        /// Call on stay lerp.
        /// </summary>
        public LerpEvent OnLerpStay;

        /// <summary>
        /// Call on exit lerp.
        /// </summary>
        public LerpEvent OnLerpExit;

        /// <summary>
        /// Current lerp value of main angle.
        /// </summary>
        public float lerpAngle { protected set; get; }
        #endregion

        #region Protected Method
        /// <summary>
        /// On main pointer's angle changed.
        /// </summary>
        protected override void OnMainAngleChanged()
        {
            CheckLerp();
            if (enabled && OnLerpStart != null)
                OnLerpStart();
        }

        /// <summary>
        /// Drive pointers to target angle.
        /// </summary>
        protected virtual void Update()
        {
            if (lerpType == LerpType.Lerp)
            {
                var lastLerp = lerpAngle;
                lerpAngle = Mathf.Lerp(lerpAngle, mAngle, mainSpeed / 180 * Time.deltaTime);
                var lerpSpeed = Mathf.Abs((lerpAngle - lastLerp) / Time.deltaTime);
                if (lerpSpeed < minSpeed)
                    lerpAngle = Mathf.MoveTowards(lastLerp, mAngle, minSpeed * Time.deltaTime);
            }
            else
                lerpAngle = Mathf.MoveTowards(lerpAngle, mAngle, mainSpeed * Time.deltaTime);
            SetPointersAngle(lerpAngle);
            CheckLerp();
            if (OnLerpStay != null)
                OnLerpStay();
            if (!enabled && OnLerpExit != null)
                OnLerpExit();
        }

        /// <summary>
        /// Check angle lerp.
        /// </summary>
        protected void CheckLerp()
        {
            enabled = mAngle - lerpAngle != 0;
        }
        #endregion
    }
}