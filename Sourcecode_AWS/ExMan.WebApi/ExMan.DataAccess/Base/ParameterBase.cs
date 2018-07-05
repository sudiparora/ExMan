using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ExMan.DataAccess.Base
{
    public class ParameterBase : CommonBase
    {

        // CreateNullParameter
        protected static SqlParameter CreateNullParameter(string name, SqlDbType paramType)
        {
            SqlParameter parameter = new SqlParameter
            {
                SqlDbType = paramType,
                ParameterName = name,
                Value = null,
                Direction = ParameterDirection.Input
            };
            return parameter;
        }

        // CreateNullParameter - with size for nvarchars
        protected static SqlParameter CreateNullParameter(string name, SqlDbType paramType, int size)
        {
            SqlParameter parameter = new SqlParameter
            {
                SqlDbType = paramType,
                ParameterName = name,
                Size = size,
                Value = null,
                Direction = ParameterDirection.Input
            };
            return parameter;
        }

        // CreateOutputParameter
        protected static SqlParameter CreateOutputParameter(string name, SqlDbType paramType)
        {
            SqlParameter parameter = new SqlParameter
            {
                SqlDbType = paramType,
                ParameterName = name,
                Direction = ParameterDirection.Output
            };
            return parameter;
        }

        // CreateOuputParameter - with size for nvarchars
        protected static SqlParameter CreateOutputParameter(string name, SqlDbType paramType, int size)
        {
            SqlParameter parameter = new SqlParameter
            {
                SqlDbType = paramType,
                Size = size,
                ParameterName = name,
                Direction = ParameterDirection.Output
            };
            return parameter;
        }

        // CreateParameter - uniqueidentifier
        protected static SqlParameter CreateParameter(string name, Guid value)
        {
            if (value.Equals(Guid_NullValue))
            {
                // If value is null then create a null parameter
                return CreateNullParameter(name, SqlDbType.UniqueIdentifier);
            }
            else
            {
                SqlParameter parameter = new SqlParameter
                {
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    ParameterName = name,
                    Value = value,
                    Direction = ParameterDirection.Input
                };
                return parameter;
            }
        }

        // CreateParameter - int
        protected static SqlParameter CreateParameter(string name, int value)
        {
            if (value == Int_NullValue)
            {
                // If value is null then create a null parameter
                return CreateNullParameter(name, SqlDbType.Int);
            }
            else
            {
                SqlParameter parameter = new SqlParameter
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = name,
                    Value = value,
                    Direction = ParameterDirection.Input
                };
                return parameter;
            }
        }

        // CreateParameter - datetime
        protected static SqlParameter CreateParameter(string name, DateTime? value)
        {
            if (value == DateTime_NullValue)
            {
                // If value is null then create a null parameter
                return CreateNullParameter(name, SqlDbType.DateTime);
            }
            else
            {
                SqlParameter parameter = new SqlParameter
                {
                    SqlDbType = SqlDbType.DateTime,
                    ParameterName = name,
                    Value = value,
                    Direction = ParameterDirection.Input
                };
                return parameter;
            }
        }

        protected static SqlParameter CreateParameter(string name, TimeSpan value)
        {
            SqlParameter parameter = new SqlParameter
            {
                SqlDbType = SqlDbType.Time,
                ParameterName = name,
                Value = value,
                Direction = ParameterDirection.Input
            };
            return parameter;
        }

        protected static SqlParameter CreateParameter(string name, string value)
        {
            if (value == String_NullValue)
            {
                // If value is null then create a null parameter
                return CreateNullParameter(name, SqlDbType.VarChar);
            }
            else
            {
                SqlParameter parameter = new SqlParameter
                {
                    SqlDbType = SqlDbType.VarChar,
                    ParameterName = name,
                    Value = value,
                    Direction = ParameterDirection.Input
                };
                return parameter;
            }
        }

        protected static SqlParameter CreateParameter(string name, bool value)
        {
            SqlParameter parameter = new SqlParameter
            {
                SqlDbType = SqlDbType.Bit,
                ParameterName = name,
                Value = value,
                Direction = ParameterDirection.Input
            };
            return parameter;
        }

        // CreateParameter - nvarchar
        protected static SqlParameter CreateParameter(string name, string value, int size)
        {
            if (value == String_NullValue)
            {
                // If value is null then create a null parameter
                return CreateNullParameter(name, SqlDbType.NVarChar);
            }
            else
            {
                SqlParameter parameter = new SqlParameter
                {
                    SqlDbType = SqlDbType.NVarChar,
                    Size = size,
                    ParameterName = name,
                    Value = value,
                    Direction = ParameterDirection.Input
                };
                return parameter;
            }
        }

        protected static SqlParameter CreateParameter(string name, long value)
        {
            if (value == Long_NullValue)
            {
                return CreateNullParameter(name, SqlDbType.BigInt);
            }
            else
            {
                SqlParameter parameter = new SqlParameter
                {
                    SqlDbType = SqlDbType.BigInt,
                    ParameterName = name,
                    Value = value,
                    Direction = ParameterDirection.Input
                };
                return parameter;
            }
        }

        // CreateParameter - char
        protected static SqlParameter CreateParameter(string name, char value)
        {
            SqlParameter parameter = new SqlParameter
            {
                SqlDbType = SqlDbType.Char,
                ParameterName = name,
                Value = value,
                Direction = ParameterDirection.Input
            };
            return parameter;
        }


    }

}
