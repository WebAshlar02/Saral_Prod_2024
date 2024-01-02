using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using UWSaralDecision;
using UWSaralObjects;
using UWSaralServices;

namespace CIBILSCORESchedular
{
    class Program
    {
        static void Main()
        {
            GetData();
        }

        public static void GetData()
        {
            UWSaralDecision.CommFun objComm = new UWSaralDecision.CommFun();
            string ApplicationNumber = string.Empty;
            string PolicyNumber = string.Empty;
            string BranchCode = string.Empty;
            string LAClientCode = string.Empty;
            string strPartnerRequest = string.Empty;
            DataSet _ds = new DataSet();
            UWSaralDecision.DataLayer objData = new UWSaralDecision.DataLayer();
            int intRetVal = 0;
            string strPartnerResponse = string.Empty;
            //CIBILLocal.Service1Client svc = new CIBILLocal.Service1Client();
            UWSaralServices.CIBILSCORE.Service1Client objcibi = new UWSaralServices.CIBILSCORE.Service1Client();
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conbpm"].ConnectionString);
            //SqlCommand cmd = new SqlCommand("GetCIBILScoreSampleData", con);
            //SqlCommand cmd = new SqlCommand("USP_GETAPPLICATIONPASS_TO_CIBIL", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandTimeout = 0;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                try
                {
                    _ds = objData.RetrieveDataset_woParam("USP_GETAPPLICATIONPASS_TO_CIBIL");
                    if(_ds.Tables[0].Rows.Count>0)
                    {
                        dt = _ds.Tables[0];
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ApplicationNumber = Convert.ToString(dt.Rows[i]["ApplicationNumber"]);
                        PolicyNumber = Convert.ToString(dt.Rows[i]["PolicyNumber"]);
                        BranchCode = Convert.ToString(dt.Rows[i]["BranchCode"]);
                        LAClientCode = Convert.ToString(dt.Rows[i]["LAClientCode"]);
                        //svc.CIBILScoreServiceDownloadReport(ApplicationNumber, LAClientCode, "batchjob", "batchjob");
                        objcibi.CIBILScoreServiceDownloadReport(ApplicationNumber, LAClientCode, "batchjob", "batchjob");
                        strPartnerResponse = UWSaralServices.CommFun.GetXMLFromObject(objcibi.Endpoint);
                    }
                }


            }
            catch (Exception ex)
            {
                //throw ex;

                strPartnerRequest = ApplicationNumber + " " + PolicyNumber + " " + PolicyNumber + " " + BranchCode + " " + LAClientCode;
                SqlParameter[] _sqlparam = new SqlParameter[10];
                _sqlparam[0] = new SqlParameter("@FEMethodName", "CIBILSCORE");
                _sqlparam[1] = new SqlParameter("@LAMethodName", string.Empty);
                _sqlparam[2] = new SqlParameter("@partnerRequest", strPartnerRequest);
                _sqlparam[3] = new SqlParameter("@partnerResponse", strPartnerResponse);
                _sqlparam[4] = new SqlParameter("@LARequest", string.Empty);
                _sqlparam[5] = new SqlParameter("@LAResponse", string.Empty);
                _sqlparam[6] = new SqlParameter("@partnerID", "CIBILSchedular");
                _sqlparam[7] = new SqlParameter("@processID", "CIBILSchedular");
                _sqlparam[8] = new SqlParameter("@error", ex);
                _sqlparam[9] = new SqlParameter("@applicationNo", ApplicationNumber);
                //objData.Insertrecord("SP_AS400_Logs", _sqlparam);
                intRetVal = objData.Insertrecord("SP_AS400_Logs", _sqlparam);
                
            }
        }
      
    }
}
