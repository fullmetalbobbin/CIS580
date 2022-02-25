using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace FinickyFeline.StateMangement
{
    public abstract class GameScreen
    {
        private bool otherScreenHasFocus;

        protected TimeSpan TransitionToActiveTime { get; set; } = TimeSpan.Zero;
        protected TimeSpan TransitionToHiddenTime { get; set; } = TimeSpan.Zero;
        protected float TransitionPosition { get; set; } = 1;
        public float TransitionAlphaValue => 1f - TransitionPosition;
       
        public ScreenManager CurrentScreenManager { get; internal set; }

        public ScreenState CurrentScreenState { get; set; } = ScreenState.TransitionToActive;

        public bool IsClosingScreen { get; protected internal set; }
        public bool IsPopupScreen { get; protected set; }

        public bool IsActiveScreen => !otherScreenHasFocus && 
            (CurrentScreenState == ScreenState.TransitionToActive || 
             CurrentScreenState == ScreenState.Active);

        public virtual void ActivateScreen() 
        { }

        public virtual void DeactivateScreen()
        { }

        public virtual void UnloadScreen()
        { }

        public virtual void Update()
        { }

        public virtual void Draw()
        { }

        public void ExitScreen()
        {
            if (TransitionToHiddenTime == TimeSpan.Zero)
            {
                //ScreenManager.Remove(this);
            }
            else 
            {
                IsClosingScreen = true;
            }
        }




        
    }
}
