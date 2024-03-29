﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platform.Utilities.LoggerFramework;
using UWSaralObjects;
using UWSaralObjects;
namespace UWSaralServices
{
    public class PremiumCalculationDetails
    {

        int i;
        DataRow[] Liferow;
        DataRow[] NomineeRow;
        DataRow[] ProposerRow;
        DataRow[] dtCoverage;
        DataRow[] JointLifeEntity;
        DataRow[] Rider;
        DataRow[] ApplicationCount;
        bool isStaff = false;
        bool isNSAP = false;
        string strLAclientId = string.Empty;
        string strLifetype = string.Empty;
        string strNomineeclientId = string.Empty;
        string strPayerClientId = string.Empty;
        string strProposerClientId = string.Empty;
        string strIsProposer = string.Empty;
        string strApplicationNo = string.Empty;
        string strSumassured = string.Empty;
        string strPolicyTerm = string.Empty;
        string strAmountinsis = string.Empty;
        string strPaymentfrequency = string.Empty;
        string strBasepremiumamount = string.Empty;
        string strTotalPremium = string.Empty;
        string strAppNo = string.Empty;
        string strProdcode = string.Empty;
        string strTotalpremiumamount = string.Empty;
        string AgentType = string.Empty;
        double strInstalmentPremiumAmt = 0.0;
        double strMedicalLoadingPremium = 0.0;
        double strNonMedicalLoadingPremium = 0.0;
        double strSumAssured = 0.0;
        double srTotalInstalmentPremium = 0.0;
        double strTotalPremiumAmount = 0.0;
        double strServicetax = 0.0;
        string strPremiumpayingterm = string.Empty;
        string strMonthlyPayout = "0";
        string strdataValue = string.Empty;
        /*added by shri on 22 aug 17 to add log*/
        string strPartnerRequest = string.Empty;
        /*end here*/
        int NonMedicalLoadBS = 0;
        int NonMedicalLoadAD = 0;
        string strMedicalClassBS = string.Empty;
        string strMedicalClassAD = string.Empty;

