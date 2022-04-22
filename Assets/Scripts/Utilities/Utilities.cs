using UnityEngine;

namespace UsefulUnityScripts
{
	public static class Utilities
	{
        public static AnimationCurve ScaleCurve(AnimationCurve curve, float maxX, float maxY)
        {
            AnimationCurve scaledCurve = new AnimationCurve();
            for (int i = 0; i < curve.keys.Length; i++)
            {
                Keyframe keyframe = curve.keys[i];
                keyframe.value = curve.keys[i].value * maxY;
                keyframe.time = curve.keys[i].time * maxX;
                keyframe.inTangent = curve.keys[i].inTangent * maxY / maxX;
                keyframe.outTangent = curve.keys[i].outTangent * maxY / maxX;
                
                scaledCurve.AddKey(keyframe);
            }
            return scaledCurve;
        }

        public static AnimationCurve NormalizeCurve(AnimationCurve curve, float maxX, float maxY)
        {
            AnimationCurve normalizedCurve = new AnimationCurve();
            for (int i = 0; i < curve.keys.Length; i++)
            {
                Keyframe keyframe = curve.keys[i];
                keyframe.value = curve.keys[i].value / maxY;
                keyframe.time = curve.keys[i].time / maxX;
                keyframe.inTangent = curve.keys[i].inTangent / maxY * maxX;
                keyframe.outTangent = curve.keys[i].outTangent / maxY * maxX;

                normalizedCurve.AddKey(keyframe);
            }
            return normalizedCurve;
        }
    } 
}
