/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LerpPointerMeter.cs
 *  Description  :  Define lerp Meter.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Meter
{
    /// <summary>
    /// Meter with lerp rotate pointers.
    /// </summary>
    [AddComponentMenu("MGS/Meter/Lerp Meter")]
    public class LerpMeter : Meter
    {
        #region Field and Property
        /// <summary>
        /// Meter lerp mode.
        /// </summary>
        [HideInInspector]
        public LerpMode lerpMode;

        /// <summary>
        /// Speed of main pointer.
        /// </summary>
        [HideInInspector]
        public float mainSpeed = 120;

        /// <summary>
        /// Min speed of main pointer.
        /// </summary>
        [HideInInspector]
        public float minSpeed = 30;

        /// <summary>
        /// Pointers dest angles.
        /// </summary>
        protected float[] destAngles;

        /// <summary>
        /// Pointers lerp angles.
        /// </summary>
        protected float[] lerpAngles;
        #endregion

        #region Protected Method
        /// <summary>
        /// Component awake.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            destAngles = new float[pointers.Length];
            lerpAngles = new float[pointers.Length];
        }

        /// <summary>
        /// Drive pointers to target angle.
        /// </summary>
        protected virtual void Update()
        {
            for (int i = 0; i < pointers.Length; i++)
            {
                LerpPointer(i);
            }
            enabled = CheckNeedLerp();
        }

        /// <summary>
        /// Lerp pointer rotation.
        /// </summary>
        /// <param name="index"></param>
        protected void LerpPointer(int index)
        {
            var lerpAngle = lerpAngles[index];
            var destAngle = destAngles[index];
            if (lerpMode == LerpMode.Lerp)
            {
                var lastLerp = lerpAngle;
                lerpAngle = Mathf.Lerp(lerpAngle, destAngle, mainSpeed / 180 * Time.deltaTime);
                var lerpSpeed = Mathf.Abs((lerpAngle - lastLerp) / Time.deltaTime);
                if (lerpSpeed < minSpeed)
                {
                    lerpAngle = Mathf.MoveTowards(lastLerp, destAngle, minSpeed * Time.deltaTime);
                }
            }
            else
            {
                lerpAngle = Mathf.MoveTowards(lerpAngle, destAngle, mainSpeed * Time.deltaTime);
            }

            lerpAngles[index] = lerpAngle;
            SetPointerAngle(index, lerpAngle);
        }

        /// <summary>
        /// Check need lerp angle.
        /// </summary>
        /// <returns></returns>
        protected bool CheckNeedLerp()
        {
            for (int i = 0; i < pointers.Length; i++)
            {
                if (lerpAngles[i] != destAngles[i])
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Refresh meter value.
        /// </summary>
        /// <param name="index">Index of part.</param>
        /// <param name="value">Value of part.</param>
        public override void Refresh(int index, float value)
        {
            destAngles[index] = value;
            enabled = CheckNeedLerp();
        }
        #endregion
    }
}