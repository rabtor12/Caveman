﻿using System;
using System.Collections;
using System.Collections.Generic;
using Caveman.Players;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Caveman.UI.Windows
{
    public class ResultRound : Result
    {
        public CNJoystick joystick;

        public void OnEnable()
        {
            if (!isMultiplayer)
            {
                StartCoroutine(DisplayResult());
            }
            else
            {
                joystick.Disable();
            }
        }

        protected override IEnumerator DisplayResult()
        {
            joystick.Disable();
            Time.timeScale = 0.00001f;
            yield return StartCoroutine(base.DisplayResult());
        }

        public void LoadMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}
