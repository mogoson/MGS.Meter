/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Clock.cs
 *  Description  :  Define clock with Hour, Minute and Second pointers.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.Meter
{
    /// <summary>
    /// Clock with Hour, Minute and Second pointers.
    /// </summary>
    public class Clock : MonoBehaviour, IClock
    {
        #region Field and Property
        /// <summary>
        /// Hour pointer of clock.
        /// </summary>
        public Transform hour;

        /// <summary>
        /// Minute pointer of clock.
        /// </summary>
        public Transform minute;

        /// <summary>
        /// Second pointer of clock.
        /// </summary>
        public Transform second;

        /// <summary>
        /// Record last second.
        /// </summary>
        protected int lastSecond;

        /// <summary>
        /// Audio source of clock.
        /// </summary>
        protected AudioSource audioSource;
        #endregion

        #region Private Method
        /// <summary>
        /// Component awake.
        /// </summary>
        protected virtual void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource)
            {
                audioSource.enabled = true;
                audioSource.playOnAwake = audioSource.loop = false;
            }
            lastSecond = DateTime.Now.Second;
        }

        /// <summary>
        /// Update pointer rotate angles.
        /// </summary>
        protected virtual void Update()
        {
            if (lastSecond == DateTime.Now.Second)
            {
                return;
            }

            //Record last second.
            lastSecond = DateTime.Now.Second;

            //Update pointers angle.
            SetPointerAngle(hour, DateTime.Now.Hour % 12 * 30 + DateTime.Now.Minute * 0.5f + lastSecond / 120);
            SetPointerAngle(minute, DateTime.Now.Minute * 6 + lastSecond * 0.1f);
            SetPointerAngle(second, lastSecond * 6);

            //Play tick.
            if (audioSource)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
        }

        /// <summary>
        /// Set pointer rotation angle.
        /// </summary>
        /// <param name="pointer">Transform of pointer.</param>
        /// <param name="angle">Rotation angle.</param>
        protected void SetPointerAngle(Transform pointer, float angle)
        {
            pointer.localRotation = Quaternion.Euler(Vector3.back * angle);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Turn on clock.
        /// </summary>
        public virtual void TurnOn()
        {
            lastSecond = DateTime.Now.Second;
            enabled = true;
        }

        /// <summary>
        /// Turn off clock.
        /// </summary>
        public virtual void TurnOff()
        {
            enabled = false;
        }
        #endregion
    }
}