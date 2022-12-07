using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// 获取设置element参数服务
    /// </summary>
    public static class ParamUtils
    {
        #region get
        /// <summary>
        /// 获取字符串值(内置参数)
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="builtInParameter"></param>
        /// <returns></returns>
        public static string GetStringValue(this Element instance, BuiltInParameter builtInParameter)
        {
            string value = string.Empty;
            if (instance != null)
            {
                Parameter para = instance.get_Parameter(builtInParameter);

                if (para != null && para.StorageType == StorageType.String)
                    using (para)
                        value = para.AsString();
            }

            return value;
        }
        /// <summary>
        /// 获取字符串值
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static string GetStringValue(this Element instance, string strName)
        {
            string value = string.Empty;

            if (instance != null && !string.IsNullOrEmpty(strName))
            {
                Parameter para = instance.LookupParameter(strName);
                if (para != null && para.StorageType == StorageType.String)
                    using (para)
                        value = para.AsString();
            }

            return value;
        }
        /// <summary>
        /// 获取元素标识(内置参数)
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="builtInParameter"></param>
        /// <returns></returns>
        public static ElementId GetElementId(this Element instance, BuiltInParameter builtInParameter)
        {
            ElementId value = ElementId.InvalidElementId;
            if (instance != null)
            {
                Parameter para = instance.get_Parameter(builtInParameter);
                if (para != null && para.StorageType == StorageType.ElementId)
                    using (para)
                        value = para.AsElementId();
            }

            return value;
        }
        /// <summary>
        /// 获取元素标识
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static ElementId GetElementId(this Element instance, string strName)
        {
            ElementId value = ElementId.InvalidElementId;

            if (instance != null && !string.IsNullOrEmpty(strName))
            {
                Parameter para = instance.LookupParameter(strName);
                if (para != null && para.StorageType == StorageType.ElementId)
                    using (para)
                        value = para.AsElementId();
            }

            return value;
        }
        /// <summary>
        /// 获得双精度类型(内置参数)
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="builtInParameter"></param>
        /// <returns></returns>
        public static double GetDoubleValue(this Element instance, BuiltInParameter builtInParameter)
        {
            double value = 0.0;
            if (instance != null)
            {
                Parameter para = instance.get_Parameter(builtInParameter);
                if (para != null && para.StorageType == StorageType.Double)
                    using (para)
                        value = para.AsDouble();
            }

            return value;
        }
        /// <summary>
        /// 获取字符串(内置参数)
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="builtInParameter"></param>
        /// <param name="formatOptions"></param>
        /// <returns></returns>
        public static string GetValueAsString(this Element instance, BuiltInParameter builtInParameter, FormatOptions formatOptions = null)
        {
            string value = string.Empty;

            if (instance != null)
            {
                Parameter para = instance.get_Parameter(builtInParameter);
                if (para != null)
                    using (para)
                        value = formatOptions == null ? para.AsValueString() : para.AsValueString(formatOptions);
            }

            return value;
        }
        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="strName"></param>
        /// <param name="formatOptions"></param>
        /// <returns></returns>
        public static string GetValueAsString(this Element instance, string strName, FormatOptions formatOptions = null)
        {
            string value = string.Empty;

            if (instance != null)
            {
                Parameter para = instance.LookupParameter(strName);
                if (para != null)
                    using (para)
                        value = formatOptions == null ? para.AsValueString() : para.AsValueString(formatOptions);
            }

            return value;
        }
        /// <summary>
        /// 获取整数(内置参数)
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="builtInParameter"></param>
        /// <returns></returns>
        public static int GetInteger(this Element instance, BuiltInParameter builtInParameter)
        {
            int value = 0;
            if (instance != null)
            {
                Parameter para = instance.get_Parameter(builtInParameter);
                if (para != null && para.StorageType == StorageType.Integer)
                    using (para)
                        value = para.AsInteger();
            }

            return value;
        }
        /// <summary>
        /// 获取整数
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static int GetInteger(this Element instance, string strName)
        {
            int value = 0;
            if (instance != null && !string.IsNullOrEmpty(strName))
            {
                Parameter para = instance.LookupParameter(strName);
                if (para != null && para.StorageType == StorageType.Integer)
                    using (para)
                        value = para.AsInteger();
            }

            return value;
        }
        /// <summary>
        /// 获得双精度类型
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static double GetDoubleValue(this Element instance, string strName)
        {
            double value = 0.0;
            if (instance != null && !string.IsNullOrEmpty(strName))
            {
                Parameter para = instance.LookupParameter(strName);
                if (para != null && para.StorageType == StorageType.Double)
                    using (para)
                        value = para.AsDouble();
            }

            return value;
        }

        #endregion

        #region set
        /// <summary>
        ///  设置双精度类型(内置参数)
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="builtInParameter"></param>
        /// <param name="value"></param>
        public static void SetDoubleValue(this Element instance, BuiltInParameter builtInParameter, double value)
        {
            if (instance != null)
            {
                var param = instance.get_Parameter(builtInParameter);
                if (
                    param != null &&
                    param.StorageType == StorageType.Double &&
                    !param.IsReadOnly)
                    using (param)
                        param.Set(value);
            }
        }
        /// <summary>
        /// 设置双精度类型
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="strName"></param>
        /// <param name="value"></param>
        public static void SetDoubleValue(this Element instance, string strName, double value)
        {
            if (instance != null && !string.IsNullOrEmpty(strName))
            {
                var param = instance.LookupParameter(strName);
                if (
                    param != null &&
                    param.StorageType == StorageType.Double &&
                    !param.IsReadOnly)
                    using (param)
                        param.Set(value);
            }
        }
        /// <summary>
        /// 设置整数类型
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="strName"></param>
        /// <param name="value"></param>
        public static void SetInteger(this Element instance, string strName, int value)
        {
            if (instance != null && !string.IsNullOrEmpty(strName))
            {
                var param = instance.LookupParameter(strName);
                if (
                    param != null &&
                    param.StorageType == StorageType.Integer &&
                    !param.IsReadOnly)
                    using (param)
                        param.Set(value);
            }
        }
        /// <summary>
        /// 设置字符串值
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="strName"></param>
        /// <param name="value"></param>
        public static void SetStringValue(this Element instance, string strName, string value)
        {
            if (instance != null && !string.IsNullOrEmpty(strName))
            {
                var param = instance.LookupParameter(strName);
                if (
                    param != null &&
                    param.StorageType == StorageType.String &&
                    !param.IsReadOnly)
                    using (param)
                        param.Set(value);
            }
        }
        /// <summary>
        /// 设置字符串值(内置参数)
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="builtInParameter"></param>
        /// <param name="value"></param>
        public static void SetStringValue(this Element instance, BuiltInParameter builtInParameter, string value)
        {
            if (instance != null)
            {
                var param = instance.get_Parameter(builtInParameter);
                if (
                    param != null &&
                    param.StorageType == StorageType.String &&
                    !param.IsReadOnly)
                    using (param)
                        param.Set(value);
            }
        }
        /// <summary>
        /// 设置整数(内置参数)
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="builtInParameter"></param>
        /// <param name="value"></param>
        public static void SetInteger(this Element instance, BuiltInParameter builtInParameter, int value)
        {
            if (instance != null)
            {
                var param = instance.get_Parameter(builtInParameter);
                if (
                    param != null &&
                    param.StorageType == StorageType.Integer &&
                    !param.IsReadOnly)
                    using (param)
                        param.Set(value);
            }
        }
        /// <summary>
        /// 设置设置ElmentID(内置参数)
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="builtInParameter"></param>
        /// <param name="value"></param>
        public static void SetElmentId(this Element instance, BuiltInParameter builtInParameter, ElementId value)
        {
            if (instance != null)
            {
                var param = instance.get_Parameter(builtInParameter);
                if (
                    param != null &&
                    param.StorageType == StorageType.ElementId &&
                    !param.IsReadOnly)
                    using (param)
                        param.Set(value);
            }
        }
        /// <summary>
        /// 设置设置ElmentID
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="strName"></param>
        /// <param name="value"></param>
        public static void SetElmentId(this Element instance, string strName, ElementId value)
        {
            if (instance != null && !string.IsNullOrEmpty(strName))
            {
                var param = instance.LookupParameter(strName);
                if (
                    param != null &&
                    param.StorageType == StorageType.ElementId &&
                    !param.IsReadOnly)
                    using (param)
                        param.Set(value);
            }
        }

        #endregion
    }
}
