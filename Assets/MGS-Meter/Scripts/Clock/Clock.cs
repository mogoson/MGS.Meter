/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson tech. Co., Ltd.
 *  FileName: Clock.cs
 *  Author: Mogoson   Version: 1.0   Date: 4/5/2016
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.            Clock                 Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     4/5/2016       1.0        Build this file.
 *************************************************************************/

namespace Developer.Meter
{
    using System;
    using UnityEngine;

    [AddComponentMenu("Developer/Meter/Clock")]
    public class Clock : MonoBehaviour
    {
        #region Property and Field
        /// <summary>
        /// Pointer of clock.
        /// Hour, minute, second pointer.
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