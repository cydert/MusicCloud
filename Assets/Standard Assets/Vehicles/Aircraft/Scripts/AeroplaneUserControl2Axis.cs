using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
    [RequireComponent(typeof (AeroplaneController))]
    public class AeroplaneUserControl2Axis : MonoBehaviour
    {
        // these max angles are only used on mobile, due to the way pitch and roll input are handled
        public float maxRollAngle = 50;
        public float maxPitchAngle = 50;
        public bool startBoot = false;
        private float throttle = 0;  //現在のスロットル
        private float throttleMax = 1;

        // reference to the aeroplane that we're controlling
        private AeroplaneController m_Aeroplane;

        void Start()
        {
            throttle = throttleMax;
        }

        private void Awake()
        {
            // Set up the reference to the aeroplane controller.
            m_Aeroplane = GetComponent<AeroplaneController>();
        }


        private void FixedUpdate()
        {
            // Read input for the pitch, yaw, roll and throttle of the aeroplane.
            float roll = CrossPlatformInputManager.GetAxis("Horizontal");
            float pitch = CrossPlatformInputManager.GetAxis("Vertical");
            bool airBrakes = CrossPlatformInputManager.GetButton("PowerDown");

            // auto throttle up, or down if braking.
            //float throttle = airBrakes ? -1 : 1;
#if MOBILE_INPUT
            AdjustInputForMobileControls(ref roll, ref pitch, ref throttle);
#endif
            if (Input.GetButton("PowerUp") && throttle < throttleMax)
            {
                throttle += 0.02f;
            }

            if (Input.GetButton("PowerDown") && throttle > -throttleMax)
            {
                throttle -= 0.02f;
            }
            // Pass the input to the aeroplane
            //Debug.Log(throttle);  //スロットル
            //Debug.Log(m_Aeroplane.ForwardSpeed); //速度(10以下で失速)
            m_Aeroplane.Move(roll, pitch, 0, throttle, airBrakes);  //移動
            

        }


        private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
        {
            // because mobile tilt is used for roll and pitch, we help out by
            // assuming that a centered level device means the user
            // wants to fly straight and level!

            // this means on mobile, the input represents the *desired* roll angle of the aeroplane,
            // and the roll input is calculated to achieve that.
            // whereas on non-mobile, the input directly controls the roll of the aeroplane.

            float intendedRollAngle = roll*maxRollAngle*Mathf.Deg2Rad;
            float intendedPitchAngle = pitch*maxPitchAngle*Mathf.Deg2Rad;
            roll = Mathf.Clamp((intendedRollAngle - m_Aeroplane.RollAngle), -1, 1);
            pitch = Mathf.Clamp((intendedPitchAngle - m_Aeroplane.PitchAngle), -1, 1);

            // similarly, the throttle axis input is considered to be the desired absolute value, not a relative change to current throttle.
            float intendedThrottle = throttle*0.5f + 0.5f;
            throttle = Mathf.Clamp(intendedThrottle - m_Aeroplane.Throttle, -1, 1);
        }
    }
}
