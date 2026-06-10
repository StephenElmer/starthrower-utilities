// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Globalization;
using StarThrower.Logging;

namespace StarThrower.DataUtilities
{
    /// <summary>
    /// A collection of functions that are useful when working with databases.
    /// </summary>
    /// <remarks>
    /// This class provices a set of wrapper functions for safely accessing recordset data.
    /// </remarks>
    public static class DataUtil
    {
        /// <summary>
        /// A DateTime which is used throughout the StarThrower Utilities to represent a null valued date.
        /// </summary>
        /// <remarks>
        /// The value of this constant is equivalent to DateTime.MinValue  (00:00:00.0000000, January 1, 0001).
        /// </remarks>
        public readonly static DateTime DTNull = DateTime.MinValue;

        public static bool CheckFieldExists(DbDataReader dr, string fieldName)
        {
            bool result = false;
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i) == fieldName)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static bool CheckFieldExists(OleDbDataReader dr, string fieldName)
            => CheckFieldExists((DbDataReader)dr, fieldName);


        #region [ Boolean ]

        /// <summary>
        /// Safely retrieves boolean data from a field in  a DataRow
        /// </summary>
        /// <param name="dataRow">The DataRow object</param>
        /// <param name="fieldName">The name of the field</param>
        /// <returns>The boolean value of the field.  False if the field is null, DBNull, or an error is thrown.</returns>
        /// <exception cref="ArgumentNullException">Thrown if dataRow or fieldName are null.</exception>
        /// <exception cref="ArgumentException">Thrown if fieldName is not a valid field in dataRow.</exception>
        public static bool GetBooleanField(DataRow? dataRow, string? fieldName)
        {
            ArgumentNullException.ThrowIfNull(dataRow);
            ArgumentNullException.ThrowIfNull(fieldName);

            try
            {
                if (dataRow[fieldName] == null) return false;
                if (dataRow[fieldName] is DBNull) return false;
                if (dataRow[fieldName].ToString() == "1") return true; //SQL Server
                if (string.Equals(dataRow[fieldName].ToString(), "True", StringComparison.OrdinalIgnoreCase)) return true; //Access ?
                return false;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetBooleanField(DataRow, string)", ex);
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static bool GetBoolField(DataRow? dr, string? field)
        {
            return GetBoolField(dr, field, false);
        }

        public static bool GetBoolField(DbDataReader? dr, string? field)
            => GetBoolField(dr, field, false);

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static bool GetBoolField(OleDbDataReader dr, string field)
            => GetBoolField((DbDataReader)dr, field);

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool GetBoolField(DataRow? dr, string? field, bool defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            bool result = defaultValue;
            try
            {
                if (!(dr[field] is DBNull))
                {
                    result = Convert.ToBoolean(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetBoolField(DataRow, string, bool)", ex);
                throw;
            }
            return result;
        }

        public static bool GetBoolField(DbDataReader? dr, string? field, bool defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            bool result = defaultValue;
            try
            {
                if (!(dr[field] is DBNull))
                {
                    result = Convert.ToBoolean(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetBoolField(DbDataReader, string, bool)", ex);
                throw;
            }
            return result;
        }

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static bool GetBoolField(OleDbDataReader dr, string field, bool defaultValue)
            => GetBoolField((DbDataReader)dr, field, defaultValue);

        #endregion


        #region [ String ]

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string GetStringField(DataRow? dr, string? field)
        {
            return GetStringField(dr, field, String.Empty);
        }

        public static string GetStringField(DbDataReader? dr, string? field)
            => GetStringField(dr, field, String.Empty);

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static string GetStringField(OleDbDataReader dr, string field)
            => GetStringField((DbDataReader)dr, field);

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetStringField(DataRow? dr, string? field, string defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);
            ArgumentNullException.ThrowIfNull(defaultValue);

            string result = defaultValue;
            try
            {
                if ((dr[field] != null) && !(dr[field] is DBNull))
                {
                    result = dr[field].ToString() ?? result;
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetStringField(DataRow, string, string)", ex);
                throw;
            }
            return result;
        }

        public static string GetStringField(DbDataReader? dr, string? field, string defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);
            ArgumentNullException.ThrowIfNull(defaultValue);

            string result = defaultValue;
            try
            {
                if (!(dr[field] is DBNull))
                {
                    result = dr[field].ToString() ?? result;
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetStringField(DbDataReader, string, string)", ex);
                throw;
            }
            return result;
        }

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static string GetStringField(OleDbDataReader dr, string field, string defaultValue)
            => GetStringField((DbDataReader)dr, field, defaultValue);

        #endregion


        #region [ DateTime ]

        /// <summary>
        /// See: http://www.sqlteam.com/article/working-with-time-spans-and-durations-in-sql-server
        /// </summary>
        /// <param name="sqlDateTime"></param>
        /// <returns></returns>
        public static TimeSpan? GetTimeSpanFromSQLDateTime(DateTime? sqlDateTime)
        {
            TimeSpan? result;
            if (sqlDateTime.HasValue)
            {
                DateTime baseDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
                DateTime val = sqlDateTime.Value;
                result = val.Subtract(baseDate);
            }
            else
            {
                result = null;
            }
            return result;
        }

        public static DateTime? GetSQLDateTimeFromTimeSpan(TimeSpan? timeSpan)
        {
            DateTime? result;
            if (timeSpan.HasValue)
            {
                DateTime baseDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
                TimeSpan val = timeSpan.Value;
                result = baseDate.Add(val);
            }
            else
            {
                result = null;
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static DateTime GetDateTimeField(DataRow? dr, string? field)
        {
            return GetDateTimeField(dr, field, DateTime.Now);
        }

        public static DateTime GetDateTimeField(DbDataReader? dr, string? field)
            => GetDateTimeField(dr, field, DateTime.Now);

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static DateTime GetDateTimeField(OleDbDataReader dr, string field)
            => GetDateTimeField((DbDataReader)dr, field);

        /// <summary>
        /// Safely retrieves DateTime data from a field in  a DataRow
        /// </summary>
        /// <param name="dr">The DataRow object</param>
        /// <param name="field">The name of the field</param>
        /// <param name="defaultValue"></param>
        /// <returns>The DateTime value of the field.  The value specified by defaultValue if the field is null, DBNull, or an error is thrown.</returns>
        /// <exception cref="ArgumentNullException">Thrown if dr or field are null.</exception>
        /// <exception cref="DataAccessException">Thrown if there is an error with respect to database communications and/or execution.</exception>
        public static DateTime GetDateTimeField(DataRow? dr, string? field, DateTime defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            DateTime result = defaultValue;
            try
            {
                if ((dr[field] != null) && !(dr[field] is DBNull))
                {
                    result = Convert.ToDateTime(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetDateTimeField(DataRow, string, DateTime)", ex);
                throw;
            }
            return result;
        }

        public static DateTime GetDateTimeField(DbDataReader? dr, string? field, DateTime defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            DateTime result = defaultValue;
            try
            {
                if (!(dr[field] is DBNull))
                {
                    result = Convert.ToDateTime(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetDateTimeField(DbDataReader, string, DateTime)", ex);
                throw;
            }
            return result;
        }

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static DateTime GetDateTimeField(OleDbDataReader dr, string field, DateTime defaultValue)
            => GetDateTimeField((DbDataReader)dr, field, defaultValue);

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static Nullable<DateTime> GetNullableDateTimeField(DataRow? dr, string? field)
        {
            return GetNullableDateTimeField(dr, field, null);
        }

        public static Nullable<DateTime> GetNullableDateTimeField(DbDataReader? dr, string? field)
            => GetNullableDateTimeField(dr, field, null);

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static Nullable<DateTime> GetNullableDateTimeField(OleDbDataReader dr, string field)
            => GetNullableDateTimeField((DbDataReader)dr, field);

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Nullable<DateTime> GetNullableDateTimeField(DataRow? dr, string? field, Nullable<DateTime> defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            Nullable<DateTime> result = defaultValue;
            try
            {
                if ((!(dr[field] is DBNull)) && !String.IsNullOrEmpty(dr[field].ToString()?.Trim()))
                {
                    result = Convert.ToDateTime(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetNullableDateTimeField(DataRow, string, Nullable<DateTime>)", ex);
                throw;
            }
            return result;
        }

        public static Nullable<DateTime> GetNullableDateTimeField(DbDataReader? dr, string? field, Nullable<DateTime> defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            Nullable<DateTime> result = defaultValue;
            try
            {
                if ((!(dr[field] is DBNull)) && !String.IsNullOrEmpty(dr[field].ToString()?.Trim()))
                {
                    result = Convert.ToDateTime(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetNullableDateTimeField(DbDataReader, string, Nullable<DateTime>)", ex);
                throw;
            }
            return result;
        }

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static Nullable<DateTime> GetNullableDateTimeField(OleDbDataReader dr, string field, Nullable<DateTime> defaultValue)
            => GetNullableDateTimeField((DbDataReader)dr, field, defaultValue);

        #endregion


        #region [ Single / Float ]

        /// <summary>
        /// Safely retrieves float data from a field in  a DataRow
        /// </summary>
        /// <param name="dataRow">The DataRow object</param>
        /// <param name="fieldName">The name of the field</param>
        /// <returns>The float value of the field.  0.0f if the field is null, DBNull, or an error is thrown.</returns>
        /// <exception cref="ArgumentNullException">Thrown if dataRow or fieldName are null.</exception>
        public static float GetSingleField(DataRow? dataRow, string? fieldName)
        {
            ArgumentNullException.ThrowIfNull(dataRow);
            ArgumentNullException.ThrowIfNull(fieldName);

            try
            {
                if (dataRow[fieldName] == null) return 0.0f;
                if (dataRow[fieldName] is DBNull) return 0.0f;
                return Convert.ToSingle(dataRow[fieldName], CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetSingleField(DataRow, string)", ex);
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static float GetFloatField(DataRow? dr, string? field)
        {
            return GetFloatField(dr, field, 0);
        }

        public static float GetFloatField(DbDataReader? dr, string? field)
            => GetFloatField(dr, field, 0);

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static float GetFloatField(OleDbDataReader dr, string field)
            => GetFloatField((DbDataReader)dr, field);

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static float GetFloatField(DataRow? dr, string? field, float defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            float result = defaultValue;
            try
            {
                if (!(dr[field] is DBNull))
                {
                    result = Convert.ToSingle(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetFloatField(DataRow, string, float)", ex);
                throw;
            }
            return result;
        }

        public static float GetFloatField(DbDataReader? dr, string? field, float defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            float result = defaultValue;
            try
            {
                if (!(dr[field] is DBNull))
                {
                    result = Convert.ToSingle(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetFloatField(DbDataReader, string, float)", ex);
                throw;
            }
            return result;
        }

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static float GetFloatField(OleDbDataReader dr, string field, float defaultValue)
            => GetFloatField((DbDataReader)dr, field, defaultValue);

        #endregion


        #region [ Double ]

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static double GetDoubleField(DataRow? dr, string? field)
        {
            return GetDoubleField(dr, field, 0.0);
        }

        public static double GetDoubleField(DbDataReader? dr, string? field)
            => GetDoubleField(dr, field, 0.0);

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static double GetDoubleField(OleDbDataReader dr, string field)
            => GetDoubleField((DbDataReader)dr, field);

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double GetDoubleField(DataRow? dr, string? field, double defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            double result = defaultValue;
            try
            {
                if (!(dr[field] is DBNull))
                {
                    result = Convert.ToDouble(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetDoubleField(DataRow, string, double)", ex);
                throw;
            }
            return result;
        }

        public static double GetDoubleField(DbDataReader? dr, string? field, double defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            double result = defaultValue;
            try
            {
                if (!(dr[field] is DBNull))
                {
                    result = Convert.ToDouble(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetDoubleField(DbDataReader, string, double)", ex);
                throw;
            }
            return result;
        }

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static double GetDoubleField(OleDbDataReader dr, string field, double defaultValue)
            => GetDoubleField((DbDataReader)dr, field, defaultValue);

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static Nullable<double> GetNullableDoubleField(DataRow? dr, string? field)
        {
            return GetNullableDoubleField(dr, field, null);
        }

        public static Nullable<double> GetNullableDoubleField(DbDataReader? dr, string? field)
            => GetNullableDoubleField(dr, field, null);

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static Nullable<double> GetNullableDoubleField(OleDbDataReader dr, string field)
            => GetNullableDoubleField((DbDataReader)dr, field);

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Nullable<double> GetNullableDoubleField(DataRow? dr, string? field, Nullable<double> defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            Nullable<double> result = defaultValue;
            try
            {
                if ((!(dr[field] is DBNull)) && !String.IsNullOrEmpty(dr[field].ToString()?.Trim()))
                {
                    result = Convert.ToDouble(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetDoubleField(DataRow, string, Nullable<double>)", ex);
                throw;
            }
            return result;
        }

        public static Nullable<double> GetNullableDoubleField(DbDataReader? dr, string? field, Nullable<double> defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            Nullable<double> result = defaultValue;
            try
            {
                if ((!(dr[field] is DBNull)) && !String.IsNullOrEmpty(dr[field].ToString()?.Trim()))
                {
                    result = Convert.ToDouble(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetNullableDoubleField(DbDataReader, string, Nullable<double>)", ex);
                throw;
            }
            return result;
        }

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static Nullable<double> GetNullableDoubleField(OleDbDataReader dr, string field, Nullable<double> defaultValue)
            => GetNullableDoubleField((DbDataReader)dr, field, defaultValue);

        #endregion


        #region [ long / Int64 ]

        /// <summary>
        /// Safely retrieves int data from a field in  a DataRow
        /// </summary>
        /// <param name="dataRow">The DataRow object</param>
        /// <param name="fieldName">The name of the field</param>
        /// <returns>The long value of the field.  0 if the field is null, DBNull, or an error is thrown.</returns>
        /// <exception cref="ArgumentNullException">Thrown if dataRow or fieldName are null.</exception>
        public static long GetInt64Field(DataRow? dataRow, string? fieldName)
        {
            ArgumentNullException.ThrowIfNull(dataRow);
            ArgumentNullException.ThrowIfNull(fieldName);

            try
            {
                if (dataRow[fieldName] == null) return 0;
                if (dataRow[fieldName] is DBNull) return 0;
                return Convert.ToInt64(dataRow[fieldName], CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetInt64Field(DataRow, string)", ex);
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static long GetLongField(DataRow? dr, string? field)
        {
            return GetLongField(dr, field, 0);
        }

        public static long GetLongField(DbDataReader? dr, string? field)
            => GetLongField(dr, field, 0);

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static long GetLongField(OleDbDataReader dr, string field)
            => GetLongField((DbDataReader)dr, field);

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static long GetLongField(DataRow? dr, string? field, long defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            long result = defaultValue;
            try
            {
                if (!(dr[field] is DBNull))
                {
                    result = Convert.ToInt64(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetLongField(DataRow, string, long)", ex);
                throw;
            }
            return result;
        }

        public static long GetLongField(DbDataReader? dr, string? field, long defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            long result = defaultValue;
            try
            {
                if (!(dr[field] is DBNull))
                {
                    result = Convert.ToInt64(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetLongField(DbDataReader, string, long)", ex);
                throw;
            }
            return result;
        }

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static long GetLongField(OleDbDataReader dr, string field, long defaultValue)
            => GetLongField((DbDataReader)dr, field, defaultValue);

        #endregion


        #region [ int / Int32 ]

        /// <summary>
        /// Safely retrieves int data from a field in  a DataRow
        /// </summary>
        /// <param name="dataRow">The DataRow object</param>
        /// <param name="fieldName">The name of the field</param>
        /// <returns>The int value of the field.  0 if the field is null, DBNull, or an error is thrown.</returns>
        /// <exception cref="ArgumentNullException">Thrown if dataRow or fieldName are null.</exception>
        public static int GetInt32Field(DataRow? dataRow, string? fieldName)
        {
            ArgumentNullException.ThrowIfNull(dataRow);
            ArgumentNullException.ThrowIfNull(fieldName);

            try
            {
                if (dataRow[fieldName] == null) return 0;
                if (dataRow[fieldName] is DBNull) return 0;
                return Convert.ToInt32(dataRow[fieldName], CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetInt32Field(DataRow, string)", ex);
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static int GetIntField(DataRow? dr, string? field)
        {
            return GetIntField(dr, field, 0);
        }

        public static int GetIntField(DbDataReader? dr, string? field)
            => GetIntField(dr, field, 0);

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static int GetIntField(OleDbDataReader dr, string field)
            => GetIntField((DbDataReader)dr, field);

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetIntField(DataRow? dr, string? field, int defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            int result = defaultValue;
            try
            {
                if (!(dr[field] is DBNull))
                {
                    result = Convert.ToInt32(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetIntField(DataRow, string, int)", ex);
                throw;
            }
            return result;
        }

        public static int GetIntField(DbDataReader? dr, string? field, int defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            int result = defaultValue;
            try
            {
                if (!(dr[field] is DBNull))
                {
                    result = Convert.ToInt32(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetIntField(DbDataReader, string, int)", ex);
                throw;
            }
            return result;
        }

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static int GetIntField(OleDbDataReader dr, string field, int defaultValue)
            => GetIntField((DbDataReader)dr, field, defaultValue);

        public static Nullable<int> GetNullableIntField(DataRow? dr, string? field)
        {
            return GetNullableIntField(dr, field, null);
        }

        public static Nullable<int> GetNullableIntField(DbDataReader? dr, string? field)
            => GetNullableIntField(dr, field, null);

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static Nullable<int> GetNullableIntField(OleDbDataReader dr, string field)
            => GetNullableIntField((DbDataReader)dr, field);

        public static Nullable<int> GetNullableIntField(DataRow? dr, string? field, Nullable<int> defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            Nullable<int> result = defaultValue;
            try
            {
                if ((!(dr[field] is DBNull)) && !String.IsNullOrEmpty(dr[field].ToString()?.Trim()))
                {
                    result = Convert.ToInt32(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetNullableIntField(DataRow, string, Nullable<int>)", ex);
                throw;
            }
            return result;
        }

        public static Nullable<int> GetNullableIntField(DbDataReader? dr, string? field, Nullable<int> defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            Nullable<int> result = defaultValue;
            try
            {
                if ((!(dr[field] is DBNull)) && !String.IsNullOrEmpty(dr[field].ToString()?.Trim()))
                {
                    result = Convert.ToInt32(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetNullableIntField(DbDataReader, string, Nullable<int>)", ex);
                throw;
            }
            return result;
        }

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static Nullable<int> GetNullableIntField(OleDbDataReader dr, string field, Nullable<int> defaultValue)
            => GetNullableIntField((DbDataReader)dr, field, defaultValue);

        #endregion


        #region [ short / Int16 ]

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static short GetShortField(DataRow? dr, string? field)
        {
            return GetShortField(dr, field, 0);
        }

        public static short GetShortField(DbDataReader? dr, string? field)
            => GetShortField(dr, field, 0);

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static short GetShortField(OleDbDataReader dr, string field)
            => GetShortField((DbDataReader)dr, field);

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static short GetShortField(DataRow? dr, string? field, short defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            short result = defaultValue;
            try
            {
                if (!(dr[field] is DBNull))
                {
                    result = Convert.ToInt16(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetShortField(DataRow, string, short)", ex);
                throw;
            }
            return result;
        }

        public static short GetShortField(DbDataReader? dr, string? field, short defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            short result = defaultValue;
            try
            {
                if (!(dr[field] is DBNull))
                {
                    result = Convert.ToInt16(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetShortField(DbDataReader, string, short)", ex);
                throw;
            }
            return result;
        }

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static short GetShortField(OleDbDataReader dr, string field, short defaultValue)
            => GetShortField((DbDataReader)dr, field, defaultValue);

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static Nullable<short> GetNullableShortField(DataRow? dr, string? field)
        {
            return GetNullableShortField(dr, field, null);
        }

        public static Nullable<short> GetNullableShortField(DbDataReader? dr, string? field)
            => GetNullableShortField(dr, field, null);

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static Nullable<short> GetNullableShortField(OleDbDataReader dr, string field)
            => GetNullableShortField((DbDataReader)dr, field);

        /// <summary>
        ///
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="field"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Nullable<short> GetNullableShortField(DataRow? dr, string? field, Nullable<short> defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            Nullable<short> result = defaultValue;
            try
            {
                if ((!(dr[field] is DBNull)) && !String.IsNullOrEmpty(dr[field].ToString()?.Trim()))
                {
                    result = Convert.ToInt16(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetNullableShortField(DataRow, string, Nullable<short>)", ex);
                throw;
            }
            return result;
        }

        public static Nullable<short> GetNullableShortField(DbDataReader? dr, string? field, Nullable<short> defaultValue)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            Nullable<short> result = defaultValue;
            try
            {
                if ((!(dr[field] is DBNull)) && !String.IsNullOrEmpty(dr[field].ToString()?.Trim()))
                {
                    result = Convert.ToInt16(dr[field], CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetNullableShortField(DbDataReader, string, Nullable<short>)", ex);
                throw;
            }
            return result;
        }

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static Nullable<short> GetNullableShortField(OleDbDataReader dr, string field, Nullable<short> defaultValue)
            => GetNullableShortField((DbDataReader)dr, field, defaultValue);

        #endregion


        #region [ Guid ]

        public static Guid GetGuidField(DbDataReader? dr, string? field)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            Guid result = Guid.Empty;
            try
            {
                if (!(dr[field] is DBNull))
                {
                    result = (Guid)(dr[field]);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetGuidField(DbDataReader, string)", ex);
                throw;
            }
            return result;
        }

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static Guid GetGuidField(OleDbDataReader dr, string field)
            => GetGuidField((DbDataReader)dr, field);

        #endregion


        #region [ Binary ]

        public static byte[]? GetBinaryField(DbDataReader? dr, string? field)
        {
            ArgumentNullException.ThrowIfNull(dr);
            ArgumentNullException.ThrowIfNull(field);

            byte[]? result = null;
            try
            {
                if (!(dr[field] is DBNull))
                {
                    result = (byte[])(dr[field]);
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DataUtil.GetBinaryField(DbDataReader, string)", ex);
                throw;
            }
            return result;
        }

        [Obsolete("Use the DbDataReader overload instead for provider-agnostic code.")]
        public static byte[]? GetBinaryField(OleDbDataReader dr, string field)
            => GetBinaryField((DbDataReader)dr, field);

        #endregion
    }
}
