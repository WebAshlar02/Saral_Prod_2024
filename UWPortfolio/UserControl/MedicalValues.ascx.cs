using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_MedicalValues : System.Web.UI.UserControl
{
    string AppNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           if(!Page.IsPostBack)
           {

           }
        }
        catch (Exception ex)
        {
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        try
        {
            string AppForMedical = Context.Items["DataToBePassed"].ToString();
            if (AppForMedical != "")
            {
                //  AppNo = Convert.ToString(Session["application"]);
                ClearFields(string.Empty);

                BindMedicalValue(AppForMedical);
            }
        }
        catch (Exception ex)
        { 

        }
    }

    protected void Page_RenderControl(object sender, EventArgs e)
    {

    }

    public void ClearFields(string emp)
    {
        txtAppNo.Text = emp;
        txtSystolic1.Text = emp;
        ddlGender.SelectedItem.Text = emp;
        txtSystolic2.Text = emp;
        txtDOB.Text = emp;
        txtSystolic3.Text = emp;
        txtAge.Text = emp;
        txtDiastolic1.Text = emp;
        txtHeight.Text = emp;
        txtDiastolic2.Text = emp;
        txtWeight.Text = emp;
        txtDiastolic3.Text = emp;
        txtBMI.Text = emp;
        txtGirth.Text = emp;
        txtPulse.Text = emp;
        txtSmokerComment.Text = emp;
        txtDMComment.Text = emp;
        txtHTNComment.Text = emp;
        txtHB.Text = emp;
        txtPCV.Text = emp;
        txtRBC1.Text = emp;
        txtMCV.Text = emp;
        txtMCH.Text = emp;
        txtMCHC.Text = emp;
        txtWBC.Text = emp;
        txtNEUTROPHILS.Text = emp;
        txtLYMPHOCYTES.Text = emp;
        txtEOSINOPHILS.Text = emp;
        txtMONOCYTES.Text = emp;
        txtBASOPHILS.Text = emp;
        txtPLATELETCOUNT.Text = emp;
        txtESR.Text = emp;

        txtDuration.Text = emp;
        txtFBS.Text = emp;
        txtHBA1C.Text = emp;
        txtRBC.Text = emp;
        ddl_ALBUMIN.SelectedItem.Text = emp;
        ddlSUGAR.SelectedItem.Text = emp;
        txtPUS.Text = emp;
        ddlOthers.SelectedItem.Text = emp;

        txtSGOT.Text = emp;
        txtSGPT.Text = emp;
        txtGGT.Text = emp;
        txtDirectBILLIRUBIN.Text = emp;
        txtBILLIRUBIN2.Text = emp;
        txtTotalBILLIRUBIN.Text = emp;
        txtALP.Text = emp;
        txtGLOBILIN.Text = emp;
        txtS_ALBUMIN.Text = emp;
        txtTOTALPROTEIN.Text = emp;
        txtAgRatio.Text = emp;

        txtCHOLESTEROL.Text = emp;
        txtHDL.Text = emp;
        txtTRIGLYCERIDE.Text = emp;
        txtTCHDLRatio.Text = emp;

        txtS_CREATININE.Text = emp;
        txtUricAcid.Text = emp;
        txtBUN.Text = emp;

        txtDateOfTest.Text = emp;
        txtECGDecision.Text = emp;

        dtTestMedication.Text = emp;
        txtMedication.Text = emp;
        txtExerciseTime.Text = emp;
        txtWorkLoad.Text = emp;
        txtBP.Text = emp;
        txtTHR.Text = emp;
        txtResonTermination.Text = emp;
        txtCTMTDecision.Text = emp;
        txtCMODecisionCTMT.Text = emp;

    }


    public void BindMedicalValue(string AppNo)
    {
        try
        {
            Commfun objComFun = new Commfun();
            DataSet ds = new DataSet();
            //AppNo = "D00040005";
            objComFun.FetchMedicalValuesFor_UWComment(ref ds, AppNo);

            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                string xmlData = ds.Tables[0].Rows[0][7].ToString();
                StringReader theReader = new StringReader(xmlData);
                DataSet ds1 = new DataSet();
                ds1.ReadXml(theReader);

                if (ds1.Tables.Count > 0)
                {
                    if (ds1.Tables[0].Rows.Count > 0)   //table 0=>_strclsHeader
                    {
                        txtAppNo.Text = ds1.Tables[0].Rows[0]["AppNo"].ToString();

                    }

                    if (ds1.Tables[1].Rows.Count > 0)//MRFDetails  //table 1=>_strMrfData
                    {
                        txtSystolic1.Text = ds1.Tables[1].Rows[0]["Systolic1"].ToString();
                        ddlGender.SelectedItem.Text = ds1.Tables[1].Rows[0]["Gender"].ToString();
                        txtSystolic2.Text = ds1.Tables[1].Rows[0]["Systolic2"].ToString();
                        txtDOB.Text = ds1.Tables[1].Rows[0]["DOB"].ToString();
                        txtSystolic3.Text = ds1.Tables[1].Rows[0]["Systolic3"].ToString();
                        txtAge.Text = ds1.Tables[1].Rows[0]["AGE"].ToString();
                        txtDiastolic1.Text = ds1.Tables[1].Rows[0]["Diastolic1"].ToString();
                        txtHeight.Text = ds1.Tables[1].Rows[0]["Height"].ToString();
                        txtDiastolic2.Text = ds1.Tables[1].Rows[0]["Diastolic2"].ToString();
                        txtWeight.Text = ds1.Tables[1].Rows[0]["Weight"].ToString();
                        txtDiastolic3.Text = ds1.Tables[1].Rows[0]["Diastolic3"].ToString();
                        txtBMI.Text = ds1.Tables[1].Rows[0]["BMI"].ToString();
                        txtGirth.Text = ds1.Tables[1].Rows[0]["Girth"].ToString();
                        txtPulse.Text = ds1.Tables[1].Rows[0]["Pulse"].ToString();
                        if (ds1.Tables[1].Rows[0]["CaseHTN"].ToString() == "1")
                        { ChekHTN.Checked = true; }
                        else ChekHTN.Checked = false;

                        txtChestInsp.Text = ds1.Tables[1].Rows[0]["ChestInspiration"].ToString();

                        if (ds1.Tables[1].Rows[0]["caseDM"].ToString() == "1")
                        { ChekDMCase.Checked = true; }
                        else ChekDMCase.Checked = false;

                        if (ds1.Tables[1].Rows[0]["Smoker"].ToString() == "1")
                        { chekSmoker.Checked = true; }
                        else chekSmoker.Checked = false;

                        if (ds1.Tables[1].Rows[0]["Alcohol"].ToString() == "1")
                        { ChekAlcohol.Checked = true; }
                        else ChekAlcohol.Checked = false;

                        txtSmokerComment.Text = ds1.Tables[1].Rows[0]["SmokerCommnets"].ToString();
                        txtDMComment.Text = ds1.Tables[1].Rows[0]["CaseDMComments"].ToString();
                        txtHTNComment.Text = ds1.Tables[1].Rows[0]["CaseHTNComments"].ToString();
                    }
                    if (ds1.Tables[2].Rows.Count > 0)//CBC_ESR Details  //table 2=>_strCbcEsr
                    {
                        txtHB.Text = ds1.Tables[2].Rows[0]["HB"].ToString();
                        txtPCV.Text = ds1.Tables[2].Rows[0]["PCV"].ToString();
                        txtRBC1.Text = ds1.Tables[2].Rows[0]["RBC"].ToString();
                        txtMCV.Text = ds1.Tables[2].Rows[0]["MCV"].ToString();
                        txtMCH.Text = ds1.Tables[2].Rows[0]["MCH"].ToString();
                        txtMCHC.Text = ds1.Tables[2].Rows[0]["MCHC"].ToString();
                        txtWBC.Text = ds1.Tables[2].Rows[0]["WBC"].ToString();
                        txtNEUTROPHILS.Text = ds1.Tables[2].Rows[0]["NEUTROPHILS"].ToString();
                        txtLYMPHOCYTES.Text = ds1.Tables[2].Rows[0]["LYMPHOCYTES"].ToString();
                        txtEOSINOPHILS.Text = ds1.Tables[2].Rows[0]["EOSINOPHILS"].ToString();
                        txtMONOCYTES.Text = ds1.Tables[2].Rows[0]["MONOCYTES"].ToString();
                        txtBASOPHILS.Text = ds1.Tables[2].Rows[0]["BASOPHILS"].ToString();
                        txtPLATELETCOUNT.Text = ds1.Tables[2].Rows[0]["PLATELETCOUNT"].ToString();
                        txtESR.Text = ds1.Tables[2].Rows[0]["ESR"].ToString();
                    }
                    if (ds1.Tables[3].Rows.Count > 0)//HBSAG  //table 3=>_strHBSAG
                    {
                        if (ds1.Tables[3].Rows[0]["NA"].ToString() == "1")
                        { chkHBSAG_NA.Checked = true; }
                        else
                            chkHBSAG_NA.Checked = false;

                        if (ds1.Tables[3].Rows[0]["Positive"].ToString() == "1")
                        { chkHBSAG_POSITITVE.Checked = true; }
                        else
                            chkHBSAG_POSITITVE.Checked = false;

                        if (ds1.Tables[3].Rows[0]["Negative"].ToString() == "1")
                        { chkHBSAG_NEGATIVE.Checked = true; }
                        else
                            chkHBSAG_NEGATIVE.Checked = false;
                    }
                    if (ds1.Tables[4].Rows.Count > 0)//HIV //table 4=>_strHIV
                    {
                        if (ds1.Tables[4].Rows[0]["NA"].ToString() == "1")
                        { chkhiv_NA.Checked = true; }
                        else chkhiv_NA.Checked = false;

                        if (ds1.Tables[4].Rows[0]["Positive"].ToString() == "1")
                        { chkhiv_POSITIVE.Checked = true; }
                        else
                            chkhiv_POSITIVE.Checked = false;

                        if (ds1.Tables[4].Rows[0]["Negative"].ToString() == "1")
                        { chkhiv_NEGATIVE.Checked = true; }
                        else
                            chkhiv_NEGATIVE.Checked = false;
                    }
                    if (ds1.Tables[5].Rows.Count > 0)//FBS_RUA  //table 5=>_strFBS
                    {
                        txtDuration.Text = ds1.Tables[5].Rows[0]["Duration"].ToString();
                        txtFBS.Text = ds1.Tables[5].Rows[0]["FBS"].ToString();
                        txtHBA1C.Text = ds1.Tables[5].Rows[0]["HBA1C"].ToString();
                        txtRBC.Text = ds1.Tables[5].Rows[0]["RBC"].ToString();
                        ddl_ALBUMIN.SelectedItem.Text = ds1.Tables[5].Rows[0]["Albumin"].ToString();
                        ddlSUGAR.SelectedItem.Text = ds1.Tables[5].Rows[0]["Sugar"].ToString();
                        txtPUS.Text = ds1.Tables[5].Rows[0]["PucCells"].ToString();
                        ddlOthers.SelectedItem.Text = ds1.Tables[5].Rows[0]["Others"].ToString();
                    }
                    if (ds1.Tables[6].Rows.Count > 0) //LFT_Test //table 6=>_strLftTest
                    {
                        txtSGOT.Text = ds1.Tables[6].Rows[0]["SGOT"].ToString();
                        txtSGPT.Text = ds1.Tables[6].Rows[0]["SGPT"].ToString();
                        txtGGT.Text = ds1.Tables[6].Rows[0]["GGT"].ToString();
                        txtDirectBILLIRUBIN.Text = ds1.Tables[6].Rows[0]["Billirubin1"].ToString();
                        txtBILLIRUBIN2.Text = ds1.Tables[6].Rows[0]["Billirubin2"].ToString();
                        txtTotalBILLIRUBIN.Text = ds1.Tables[6].Rows[0]["TotalBillirubin"].ToString();
                        txtALP.Text = ds1.Tables[6].Rows[0]["ALP"].ToString();
                        txtGLOBILIN.Text = ds1.Tables[6].Rows[0]["S_Globilin"].ToString();
                        txtS_ALBUMIN.Text = ds1.Tables[6].Rows[0]["S_Albumin"].ToString();
                        txtTOTALPROTEIN.Text = ds1.Tables[6].Rows[0]["TotalProtein"].ToString();
                        txtAgRatio.Text = ds1.Tables[6].Rows[0]["AGRatio"].ToString();
                    }
                    if (ds1.Tables[7].Rows.Count > 0) //LIPIDS  //table 7=>_strLipidsTest
                    {
                        txtCHOLESTEROL.Text = ds1.Tables[7].Rows[0]["Cholestrol"].ToString();
                        txtHDL.Text = ds1.Tables[7].Rows[0]["HDL"].ToString();
                        txtTRIGLYCERIDE.Text = ds1.Tables[7].Rows[0]["Triglyceride"].ToString();
                        txtTCHDLRatio.Text = ds1.Tables[7].Rows[0]["HdlRatio"].ToString();
                    }
                    if (ds1.Tables[8].Rows.Count > 0)//RFT  //table 8=>_strRftTest
                    {
                        txtS_CREATININE.Text = ds1.Tables[8].Rows[0]["S_Creatine"].ToString();
                        txtUricAcid.Text = ds1.Tables[8].Rows[0]["UricAcid"].ToString();
                        txtBUN.Text = ds1.Tables[8].Rows[0]["Bun"].ToString();
                    }
                    if (ds1.Tables[9].Rows.Count > 0) //ECG //table 9=>_strECGTest
                    {
                        txtDateOfTest.Text = ds1.Tables[9].Rows[0]["DateOfECGTest"].ToString();
                        txtECGDecision.Text = ds1.Tables[9].Rows[0]["ECGDecision"].ToString();
                    }
                    if (ds1.Tables[10].Rows.Count > 0)//CTMT  //table 10=>_strCtmtTest
                    {
                        dtTestMedication.Text = ds1.Tables[10].Rows[0]["DateOfCtmtTest"].ToString();
                        txtMedication.Text = ds1.Tables[10].Rows[0]["Medication"].ToString();
                        txtExerciseTime.Text = ds1.Tables[10].Rows[0]["ExerciseTime"].ToString();
                        txtWorkLoad.Text = ds1.Tables[10].Rows[0]["WorkLoad"].ToString();
                        txtBP.Text = ds1.Tables[10].Rows[0]["BP"].ToString();
                        txtTHR.Text = ds1.Tables[10].Rows[0]["THR"].ToString();
                        txtResonTermination.Text = ds1.Tables[10].Rows[0]["TerminationReason"].ToString();
                        txtCTMTDecision.Text = ds1.Tables[10].Rows[0]["Decision"].ToString();
                        txtCMODecisionCTMT.Text = ds1.Tables[10].Rows[0]["CmoDecisionCTMT"].ToString();
                    }
                    //if (ds.Tables[11].Rows.Count > 0)//CTMT  //table 10=>_strCtmtTest
                    //{
                    //    //txtOtherComments.Text = ds.Tables[11].Rows[0][0].ToString();
                    //    //ddlMedicalreason.SelectedItem.Text = ds.Tables[11].Rows[0][0].ToString();
                    //    //ddlExreason.SelectedItem.Text = ds.Tables[11].Rows[0][0].ToString();
                    //    //txttotalEMR.Text = ds.Tables[11].Rows[0][0].ToString();
                    //    //txtmanualEMR.Text = ds.Tables[11].Rows[0][0].ToString();
                    //    //txtCMODecision.Text = ds.Tables[11].Rows[0][0].ToString(); 
                    //}




                    //Decision
                }
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }




}