        CommFun objcomm = new CommFun();
        AgentEnquiry objAgent = new AgentEnquiry();
        public void PremiumCalculationPushService(string strPQuoteNo, ref DataSet _dsContractValResult, ChangeValue objChangeObj, DataSet _dsContract, ref int strLAPushErrorcode, ref string strLAPushStatus)
        {
            try
            {
                Logger.Info(strPQuoteNo + "PAGE_NAME:UWSaralDecision/BussLayer //EVENT_NAME:OnlineApplicationLAServiceDetails_PUSH//I-INFO:Service Call Execution Start: PREMIUMCAL" + System.Environment.NewLine);
                #region Variable declaration Begins.
                string strUserid = string.Empty;
                string _strOwnerClientID = string.Empty;
                _dsContract.Tables[0].TableName = "CLNTDTLS";
                _dsContract.Tables[1].TableName = "PRODDTLS";
                _dsContract.Tables[2].TableName = "RIDERDTLS";
                if (_dsContract.Tables.Count > 2)
                {
                    _dsContract.Tables[3].TableName = "CHILDDTLS";
                }
                #endregion Variable declaration End.

                #region Object Declaration Begins.
                LAPremiumCalService.LifeAssuredEntity objLifeAssuredEntity = new LAPremiumCalService.LifeAssuredEntity();
                LAPremiumCalService.ProposerEntity objProposerEntity = new LAPremiumCalService.ProposerEntity();
                LAPremiumCalService.ProductEntity objProductEntity = new LAPremiumCalService.ProductEntity();
                LAPremiumCalService.PolicyEntity objPolicyEntity = new LAPremiumCalService.PolicyEntity();
                LAPremiumCalService.SystemEntity objSystemEntity = new LAPremiumCalService.SystemEntity();
                LAPremiumCalService.RiderEntity[] objRiderEntity = null;


                List<LAPremiumCalService.RiderEntity> LstRiderEntity = new List<LAPremiumCalService.RiderEntity>();
                LAPremiumCalService.ChildEntity objChildEntity = new LAPremiumCalService.ChildEntity();
                LAPremiumCalService.LifePremiumCalculatorClient objInvoke = new LAPremiumCalService.LifePremiumCalculatorClient();
                LAPremiumCalService.LifePremiumResult objResponce = new LAPremiumCalService.LifePremiumResult();
                LAPremiumCalService.ComponentResults[] objCompResult = null;
                #endregion Object Declaration end.
                //if (objChangeObj.Prod_policydetails != null)
                //{
                //    strPolicyTerm = objChangeObj.Prod_policydetails._PolicyTerm;
                //    strPremiumpayingTerm = objChangeObj.Prod_policydetails._Premiumpayingterm;
                //    strSumassured = objChangeObj.Prod_policydetails._Sumassured;
                //    strAmountinsis = objChangeObj.Prod_policydetails._Amountinsis;
                //    strPaymentfrequency = objChangeObj.Prod_policydetails._Paymentfrequency;
                //    strBasepremiumamount = objChangeObj.Prod_policydetails._Basepremiumamount;
                //    strTotalPremium = objChangeObj.Prod_policydetails._TotalPremiumamount;
                //}

                _dsContractValResult = new DataSet();
                _dsContractValResult.Locale = CultureInfo.InvariantCulture;
                DataTable dtPremiumDetails = _dsContractValResult.Tables.Add("SampleData");

                // added by amit ; add all the premium calculation result to datatable.
                dtPremiumDetails.Columns.Add("BackdatedInt", typeof(string));
                dtPremiumDetails.Columns.Add("ComponentCd", typeof(string));
                dtPremiumDetails.Columns.Add("EduCess", typeof(string));
                dtPremiumDetails.Columns.Add("ExtraPremiumAmt", typeof(string));
                dtPremiumDetails.Columns.Add("InstalmentPremiumAmt", typeof(string));
                dtPremiumDetails.Columns.Add("LifeType", typeof(string));
                dtPremiumDetails.Columns.Add("MedicalLoadingPremium", typeof(string));
                dtPremiumDetails.Columns.Add("MedicalLoadingRate", typeof(string));
                dtPremiumDetails.Columns.Add("ModalPremiumAmt", typeof(string));
                dtPremiumDetails.Columns.Add("NonMedicalLoadingPremium", typeof(string));
                dtPremiumDetails.Columns.Add("NonMedicalLoadingRate", typeof(string));
                dtPremiumDetails.Columns.Add("RiderCtg", typeof(string));
                dtPremiumDetails.Columns.Add("RiderPPT", typeof(string));
                dtPremiumDetails.Columns.Add("RiderPT", typeof(string));
                dtPremiumDetails.Columns.Add("SeriveTax", typeof(string));
                dtPremiumDetails.Columns.Add("SumAssured", typeof(string));
                dtPremiumDetails.Columns.Add("SumAssuredAcrossPlans", typeof(string));
                dtPremiumDetails.Columns.Add("TotalInstalmentPremium", typeof(string));
                dtPremiumDetails.Columns.Add("TotalPremiumAmount", typeof(string));
                dtPremiumDetails.Columns.Add("RiderInfo", typeof(string));
                dtPremiumDetails.Columns.Add("RiderType", typeof(string));
                dtPremiumDetails.Columns.Add("ProductCode", typeof(string));
                dtPremiumDetails.Columns.Add("ServiceTax", typeof(string));


                /*
                dtPremiumDetails.Columns.Add("ProductCode", typeof(string));
                dtPremiumDetails.Columns.Add("InstalmentPremiumAmt", typeof(string));
                dtPremiumDetails.Columns.Add("MedicalLoadingPremium", typeof(string));
                dtPremiumDetails.Columns.Add("NonMedicalLoadingPremium", typeof(string));
                dtPremiumDetails.Columns.Add("SumAssured", typeof(string));
                dtPremiumDetails.Columns.Add("ServiceTax", typeof(string));
                dtPremiumDetails.Columns.Add("TotalInstalmentPremium", typeof(string));
                dtPremiumDetails.Columns.Add("TotalPremiumAmount", typeof(string));                
                dtPremiumDetails.Columns.Add("ExtraPremiumAmt", typeof(string));                
                dtPremiumDetails.Columns.Add("BackDateintrest", typeof(string));               
                /*added by shri on 26 july 17 to create table structure for rider info*/
                /*dtPremiumDetails.Columns.Add("RiderInfo", typeof(string));
                dtPremiumDetails.Columns.Add("RiderType", typeof(string));*/
                /*end here*/
                for (i = 0; i < _dsContract.Tables[1].Rows.Count; i++)
                {
                    Logger.Info(strPQuoteNo + "STAG 2 :PageName :PremiumCalculationDetails.cs // MethodeName :PremiumCalculationPushService // Premium Calculation for" + _dsContract.Tables["PRODDTLS"].Rows[i]["ApplicationNo"].ToString() + "Begins");

                    #region Common feild Begins.
                    strApplicationNo = "'" + _dsContract.Tables["PRODDTLS"].Rows[i]["QuoteNo"].ToString() + "'";
                    strIsProposer = _dsContract.Tables["CLNTDTLS"].Rows[i]["IsProposer"].ToString();
                    strProdcode = _dsContract.Tables["PRODDTLS"].Rows[i]["PROD_productCode_CHDRTYPE"].ToString();
                    if (objChangeObj.App_backdate != null)
                    {
                        if (!objChangeObj.App_backdate._Backdate.Contains("1900-01-01"))
                        {
                            strdataValue = objChangeObj.App_backdate._Backdate;
                        }

                    }
                    if (objChangeObj.Prod_policydetails != null)
                    {
                        if (objChangeObj.Prod_policydetails._ProdcodeBase == strProdcode)
                        {
                            strPolicyTerm = objChangeObj.Prod_policydetails._PolicyTerm;
                            strPremiumpayingterm = objChangeObj.Prod_policydetails._Premiumpayingterm;
                            strSumassured = objChangeObj.Prod_policydetails._Sumassured;
                            strMonthlyPayout = objChangeObj.Prod_policydetails._MonthlyPayoutBase;
                            strBasepremiumamount = objChangeObj.Prod_policydetails._Basepremiumamount;
                        }
                        else
                        {
                            strPolicyTerm = objChangeObj.Prod_policydetails._PolicyTermCombo;
                            strPremiumpayingterm = objChangeObj.Prod_policydetails._PremiumpayingtermCombo;
                            strSumassured = objChangeObj.Prod_policydetails._SumassuredCombo;
                            strMonthlyPayout = objChangeObj.Prod_policydetails._MonthlyPayoutCombo;
                            strBasepremiumamount = objChangeObj.Prod_policydetails._BasepremiumamountCombo;
                        }
                        strPaymentfrequency = objChangeObj.Prod_policydetails._Paymentfrequency;
                        strAmountinsis = objChangeObj.Prod_policydetails._Amountinsis;
                        strTotalpremiumamount = objChangeObj.Prod_policydetails._TotalPremiumamount;
                    }
                    #endregion common feild end.

                    #region LifeAssuredEntity Mapping begins.
                    if (_dsContract.Tables["CLNTDTLS"].Rows.Count > 0)
                    {
                        Liferow = _dsContract.Tables["CLNTDTLS"].Select("relationshipToLifeAssured='LA'");

                        foreach (DataRow row in Liferow)
                        {
                            strLAclientId = row["CLT_clientId_CLNTNUM"].ToString();
                            isStaff = Convert.ToBoolean(row["APP_isStaff"].ToString());
                            isNSAP = Convert.ToBoolean(row["APP_isNSAP"].ToString());
                            strLifetype = row["clientType"].ToString();
                            objLifeAssuredEntity.Age = Convert.ToInt32(row["Age"].ToString());
                            objLifeAssuredEntity.PersonCoverType = row["PERSONCOVERTYPE"].ToString();
                            /*commented and added by shri on 11 aug 17*/
                            //objLifeAssuredEntity.SmokerStatus = row["IsSmoker"].ToString();
                            //objLifeAssuredEntity.DateOfBirth = Convert.ToDateTime(row["CLT_dob_CLTDOBX"].ToString());
                            //objLifeAssuredEntity.Gender = row["CLT_gender_CLTSEX"].ToString();
                            objLifeAssuredEntity.SmokerStatus = row["IsSmoker"].ToString();
                            if (objChangeObj.ClientDetails != null)
                            {
                                ClientDetails objClientDetails = objChangeObj.ClientDetails;
                                //objLifeAssuredEntity.SmokerStatus = (objClientDetails.IsSmoker) ? "True" : "False";
                                objLifeAssuredEntity.Gender = Convert.ToString(objClientDetails.ClientGender);
                                objLifeAssuredEntity.DateOfBirth = objClientDetails.ClientDob;
                            }
                            else
                            {
                                //objLifeAssuredEntity.SmokerStatus = row["IsSmoker"].ToString();
                                objLifeAssuredEntity.Gender = row["CLT_gender_CLTSEX"].ToString();
                                objLifeAssuredEntity.DateOfBirth = Convert.ToDateTime(row["CLT_dob_CLTDOBX"].ToString());
                            }
                            /*end here*/
                        }
                    }
                    #endregion LifeAssuredEntity Mapping end.

                    #region ProposerEntity Mapping begins.
                    if (strIsProposer == "1")
                    {
                        ProposerRow = _dsContract.Tables["CLNTDTLS"].Select("relationshipToLifeAssured='LA'");
                        foreach (DataRow row in ProposerRow)
                        {
                            strProposerClientId = row["CLT_clientId_CLNTNUM"].ToString();
                            objProposerEntity.Age = Convert.ToInt32(row["Age"].ToString());
                            objProposerEntity.DateOfBirth = Convert.ToDateTime(row["CLT_dob_CLTDOBX"].ToString());
                            objProposerEntity.Gender = row["CLT_gender_CLTSEX"].ToString();
                        }
                    }
                    else if (strIsProposer == "0")
                    {
                        if (_dsContract.Tables["CLNTDTLS"].Rows.Count > 0)
                        {
                            ProposerRow = _dsContract.Tables["CLNTDTLS"].Select("relationshipToLifeAssured='Nominee'");
                            foreach (DataRow row in ProposerRow)
                            {
                                strProposerClientId = row["CLT_clientId_CLNTNUM"].ToString();
                                objProposerEntity.Age = Convert.ToInt32(row["Age"].ToString());
                                objProposerEntity.DateOfBirth = Convert.ToDateTime(row["CLT_dob_CLTDOBX"].ToString());
                                objProposerEntity.Gender = row["CLT_gender_CLTSEX"].ToString();
                            }
                        }
                    }
                    else if (strPayerClientId != "" && strIsProposer == "2")
                    {
                        if (_dsContract.Tables["CLNTDTLS"].Rows.Count > 0)
                        {
                            ProposerRow = _dsContract.Tables["CLNTDTLS"].Select("relationshipToLifeAssured='payer'");
                            foreach (DataRow row in ProposerRow)
                            {
                                strProposerClientId = row["CLT_clientId_CLNTNUM"].ToString();
                                objProposerEntity.Age = Convert.ToInt32(row["Age"].ToString());
                                objProposerEntity.DateOfBirth = Convert.ToDateTime(row["CLT_dob_CLTDOBX"].ToString());
                                objProposerEntity.Gender = row["CLT_gender_CLTSEX"].ToString();
                            }
                        }
                    }
                    else
                    {
                        if (_dsContract.Tables["CLNTDTLS"].Rows.Count > 0)
                        {
                            ProposerRow = _dsContract.Tables["CLNTDTLS"].Select("relationshipToLifeAssured='proposer'");
                            foreach (DataRow row in ProposerRow)
                            {
                                strProposerClientId = row["CLT_clientId_CLNTNUM"].ToString();
                                objProposerEntity.Age = Convert.ToInt32(row["Age"].ToString());
                                objProposerEntity.DateOfBirth = Convert.ToDateTime(row["CLT_dob_CLTDOBX"].ToString());
                                objProposerEntity.Gender = row["CLT_gender_CLTSEX"].ToString();
                            }
                        }
                    }


                    #endregion ProposerEntity Mapping end.

                    #region ProductEntity Mapping begins
                    strAppNo = _dsContract.Tables["PRODDTLS"].Rows[i]["QuoteNo"].ToString();
                    //Agent Type is not mandetory in given soap request so passed as null.
                    if (!string.IsNullOrEmpty(_dsContract.Tables["PRODDTLS"].Rows[i]["AGENTCODE"].ToString()))
                    {
                        objAgent.GetAgentDetails(strPQuoteNo, _dsContract.Tables["PRODDTLS"].Rows[i]["AGENTCODE"].ToString(), ref AgentType);
                        if (!string.IsNullOrEmpty(AgentType))
                        {
                            objProductEntity.AgentType = AgentType;
                        }
                        else
                        {
                            strLAPushErrorcode = 1;
                            strLAPushStatus = "Agent Not Verified";
                            return;
                        }
                    }

                    //objProductEntity.AgentType = _dsContract.Tables["PRODDTLS"].Rows[i]["AgentType"].ToString();
                    //not getting the exact meaning so by the time pass 4 as passed in soap
                    objProductEntity.CashBackPeriod = Convert.ToInt32(_dsContract.Tables["PRODDTLS"].Rows[i]["CashBackPeriod"].ToString());
                    objProductEntity.Frequency = (string.IsNullOrEmpty(strPaymentfrequency)) ? Convert.ToInt32(_dsContract.Tables["PRODDTLS"].Rows[i]["POL_premPayingFreq"].ToString()) : Convert.ToInt32(strPaymentfrequency);
                    objProductEntity.ProductCode = _dsContract.Tables["PRODDTLS"].Rows[i]["PROD_productCode_CHDRTYPE"].ToString();
                    //ProductType Type is not mandetory in given soap request so passed as null.
                    objProductEntity.ProductType = _dsContract.Tables["PRODDTLS"].Rows[i]["PROD_productType"].ToString();
                    #endregion ProductEntity Mapping end.

                    #region PolicyEntity Mapping begins.
                    //not getting the exact meaning so by the time pass 4 as passed in soap
                    objPolicyEntity.AccrualPeriod = Convert.ToDouble(_dsContract.Tables["PRODDTLS"].Rows[i]["POL_accuralPeriod"].ToString());
                    objPolicyEntity.BranchCode = _dsContract.Tables["PRODDTLS"].Rows[i]["RECEIPTBRANCH"].ToString();

                    //not getting the exact value from table so by the time pass 4 as passed in soap
                    objPolicyEntity.IsStaff = isStaff;

                    //not getting the exact meaning so by the time pass 4 as passed in soap
                    objPolicyEntity.MethodOfPayment = _dsContract.Tables["PRODDTLS"].Rows[i]["RECEIPTBRANCH"].ToString();
                    objPolicyEntity.PolicyTerm = (string.IsNullOrEmpty(strPolicyTerm)) ? Convert.ToInt32(_dsContract.Tables["PRODDTLS"].Rows[i]["POL_policyTerm"].ToString()) : Convert.ToInt32(strPolicyTerm);
                    // objPolicyEntity.PolicyTerm = 0;

                    objPolicyEntity.PremiumPaymentTerm = (string.IsNullOrEmpty(strPremiumpayingterm)) ? Convert.ToInt32(_dsContract.Tables["PRODDTLS"].Rows[i]["POL_premPayingTerm"].ToString()) : Convert.ToInt32(strPremiumpayingterm);
                    // SumofReceipts is not mandetory .
                    //objPolicyEntity.SumofReceipts = Convert.ToDouble(_dsContract.Tables[0].Rows[i]["SumofReceipts"].ToString());

                    //not getting the exact meaning so by the time pass 0.0 as passed in soap

                    //objPolicyEntity.ULIPAmountReceived = (!string.IsNullOrEmpty(strMonthlyPayout)) ? Convert.ToDouble(strMonthlyPayout) : Convert.ToDouble(_dsContract.Tables["PRODDTLS"].Rows[i]["AnnualIncome"].ToString());
                    if (string.IsNullOrEmpty(strBasepremiumamount))
                    {
                        strBasepremiumamount = _dsContract.Tables["PRODDTLS"].Rows[i]["BasePremium"].ToString();
                    }

                    objPolicyEntity.ULIPAmountReceived = (Convert.ToDouble(strMonthlyPayout) != 0) ? Convert.ToDouble(strMonthlyPayout) : Convert.ToDouble(strBasepremiumamount);


                    #endregion PolicyEntity Mapping end.

                    #region SystemEntity Mapping end.

                    //objSystemEntity.BusinessDate =(string.IsNullOrEmpty(strdataValue))?Convert.ToDateTime(_dsContract.Tables["PRODDTLS"].Rows[i]["BUSSINESSDATE"].ToString()):Convert.ToDateTime(strdataValue);

                    objSystemEntity.BusinessDate = Convert.ToDateTime(_dsContract.Tables["PRODDTLS"].Rows[i]["BUSSINESSDATE"].ToString());
                    objSystemEntity.RiskCommencementDate = (string.IsNullOrEmpty(strdataValue)) ? Convert.ToDateTime(_dsContract.Tables["PRODDTLS"].Rows[i]["POL_riskCommencementDate"].ToString()) : Convert.ToDateTime(strdataValue);

                    #endregion SystemEntity Mapping end.


                    #region ChildEntity Mapping begin.
                    // I have not mappedd this because this is not mandetory and pass null in soap.

                    if (_dsContract.Tables.Count > 2 && _dsContract.Tables["CHILDDTLS"].Rows.Count > 0)
                    {
                        objChildEntity.ChildDateOfBirth = Convert.ToDateTime(_dsContract.Tables["CHILDDTLS"].Rows[0]["ChildDateOfBirth"]);
                        objChildEntity.Name = Convert.ToString(_dsContract.Tables["CHILDDTLS"].Rows[0]["Name"]);
                    }
                    #endregion ChildEntity Mapping end.

                    #region SystemEntity Mapping end.

                    if (_dsContract.Tables["RIDERDTLS"].Rows.Count > 0)
                    {
                        //strApplicationNo

                        if (objChangeObj.Load_Loadingdetails != null && objChangeObj.Load_Loadingdetails.lstLoadParam.Count > 0)
                        {
                            if (objChangeObj.Load_Loadingdetails.lstLoadParam != null)
                            {
                                if (objChangeObj.Load_Loadingdetails.lstLoadParam[0].strRiderCtg.Equals("BS"))
                                {
                                    NonMedicalLoadBS = Convert.ToInt32(objChangeObj.Load_Loadingdetails.lstLoadParam[0].strNonMedicalLoading);
                                    strMedicalClassBS = objChangeObj.Load_Loadingdetails.lstLoadParam[0].strMedicalLoadingClass;
                                }
                                else
                                {
                                    NonMedicalLoadAD = Convert.ToInt32(objChangeObj.Load_Loadingdetails.lstLoadParam[0].strNonMedicalLoading);
                                    strMedicalClassAD = objChangeObj.Load_Loadingdetails.lstLoadParam[0].strMedicalLoadingClass;
                                }
                            }
                        }

                        ApplicationCount = _dsContract.Tables["RIDERDTLS"].Select("QuoteNo=" + strApplicationNo);
                        int L = 0;
                        for (int k = 0; k < _dsContract.Tables["RIDERDTLS"].Rows.Count; k++)
                        {
                            if (strAppNo == _dsContract.Tables["RIDERDTLS"].Rows[k]["QuoteNo"].ToString())
                            {
                                LAPremiumCalService.RiderEntity objRiderEntity1 = new LAPremiumCalService.RiderEntity();
                                /*commented and added by shri on 24 july 17 to fetch rider info directly from db not from string */
                                if (_dsContract.Tables["RIDERDTLS"].Rows[k]["RiderCtg"].ToString() == "BS")
                                {
                                    objRiderEntity1.LifeType = strLifetype;
                                    objRiderEntity1.NonMedicalLoading = NonMedicalLoadBS;
                                    //added by amit to pass flat mortality for medical loading
                                    if (!string.IsNullOrEmpty(strMedicalClassBS))
                                        objRiderEntity1.MedicalLoadingClass = strMedicalClassBS;
                                    objRiderEntity1.NSAPFlag = isNSAP;
                                    objRiderEntity1.RiderCode = _dsContract.Tables["RIDERDTLS"].Rows[k]["RIDERCODE"].ToString();
                                    objRiderEntity1.RiderName = _dsContract.Tables["RIDERDTLS"].Rows[k]["SRID_riderName"].ToString();
                                    objRiderEntity1.RiderSumAssured = (string.IsNullOrEmpty(strSumassured)) ? Convert.ToDouble(_dsContract.Tables["RIDERDTLS"].Rows[k]["SRID_riderSumAssured"].ToString()) : Convert.ToDouble(strSumassured);
                                    LstRiderEntity.Add(objRiderEntity1);
                                }
                                else
                                {
                                    if (objChangeObj != null && objChangeObj.RiderInfo == null)
                                    {
                                        objRiderEntity1.LifeType = strLifetype;
                                        objRiderEntity1.NonMedicalLoading = NonMedicalLoadAD;
                                        //added by amit to pass flat mortality for medical loading
                                        if (!string.IsNullOrEmpty(strMedicalClassBS))
                                            objRiderEntity1.MedicalLoadingClass = strMedicalClassAD;
                                        objRiderEntity1.NSAPFlag = isNSAP;
                                        objRiderEntity1.RiderCode = _dsContract.Tables["RIDERDTLS"].Rows[k]["RIDERCODE"].ToString();
                                        objRiderEntity1.RiderName = _dsContract.Tables["RIDERDTLS"].Rows[k]["SRID_riderName"].ToString();
                                        objRiderEntity1.RiderSumAssured = Convert.ToDouble(_dsContract.Tables["RIDERDTLS"].Rows[k]["SRID_riderSumAssured"].ToString());
                                        LstRiderEntity.Add(objRiderEntity1);
                                    }
                                }
                                /*end here*/
                                L++;
                            }
                        }
                    }
                    if (objChangeObj != null && objChangeObj.RiderInfo != null)
                    {
                        for (int m = 0; m < objChangeObj.RiderInfo.Count; m++)
                        {
                            if (objChangeObj.RiderInfo[m].IsActive)
                            {
                                LAPremiumCalService.RiderEntity objRiderEntity1 = new LAPremiumCalService.RiderEntity();
                                objRiderEntity1.LifeType = strLifetype;
                                objRiderEntity1.NonMedicalLoading = 0;
                                objRiderEntity1.NSAPFlag = isNSAP;
                                objRiderEntity1.RiderCode = objChangeObj.RiderInfo[m].RiderId;
                                objRiderEntity1.RiderName = objChangeObj.RiderInfo[m].RiderName;
                                objRiderEntity1.RiderSumAssured = objChangeObj.RiderInfo[m].SumAssured;
                                LstRiderEntity.Add(objRiderEntity1);
                            }
                        }
                    }
                    if (LstRiderEntity != null && LstRiderEntity.Count > 0)
                    {
                        objRiderEntity = LstRiderEntity.ToArray();
                    }
                    else
                    {
                        objRiderEntity = new LAPremiumCalService.RiderEntity[0];
                    }
                    //objChangeObj.
                    #endregion SystemEntity Mapping end.
                    #region log
                    /*added by shri on 27 july 17 to add log of request and response */
                    string strLaEntity = CommFun.GetXMLFromObject(objLifeAssuredEntity);
                    string strProposerEntity = CommFun.GetXMLFromObject(objProposerEntity);
                    string strProductEntity = CommFun.GetXMLFromObject(objProductEntity);
                    string strPolicyEntity = CommFun.GetXMLFromObject(objPolicyEntity);
                    string strSystemEntity = CommFun.GetXMLFromObject(objSystemEntity);
                    string strRiderEntity = CommFun.GetXMLFromObject(objRiderEntity);
                    string strChildEntity = CommFun.GetXMLFromObject(objChildEntity);
                    strPartnerRequest = strLaEntity + strProposerEntity + strProductEntity + strPolicyEntity + strSystemEntity + strRiderEntity + strChildEntity;
                    string strErrorFromService = string.Empty;
                    //objcomm.MaintainLog(
                    /*end here*/
                    #endregion
                    #region Call Premium calculation service Begins.
                    objResponce = objInvoke.CalculatePremium(objLifeAssuredEntity, objProposerEntity, objProductEntity, objPolicyEntity, objSystemEntity, objRiderEntity, objChildEntity);
                    string strPartnerResponse = CommFun.GetXMLFromObject(objResponce);
                    #endregion Call Premium calculation service End.
                    // calculate Service responce Begins.
                    if (!string.IsNullOrEmpty(objResponce.TotalPremiumAmount.ToString()) && (objResponce.TotalPremiumAmount != 0.0))
                    {
                        Logger.Info(strPQuoteNo + " STAG 2 :PageName :PremiumCalculationDetails.cs // MethodeName :PremiumCalculationPushService" + System.Environment.NewLine + "Premium calculation service Succeed" + System.Environment.NewLine);
                        LAPremiumCalService.ComponentResults objCommDetails = new LAPremiumCalService.ComponentResults();
                        if (objResponce.CompDetail != null && objResponce.CompDetail.Length > 0)
                        {
                            objCompResult = new LAPremiumCalService.ComponentResults[objResponce.CompDetail.Length];
                            /*commented by shri on 26 july 17 to declare obj inside loop*/
                            //DataRow samplePremiumRow;
                            //samplePremiumRow = dtPremiumDetails.NewRow();               
                            /*end here*/
                            foreach (LAPremiumCalService.ComponentResults CompDetail in objResponce.CompDetail)
                            {
                                DataRow samplePremiumRow;
                                samplePremiumRow = dtPremiumDetails.NewRow();

                                //changes begin;amit; add all the premium calculation feild 
                                if (!string.IsNullOrEmpty(objResponce.BackdatedInt.ToString()) || objResponce.BackdatedInt != 0.0)
                                    samplePremiumRow["BackdatedInt"] = objResponce.BackdatedInt;

                                samplePremiumRow["ComponentCd"] = CompDetail.ComponentCd;
                                if (!string.IsNullOrEmpty(CompDetail.EduCess.ToString()) || CompDetail.EduCess != 0.0)
                                    samplePremiumRow["EduCess"] = CompDetail.EduCess;

                                if (!string.IsNullOrEmpty(CompDetail.ExtraPremiumAmt.ToString()) || CompDetail.ExtraPremiumAmt != 0.0)
                                    samplePremiumRow["ExtraPremiumAmt"] = CompDetail.ExtraPremiumAmt;
                                //CHNAGES DONE BY AMIT : BECAUSE FOR SOME PRODUCT PREMIUM SERVICE RETURN BASE PREMIUM AS 0
                                if (!string.IsNullOrEmpty(CompDetail.InstalmentPremiumAmt.ToString()))
                                {
                                    if (CompDetail.InstalmentPremiumAmt == 0.0 || strProdcode == "E41" || strProdcode=="E39" || 
                                        strProdcode == "E43" || strProdcode == "E44" || strProdcode == "E50" || strProdcode == "E51" ||
                                        strProdcode == "E52" || strProdcode == "T17" || strProdcode == "T16" || strProdcode == "E57" ||
                                        strProdcode == "E58" || strProdcode == "E36" || strProdcode == "E47" || strProdcode == "E31")
                                    {
                                        samplePremiumRow["InstalmentPremiumAmt"] = strBasepremiumamount;
                                        
                                    }
                                    else
                                    {
                                        samplePremiumRow["InstalmentPremiumAmt"] = CompDetail.InstalmentPremiumAmt;
                                    }
                                }



                                if (!string.IsNullOrEmpty(CompDetail.LifeType.ToString()))
                                    samplePremiumRow["LifeType"] = CompDetail.LifeType;

                                if (!string.IsNullOrEmpty(CompDetail.MedicalLoadingPremium.ToString()) || CompDetail.MedicalLoadingPremium != 0.0)
                                    samplePremiumRow["MedicalLoadingPremium"] = CompDetail.MedicalLoadingPremium;

                                if (!string.IsNullOrEmpty(CompDetail.MedicalLoadingRate.ToString()) || CompDetail.MedicalLoadingRate != 0.0)
                                    samplePremiumRow["MedicalLoadingRate"] = CompDetail.MedicalLoadingRate;

                                if (!string.IsNullOrEmpty(CompDetail.ModalPremiumAmt.ToString()) || CompDetail.ModalPremiumAmt != 0.0)
                                    samplePremiumRow["ModalPremiumAmt"] = CompDetail.ModalPremiumAmt;

                                if (!string.IsNullOrEmpty(CompDetail.NonMedicalLoadingPremium.ToString()) || CompDetail.NonMedicalLoadingPremium != 0.0)
                                    samplePremiumRow["NonMedicalLoadingPremium"] = CompDetail.NonMedicalLoadingPremium;

                                if (!string.IsNullOrEmpty(CompDetail.NonMedicalLoadingRate.ToString()) || CompDetail.NonMedicalLoadingRate != 0.0)
                                    samplePremiumRow["NonMedicalLoadingRate"] = CompDetail.NonMedicalLoadingRate;

                                if (!string.IsNullOrEmpty(CompDetail.RiderCtg.ToString()))
                                    samplePremiumRow["RiderCtg"] = CompDetail.RiderCtg;

                                if (!string.IsNullOrEmpty(CompDetail.RiderPPT.ToString()))
                                    samplePremiumRow["RiderPPT"] = CompDetail.RiderPPT;

                                if (!string.IsNullOrEmpty(CompDetail.RiderPT.ToString()))
                                    samplePremiumRow["RiderPT"] = CompDetail.RiderPT;

                                if (!string.IsNullOrEmpty(CompDetail.SeriveTax.ToString()) || CompDetail.SeriveTax != 0.0)
                                    samplePremiumRow["SeriveTax"] = CompDetail.SeriveTax;

                                if (!string.IsNullOrEmpty(CompDetail.SeriveTax.ToString()) || CompDetail.SeriveTax != 0.0)
                                    samplePremiumRow["ServiceTax"] = CompDetail.SeriveTax;
                                
                                if (!string.IsNullOrEmpty(CompDetail.SumAssured.ToString()) || CompDetail.SumAssured != 0.0)
                                    samplePremiumRow["SumAssured"] = CompDetail.SumAssured;

                                if (!string.IsNullOrEmpty(CompDetail.SumAssuredAcrossPlans.ToString()) || CompDetail.SumAssuredAcrossPlans != 0.0)
                                    samplePremiumRow["SumAssuredAcrossPlans"] = CompDetail.SumAssuredAcrossPlans;

                                if (!string.IsNullOrEmpty(objResponce.TotalInstalmentPremium.ToString()) || objResponce.TotalInstalmentPremium != 0.0)
                                    samplePremiumRow["TotalInstalmentPremium"] = objResponce.TotalInstalmentPremium;

                                if (!string.IsNullOrEmpty(objResponce.TotalPremiumAmount.ToString()) || objResponce.TotalPremiumAmount != 0.0)
                                    samplePremiumRow["TotalPremiumAmount"] = objResponce.TotalPremiumAmount;

                                samplePremiumRow["RiderInfo"] = CompDetail.ComponentCd;
                                samplePremiumRow["RiderType"] = CompDetail.RiderCtg;
                                samplePremiumRow["ProductCode"] = objProductEntity.ProductCode;

                                dtPremiumDetails.Rows.Add(samplePremiumRow);

                            }
                        }
                        foreach (string strError in objResponce.BRErrMessages)
                        {
                            strLAPushStatus += strError + System.Environment.NewLine;
                        }
                    }
                    else
                    {
                        foreach (string strError in objResponce.BRErrMessages)
                        {
                            strLAPushStatus += strError + System.Environment.NewLine;
                        }
                    }
                    // calculate Service responce End.
                    /*added by shri on 27 july 17 to maintain log*/
                    if (string.IsNullOrEmpty(strLAPushStatus))
                    {
                        strErrorFromService = string.Empty;
                    }
                    else
                    {
                        strErrorFromService = strLAPushStatus;
                    }
                    objcomm.MaintainLog("PremiumCalculationDetails", "PREMCAL", strPartnerRequest, strPartnerResponse, string.Empty, string.Empty, "UWSaral", "UWSaral"
                            , strErrorFromService, strAppNo);
                    /*end here*/
                }
                //_dsContractValResult = new DataSet();
                //_dsContractValResult.Locale = CultureInfo.InvariantCulture;
                //DataTable sampleDataTable = _dsContractValResult.Tables.Add("SampleData");
                //DataRow sampleDataRow;
                //sampleDataTable.Columns.Add("ProductCode", typeof(string));
                //sampleDataTable.Columns.Add("InstalmentPremiumAmt", typeof(string));
                //sampleDataTable.Columns.Add("MedicalLoadingPremium", typeof(string));
                //sampleDataTable.Columns.Add("NonMedicalLoadingPremium", typeof(string));
                //sampleDataTable.Columns.Add("SumAssured", typeof(string));
                //sampleDataTable.Columns.Add("ServiceTax", typeof(string));
                //sampleDataTable.Columns.Add("TotalInstalmentPremium", typeof(string));
                //sampleDataTable.Columns.Add("TotalPremiumAmount", typeof(string));
                //sampleDataRow = sampleDataTable.NewRow();

                //if (objResponce.CompDetail != null && objResponce.CompDetail.Length > 0)
                //{
                //    objCompResult = new LAPremiumCalService.ComponentResults[objResponce.CompDetail.Length];
                //    foreach (LAPremiumCalService.ComponentResults CompDetail in objResponce.CompDetail)
                //    {
                //        if (!string.IsNullOrEmpty(CompDetail.InstalmentPremiumAmt.ToString()) || CompDetail.InstalmentPremiumAmt != 0.0)
                //            sampleDataRow["InstalmentPremiumAmt"] = strInstalmentPremiumAmt;
                //        if (CompDetail.MedicalLoadingPremium != 0.0)
                //            sampleDataRow["MedicalLoadingPremium"] = strMedicalLoadingPremium;
                //        if (CompDetail.NonMedicalLoadingPremium != 0.0)
                //            sampleDataRow["NonMedicalLoadingPremium"] = strNonMedicalLoadingPremium;
                //        if (CompDetail.SumAssured != 0.0)
                //            sampleDataRow["SumAssured"] = strSumAssured;
                //        if (CompDetail.SeriveTax != 0.0)
                //            sampleDataRow["ServiceTax"] = strServicetax;
                //    }
                //    sampleDataRow["TotalInstalmentPremium"] = srTotalInstalmentPremium;
                //    sampleDataRow["TotalPremiumAmount"] = strTotalPremiumAmount;
                //    sampleDataTable.Rows.Add(sampleDataRow);
                //}


                if (string.IsNullOrEmpty(strLAPushStatus))
                {
                    //strLAPushStatus = "Success";
                    strLAPushErrorcode = 0;
                    Logger.Info(strPQuoteNo + "*******Premium Calculation  end for " + strPQuoteNo + "******" + System.Environment.NewLine);
                }
                else
                {
                    strLAPushErrorcode = 1;
                    Logger.Info(strPQuoteNo + "*******Premium Calculation  end for " + strPQuoteNo + "******" + System.Environment.NewLine);
                    objcomm.SaveErrorLogs(strPQuoteNo, "Failed", "UWSaralServices", "PremiumCalculationDetails.cs", "PremiumCalculationPushService", "E-ServiceCallError", "", "", strLAPushStatus.ToString());
                }

            }
            catch (Exception Error)
            {
                /*added by shri on 22 aug 17 to maintain error log */
                objcomm.MaintainLog("PremiumCalculationDetails", "PREMCAL", strPartnerRequest, string.Empty, string.Empty, string.Empty, "UWSaral", "UWSaral"
                            , Error.Message, strAppNo);
                /*end here*/
                strLAPushErrorcode = -1;
                strLAPushStatus = "Success";
                strLAPushStatus = "Error in Premium calculation,Please contact System Team";
                Logger.Error(strPQuoteNo + "STAG 2 :PageName :PremiumCalculationDetails.CS // MethodeName :PremiumCalculationPushService Error :" + System.Environment.NewLine + Error.ToString());
                objcomm.SaveErrorLogs(strPQuoteNo, "Failed", "UWSaralServices", "PremiumCalculationDetails.cs", "PremiumCalculationPushService", "E-ExceptionError", "", "", Error.ToString());
                Logger.Info(strPQuoteNo + "*******Premium Calculation  end for " + strPQuoteNo + "******" + System.Environment.NewLine);
            }
        }

    }

}
