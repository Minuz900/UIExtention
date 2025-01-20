using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExFoundation
{
    // UI 확장 메소드.
    public static class UIExtention
    {
        #region enum

        public enum AnchorPresets
        {
            TopLeft,
            TopCenter,
            TopRight,

            MiddleLeft,
            MiddleCenter,
            MiddleRight,

            BottomLeft,
            BottonCenter,
            BottomRight,
            BottomStretch,

            VertStretchLeft,
            VertStretchRight,
            VertStretchCenter,

            HorStretchTop,
            HorStretchMiddle,
            HorStretchBottom,

            StretchAll
        }

        #endregion


        #region RectTransform

        /// <summary>
        /// LocalPosition - Pos X, Y, Z 값을 조절.  기본은 Zero.
        /// </summary>
        /// <param name="x">설정 할 X 값.</param>
        /// <param name="y">설정 할 Y 값.</param>
        /// <param name="z">설정 할 Z 값.</param>
        public static void SetLocalPosition<T>(this T original, float x = 0, float y = 0, float z = 0) where T : Component
        {
            if (original)
            {
                original.transform.localPosition = new Vector3(x, y, z);
            }
        }

        /// <summary>
        /// LocalPosition - Pos X 값만 조절.
        /// </summary>
        /// <param name="x">설정 할 X 값.</param>
        public static void SetLocalPositionX<T>(this T original, float x) where T : Component
        {
            if (original)
            {
                original.transform.localPosition = new Vector3(x, original.transform.localPosition.y, original.transform.localPosition.z);
            }
        }

        /// <summary>
        /// LocalPosition - Pos Y 값을 조절.
        /// </summary>
        /// <param name="y">설정 할 Y 값.</param>
        public static void SetLocalPositionY<T>(this T original, float y) where T : Component
        {
            if (original)
            {
                original.transform.localPosition = new Vector3(original.transform.localPosition.x, y, original.transform.localPosition.z);
            }
        }

        /// <summary>
        /// LocalPosition - Pos Z 값을 조절.
        /// </summary>
        /// <param name="z">설정 할 Z 값.</param>
        public static void SetLocalPositionZ<T>(this T original, float z) where T : Component
        {
            if (original)
            {
                original.transform.localPosition = new Vector3(original.transform.localPosition.x, original.transform.localPosition.y, z);
            }
        }

        /// <summary>
        ///  RectTransform Size 를 조절.
        /// </summary>
        /// <param name="width">설정 할 Width 값.</param>
        /// <param name="height">설정 할 Height 값.</param>
        public static void SetSize<T>(this T original, float width = 0, float height = 0) where T : Component
        {
            if (original)
            {
                RectTransform rectTransform = original.transform as RectTransform;
                if (rectTransform)
                {
                    rectTransform.sizeDelta = new Vector2(width, height);
                }
            }
        }

        /// <summary>
        /// RectTransform Width 를 조절.
        /// </summary>
        /// <param name="width">설정 할 Width 값.</param>
        public static void SetSizeWidth<T>(this T original, float width = 0) where T : Component
        {
            if (original)
            {
                RectTransform rectTransform = original.transform as RectTransform;
                if (rectTransform)
                {
                    rectTransform.sizeDelta = new Vector2(width, rectTransform.sizeDelta.y);
                }
            }
        }

        /// <summary>
        /// RectTransform Height 를 조절.
        /// </summary>
        /// <param name="height">설정 할 Height 값.</param>
        public static void SetSizeHeight<T>(this T original, float height = 0) where T : Component
        {
            if (original)
            {
                RectTransform rectTransform = original.transform as RectTransform;
                if (rectTransform)
                {
                    rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);
                }
            }
        }

        public static void SetAnchors<T>(this T original, float minX = 0, float minY = 0, float maxX = 0, float maxY = 0) where T : Component
        {
            if (original)
            {
                RectTransform rectTransform = original.transform as RectTransform;
                if (rectTransform)
                {
                    rectTransform.anchorMin = new Vector2(minX, minY);
                    rectTransform.anchorMax = new Vector2(maxX, maxY);
                }
            }
        }


        public static void SetAnchors<T>(this T original, AnchorPresets allign, int offsetX = 0, int offsetY = 0) where T : Component
        {
            if (original)
            {
                RectTransform rectTransform = original.transform as RectTransform;

                if (rectTransform)
                {
                    rectTransform.anchoredPosition = new Vector3(offsetX, offsetY, 0);

                    switch (allign)
                    {
                        case AnchorPresets.TopLeft:
                            {
                                rectTransform.anchorMin = new Vector2(0, 1);
                                rectTransform.anchorMax = new Vector2(0, 1);
                                break;
                            }
                        case AnchorPresets.TopCenter:
                            {
                                rectTransform.anchorMin = new Vector2(0.5f, 1);
                                rectTransform.anchorMax = new Vector2(0.5f, 1);
                                break;
                            }
                        case (AnchorPresets.TopRight):
                            {
                                rectTransform.anchorMin = new Vector2(1, 1);
                                rectTransform.anchorMax = new Vector2(1, 1);
                                break;
                            }

                        case (AnchorPresets.MiddleLeft):
                            {
                                rectTransform.anchorMin = new Vector2(0, 0.5f);
                                rectTransform.anchorMax = new Vector2(0, 0.5f);
                                break;
                            }
                        case (AnchorPresets.MiddleCenter):
                            {
                                rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                                rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                                break;
                            }
                        case (AnchorPresets.MiddleRight):
                            {
                                rectTransform.anchorMin = new Vector2(1, 0.5f);
                                rectTransform.anchorMax = new Vector2(1, 0.5f);
                                break;
                            }

                        case (AnchorPresets.BottomLeft):
                            {
                                rectTransform.anchorMin = new Vector2(0, 0);
                                rectTransform.anchorMax = new Vector2(0, 0);
                                break;
                            }
                        case (AnchorPresets.BottonCenter):
                            {
                                rectTransform.anchorMin = new Vector2(0.5f, 0);
                                rectTransform.anchorMax = new Vector2(0.5f, 0);
                                break;
                            }
                        case (AnchorPresets.BottomRight):
                            {
                                rectTransform.anchorMin = new Vector2(1, 0);
                                rectTransform.anchorMax = new Vector2(1, 0);
                                break;
                            }

                        case (AnchorPresets.HorStretchTop):
                            {
                                rectTransform.anchorMin = new Vector2(0, 1);
                                rectTransform.anchorMax = new Vector2(1, 1);
                                break;
                            }
                        case (AnchorPresets.HorStretchMiddle):
                            {
                                rectTransform.anchorMin = new Vector2(0, 0.5f);
                                rectTransform.anchorMax = new Vector2(1, 0.5f);
                                break;
                            }
                        case (AnchorPresets.HorStretchBottom):
                            {
                                rectTransform.anchorMin = new Vector2(0, 0);
                                rectTransform.anchorMax = new Vector2(1, 0);
                                break;
                            }

                        case (AnchorPresets.VertStretchLeft):
                            {
                                rectTransform.anchorMin = new Vector2(0, 0);
                                rectTransform.anchorMax = new Vector2(0, 1);
                                break;
                            }
                        case (AnchorPresets.VertStretchCenter):
                            {
                                rectTransform.anchorMin = new Vector2(0.5f, 0);
                                rectTransform.anchorMax = new Vector2(0.5f, 1);
                                break;
                            }
                        case (AnchorPresets.VertStretchRight):
                            {
                                rectTransform.anchorMin = new Vector2(1, 0);
                                rectTransform.anchorMax = new Vector2(1, 1);
                                break;
                            }

                        case (AnchorPresets.StretchAll):
                            {
                                rectTransform.anchorMin = new Vector2(0, 0);
                                rectTransform.anchorMax = new Vector2(1, 1);
                                break;
                            }
                    }
                }
            }
        }

        /// <summary>
        /// LocalScale -  Vector3.zero로 설정.
        /// </summary>
        public static void SetLocalScaleZero<T>(this T original) where T : Component
        {
            if (original)
            {
                original.transform.localScale = Vector3.zero;
            }
        }

        /// <summary>
        /// LocalScale -  Vector3.one로 설정.
        /// </summary>
        public static void SetLocalScaleOne<T>(this T original) where T : Component
        {
            if (original)
            {
                original.transform.localScale = Vector3.one;
            }
        }

        #endregion

    }
}