using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Moin.ApplicationBlocks.Data;
/// <summary>
/// Summary description for DBase
/// </summary>
public class DBase
{
    public static string ConnStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
    //Procedure Without Parrameters


    public static DataSet GetDataSet(string sStoreProcedureName)
    {
        return SqlHelper.ExecuteDataset(ConnStr, CommandType.StoredProcedure, sStoreProcedureName);

    }
    //Procedure With Parrameters
    public static DataSet GetDataSet(string sStoreProcedureName, object[] objParram)
    {
        return SqlHelper.ExecuteDataset(ConnStr, sStoreProcedureName, objParram);

    }
    //Procedure With only one parrameter of type int
    public static DataSet GetDataSet(string sStoreProcedureName, int iValue)
    {
        return SqlHelper.ExecuteDataset(ConnStr, sStoreProcedureName, iValue);

    }
    //Procedure With only one parrameter of type string
    public static DataSet GetDataSet(string sStoreProcedureName, string sString)
    {

        return SqlHelper.ExecuteDataset(ConnStr, sStoreProcedureName, sString);

    }
    //Procedure With only one parrameter of type GUID
    public static DataSet GetDataSet(string sStoreProcedureName, Guid sGuid)
    {

        return SqlHelper.ExecuteDataset(ConnStr, sStoreProcedureName, sGuid);

    }
    // Procedure with Only One Date Parameter
    public static DataSet GetDataSet(string sStoreProcedureName, DateTime sDate)
    {

        return SqlHelper.ExecuteDataset(ConnStr, sStoreProcedureName, sDate);

    }

    public static DataSet GetDataSetforSQLQuery(string sSql)
    {
        return SqlHelper.ExecuteDataset(ConnStr, CommandType.Text, sSql);

    }

    //Procedure With only one parrameter of type int for Delete
    public static int ExecuteNonQuery(string sStoreProcedureName, int iValue)
    {
        return SqlHelper.ExecuteNonQuery(ConnStr, sStoreProcedureName, iValue);

    }
    //Procedure With parrameters  for Insert,Update or Delete
    public static int ExecuteNonQuery(string sStoreProcedureName, object[] objParram)
    {
        return SqlHelper.ExecuteNonQuery(ConnStr, sStoreProcedureName, objParram);

    }

    //Procedure With parrameters  for Insert,Update or Delete

    // Proceure with sql string for Inset Update or Delete

    public static int ExecuteNonQuery(string sSql)
    {
        return SqlHelper.ExecuteNonQuery(ConnStr, CommandType.Text, sSql);
    }
    public static int ExecuteScalar(string sStoreProcedureName, object[] objParram)
    {
        return Convert.ToInt16(SqlHelper.ExecuteScalar(ConnStr, sStoreProcedureName, objParram));

    }
    public static String ExecuteScalar2(string sSqlString)
    {

        return Convert.ToString(SqlHelper.ExecuteScalar(ConnStr, CommandType.Text, sSqlString));
    }
    public static DateTime ExecuteScalarDateTime(string sSqlString)
    {
        return Convert.ToDateTime(SqlHelper.ExecuteScalar(ConnStr, CommandType.Text, sSqlString));
    }
    public static int ExecuteScalar(string sSqlString)
    {
        return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnStr, CommandType.Text, sSqlString));
    }

    public static string ExecuteScalar(string sStoreProcedureName, Guid sGuid)
    {
        return Convert.ToString(SqlHelper.ExecuteScalar(ConnStr, sStoreProcedureName, sGuid));
    }

}
