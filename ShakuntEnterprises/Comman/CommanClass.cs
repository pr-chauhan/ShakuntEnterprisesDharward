namespace ShakuntEnterprises.Comman
{
    using ShakuntEnterprises.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Data;
    using System.Data.SqlClient;
    using System.Reflection;
    using System.Data.SqlTypes;
    using System.Security.Cryptography.Xml;
    using MessagePack;
    using System.Data.SqlClient;
    using Microsoft.Net.Http.Headers;

    public class CommanClass
    {
        private readonly  ShakuntEnterprisesContext _context;
        private DataTable dataTable;
        private SqlConnection sqlConnection;
        private SqlConnection sqlConnectionerp;
        private SqlDataAdapter sqlDataAdapter;
        private readonly IConfiguration configuration;

        public CommanClass(ShakuntEnterprisesContext context, IConfiguration _configuration)
        {
            _context = context;
            this.configuration = _configuration;
            sqlConnectionerp = new SqlConnection(SQLConnection());
            if (sqlConnectionerp.State == ConnectionState.Closed)
            {
                sqlConnectionerp.Open();
            }

           
        }
        public string SQLConnection()
        {
            var conString = configuration.GetSection("ConnectionStrings").GetChildren().ToList();
            return conString[0].Value;
        }
        public List<ModuleList> getModlueList(string? userId)
        {
            //List<MainModuleBar> result = _context.mainModuleBars.Where(x => x.UserId.Equals(userId)).OrderBy(x=> x.ModuleId).ToList();
            List<ModuleList> result = new List<ModuleList>();
            var data = _context.MainModuleBars.Where(x => x.UserId.Equals(userId) && x.IsActive.Equals("Y")).ToList();
            var query = (from a in data
                        join b in _context.ModuleLists
                        on a.ModuleId equals b.ModuleId
                        select b).OrderBy(b=> b.ModuleId).ToList();
            foreach(var item in query)
            {
                result.Add(item);
            }

            return result;

        }
        public List<ModuleList> getAllModlueList()
        {
            List<ModuleList> result = _context.ModuleLists.Where(x => x.IsActive == "Y").ToList();

            return result;

        }
        public List<MainNavigationBar> getModlueMenuList(string? userId)
        {
            List<MainNavigationBar> result = _context.MainNavigationBars.
                Where(x => x.UserId.Equals(userId) && x.SubMenuId == null && x.IsActive == "Y").OrderBy(x=>  x.ModuleId).ToList();

            return result;

        }
      
        public List<MainNavigationBar> getAllModlueMenuList()
        {
            List<MainNavigationBar> result = _context.MainNavigationBars.Where(x => x.IsActive == "Y").ToList();

            return result;

        }
        public List<MainNavigationBar> getModlueSubMenuList(string? userId,string? department)
        {
            List<MainNavigationBar> result = _context.MainNavigationBars.Where(x => x.UserId.Equals(userId) && x.SubMenuId != null && x.IsActive =="Y" && x.SubMenuName.Contains(department)).OrderBy(x => x.SubMenuName).ToList();

            return result;

        }
        public List<MainNavigationBar> getAllModlueSubMenuList()
        {
            List<MainNavigationBar> result = _context.MainNavigationBars.Where(x => x.IsActive == "Y").ToList();

            return result;

        }
        public List<UserMaster> getAllUserList()
        {
            List<UserMaster> result = _context.UserMasters.ToList();

            return result;
        }

        public List<MainNavigationBar> getAllControllerList()
        {
            List<MainNavigationBar> result = _context.MainNavigationBars.Where(x=> x.UserId == "admin" && x.IsActive =="Y").ToList();

            return result;
        }
        public List<MainNavigationBar> getAllActionList()
        {
            List<MainNavigationBar> result = _context.MainNavigationBars.Where(x => x.UserId == "admin" && x.IsActive == "Y").ToList();

            return result;
        }
        public DataTable getTestCertificateRecordList(string Id)
        {
            var result = GetDataTable("SELECT *  FROM  [TestCertificateRecord] Where CertificateNo='" + Id+"'");//)_context.MainNavigationBars.Where(x => x.UserId == "admin" && x.IsActive == "Y").ToList();

            return result;
        }
        public DataTable getTestCertificateResultRecordList(string Id)
        {
            var result = GetDataTable("SELECT *  FROM  [TestCertificateResultRecord] Where CertificateNo='" + Id + "'");//)_context.MainNavigationBars.Where(x => x.UserId == "admin" && x.IsActive == "Y").ToList();

            return result;
        }
        public DataTable getTradeDesignationMasterRecord(string Id)
        {
            var result = GetDataTable("SELECT *  FROM  [TradeDesignationMaster] Where TradeDesignation='" + Id + "'");//)_context.MainNavigationBars.Where(x => x.UserId == "admin" && x.IsActive == "Y").ToList();

            return result;
        }
        public string TotalCertificate()
        {
            var result = GetDataTable("SELECT count(Id) TotalCertificate  FROM  [TestCertificateRecord]");

            return result.Rows[0][0].ToString();
        }
        public string TotalPassCertificate()
        {
            var result = GetDataTable("SELECT count(Id) TotalCertificate  FROM  [TestCertificateRecord] Where IsApproved=1");

            return result.Rows[0][0].ToString();
        }
        public string TotalFailedCertificate()
        {
            var result = GetDataTable("SELECT count(Id) TotalCertificate  FROM  [TestCertificateRecord] Where IsApproved!=1");

            return result.Rows[0][0].ToString();
        }
        public string TotalManualCertificate()
        {
            var result = GetDataTable("SELECT count(Id) TotalCertificate  FROM  [TestCertificateRecord] Where Certificate_Type='Manual'");

            return result.Rows[0][0].ToString();
        }
        public string TotalSystemCertificate()
        {
            var result = GetDataTable("SELECT count(Id) TotalCertificate  FROM  [TestCertificateRecord] Where Certificate_Type='System'");

            return result.Rows[0][0].ToString();
        }

        public List<SizeMaster> getAllSizeList()
        {
            List<SizeMaster> result = _context.SizeMasters.ToList();

            return result;
        }
        public List<TradeDesignationMaster> getAllTradeDesignationMasterList()
        {
            List<TradeDesignationMaster> result = _context.TradeDesignationMasters.ToList();

            return result;
        }
        public  DataTable GetDataTable(string sqlstring)
        {
            dataTable = new DataTable();
            sqlDataAdapter = new SqlDataAdapter(sqlstring, sqlConnectionerp);
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }
        public DataTable GetDataTableLogic(string sqlstring)
        {
            dataTable = new DataTable();
            sqlDataAdapter = new SqlDataAdapter(sqlstring, sqlConnection);
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
         
        public int GenerateNumberSeries(string? SeriesId)
        {
            var data = _context.NumberSeries.FirstOrDefault(x => x.SeriesId == SeriesId);
            var result = (int)_context.NumberSeries.Where(x => x.SeriesId == SeriesId).Max(x => x.SeriesNumber) + 1;
            if (data != null)
            {
                data.SeriesNumber = result ;
                _context.Update(data);
                _context.SaveChanges();
            }

            return result;
             
        }

        public bool CheckLicenseDate(string appName)
        {
            bool lRetVal = false;


            string sysDate = string.Empty;
            string endDate = string.Empty;
            DataTable dataTable = new DataTable();
            try
            {
                string sqlLString = "EXEC sp_get_applicatioin_date "+ appName;
                SqlCommand llCommand = new SqlCommand();
                llCommand.CommandText = sqlLString;
                llCommand.Connection = sqlConnectionerp;
                SqlDataAdapter sqllAdapter = new SqlDataAdapter(llCommand);
                sqllAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    sysDate = dataTable.Rows[0]["SYSTEM_DATE"].ToString();
                    endDate = dataTable.Rows[0]["LICENSE_END_DATE"].ToString();
                }
                llCommand.Connection.Close();

                DateTime systemDate = Convert.ToDateTime(sysDate);
                DateTime dateTime = Convert.ToDateTime(endDate);
                int diffVal = (dateTime.Date - systemDate.Date).Days;
                if (diffVal < 0)
                {
                    lRetVal = true;
                }
            }
            catch(Exception ex)
            {
                lRetVal = true;
            }


            return lRetVal;
        }

    }

    public class Batch_Number
    {
        public int Batch_No { get; set; }


    }

    public class POUmber
    {
        public string? PO_Number { get; set; }
        

    }

    public class POHeader
    {
        public string? PONo { get; set; }
        public string? VendorNo { get; set; }
        public string? Vendor_Name { get; set; }
        public DateTime DocumentDate { get; set; }
        public string? Branch_Code { get; set; }

    }

    public class POLine
    {
        public string? ItemNo { get; set; }
        public string? ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityReceived { get; set; }
        public decimal QuantityToReceive { get; set; }
        public string? Branch_Code { get; set; }

    }

    public class ItemMasterERP
    {
        public string? ItemCode { get; set; }
        public string? ItemDescription { get; set; }
        public string? UOM { get; set; }
        

    }
    public class VendorLogicERP
    {
        public string? VendorCode { get; set; }
        public string? VendorName { get; set; }
        public string? Address { get; set; }
        public string? Address_2 { get; set; }
        


    }
    public class ItemMasterLOGICERP
    {
        public string? BarcCode { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemDescription { get; set; }
        public string? UOM { get; set; }
        public double? Price { get; set; }


    }

    public class ItemMasterStock
    {
        public string? ItemCode { get; set; }
        
        public decimal? Stock { get; set; }


    }
    public class VendorMasterERP
    {
        public string? VendorCode { get; set; }
        public string? VendorDescription { get; set; }
        public string? VendorState { get; set; }
        public string? Address { get; set; }



    }
}
