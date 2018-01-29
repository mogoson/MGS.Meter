/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  LerpMeter.cs
 *  Description  :  Define lerp Meter.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/4/2016
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Developer.Meter
{
    /// <summary>
    /// Meter Lerp Type.
    /// </summary>
    public enum LerpType
    {
        Lerp = 0,
        Towards = 1
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
        public float LerpAngle { protected set; get; }
        #endregion

        #region Protected Method
        /// <summary>
        /// On main pointer's angle changed.
        /// </summary>
        /// <param name="mainAngle">Main pointer's angle.</param>
        protected override void OnMainAngleChanged(float mainAngle)
        {
            CheckLerp(mainAngle);
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
                var lastLerp = LerpAngle;
                LerpAngle = Mathf.Lerp(LerpAngle, mainPointerAngle, mainSpeed / 180 * Time.deltaTime);

                var lerpSpeed = Mathf.Abs((LerpAngle - lastLerp) / Time.deltaTime);
                if (lerpSpeed < minSpeed)
                    LerpAngle = Mathf.MoveTowards(lastLerp, mainPointerAngle, minSpeed * Time.deltaTime);
            }
            else
                LerpAngle = Mathf.MoveTowards(LerpAngle, mainPointerAngle, mainSpeed * Time.deltaTime);

            SetPointersAngle(LerpAngle);
            CheckLerp(mainPointerAngle);

            if (OnLerpStay != null)
                OnLerpStay();

            if (!enabled && OnLerpExit != null)
                OnLerpExit();
        }

        /// <summary>
        /// Check need lerp angle.
        /// </summary>
        /// <param name="mainAngle">Main pointer's angle.</param>
        protected void CheckLerp(float mainAngle)
        {
            enabled = mainAngle - LerpAngle != 0;
        }
        #endregion
    }
}