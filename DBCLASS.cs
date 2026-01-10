using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

public class DBCLASS
{
    string id = "hong1";
    string pw = "1111";

    private int selectedRowIndex;
    private int selectedKeyValue;

    private OracleConnection DBConn;
    private OracleDataAdapter dBAdapter;
    private OracleCommandBuilder myCommandBuilder;
    private DataSet dS;
    private DataTable MyTable;

    public string getId() { return id; }
    public string getPw() { return pw; }
    public int SelectedRowIndex { get { return selectedRowIndex; } set { selectedRowIndex = value; } }
    public int SelectedKeyValue { get { return selectedKeyValue; } set { selectedKeyValue = value; } }
    public OracleDataAdapter DBAdapter { get { return dBAdapter; } set { dBAdapter = value; } }
    public DataSet DS { get { return dS; } set { dS = value; } }
    public OracleCommandBuilder MyCommandBuilder { get { return myCommandBuilder; } set { myCommandBuilder = value; } }
    public DataTable PhoneTable { get { return MyTable; } set { MyTable = value; } }

    // ✅ 객체 생성
    public void DB_ObjCreate()
    {
        string connectionString =
            $"User Id={id}; Password={pw}; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL =TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)));";

        DBConn = new OracleConnection(connectionString);
        dBAdapter = new OracleDataAdapter();
        if (DS == null)
            DS = new DataSet(); // 기존 DataSet 유지
        MyTable = new DataTable();
    }

    // ✅ SQL 설정 + 연결 오픈
    public void DB_Open(string cmd)
    {
        try
        {
           // DBConn.Open();
            dBAdapter.SelectCommand = new OracleCommand(cmd, DBConn);
            myCommandBuilder = new OracleCommandBuilder(dBAdapter);
        }
        catch (DataException DE)
        {
            MessageBox.Show(DE.Message);
        }
    }

    // ✅ DB 닫기
    public void DB_Close()
    {
        try
        {
            if (DBConn != null && DBConn.State == ConnectionState.Open)
                DBConn.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("DB 닫기 오류: " + ex.Message);
        }
    }
}
