/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  Clock.cs
 *  Description  :  Define clock.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/5/2016
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace Developer.Meter
{
    [AddComponentMenu("Developer/Meter/Clock")]
    public class Clock : MonoBehaviour
    {
        #region Property and Field
        /// <summary>
        /// Pointer of clock.
        /// Hour, Minute, Second pointer.
        /// </summary>
        public Transform[] pointers = new Transform[3];

        /// <summary>
        /// Last record second.
        /// </summary>
        protected int lastSecond;

        /// <summary>
        /// Audio source of clock.
        /// </summary>
        protected AudioSource audioSource;
        #endregion

        #region Private Method
        protected virtual void Start()
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource)
            {
                audioSource.enabled = true;
                audioSource.playOnAwake = audioSource.loop = false;
            }
            lastSecond = DateTime.Now.Second;
        }

        protected virtual void Update()
        {
            if (lastSecond == DateTime.Now.Second)
                return;

            //Record last second.
            lastSecond = DateTime.Now.Second;

            //Update pointers angle.
            SetLocalRotation(0, DateTime.Now.Hour % 12 * 30 + DateTime.Now.Minute * 0.5f + lastSecond / 120);
            SetLocalRotation(1, DateTime.Now.Minute * 6 + lastSecond * 0.1f);
            SetLocalRotation(2, lastSecond * 6);

            //Play tick.
            if (audioSource)
                audioSource.PlayOneShot(audioSource.clip);
        }

        /// <summary>
        /// Set pointer local rotation.
        /// </summary>
        /// <param name="index">Pointer's index.</param>
        /// <param name="angle">Angle of z axis.</param>
        protected void SetLocalRotation(int index, float angle)
        {
            pointers[index].localRotation = Quaternion.Euler(Vector3.back * angle);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Turn on clock.
        /// </summary>
        public void TurnOn()
        {
            lastSecond = DateTime.Now.Second;
            enabled = true;
        }

        /// <summary>
        /// Turn off clock.
        /// </summary>
        public void TurnOff()
        {
            enabled = false;
        }
        #endregion
    }
}