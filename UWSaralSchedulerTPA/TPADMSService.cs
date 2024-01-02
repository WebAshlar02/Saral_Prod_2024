using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using UWSaralServices;
using UWSaralObjects;
using System.Configuration;
using Platform.Utilities.LoggerFramework;
using System.Net;


namespace UWSaralSchedulerTPA
{
    public class TPA_DMS_Service
    {
        DataSet _ds;
        UWSaralServices.CommFun objRevampCommFun;
        public static void Main()
        {
            try
            {
                Logger.Info("***********************DMS Service Start****************************" + System.Environment.NewLine);
                //check whether service is running or not 
                Logger.Info("***********************Check whether service is already running or not****************************" + System.Environment.NewLine);
                TPA_DMS_Service objTPA_DMS_Service = new TPA_DMS_Service();
                //objTPA_DMS_Service.OldCasesMedicalValue();
                objTPA_DMS_Service.RevampMedicalCases();
            }
            catch (Exception Error)
            {
                CommFun objComm = new CommFun();
                Logger.Error("STAG 2 :PageName :TPA_DMS_Service.CS // MethodeName :Main Error :" + System.Environment.NewLine + Error.ToString());
                objComm.SaveErrorLogs(string.Empty, "Failed", "TPA_DMS_Service", "Commfun.cs", "Main", "E-Error", "", "", Error.ToString());
            }
        }

        //check whether application is running or not 
        private static bool AlreadyRunning()
        {
            Process[] processes = Process.GetProcesses();
            Process currentProc = Process.GetCurrentProcess();

            foreach (Process process in processes)
            {
                try
                {
                    if (process.Modules[0].FileName == System.Reflection.Assembly.GetExecutingAssembly().Location
                                && currentProc.Id != process.Id)
                        return true;
                }
                catch (Exception ex)
                {
                    CommFun objComm = new CommFun();
                    objComm.SaveErrorLogs(string.Empty, "Failed", "TPA_DMS_Service", "Commfun.cs", "Main", "E-Error", "", "", ex.ToString());
                }
            }

            return false;
        }

        private void FetchPDF(TIF objTif)
        {
            try
            {
                UWSaralServices.CommFun objCommFun = new CommFun();
                Logger.Error("STAG 3 :PageName :TPA_DMS_Service.CS // MethodeName :FetchPDF Start" + System.Environment.NewLine);
                string strFilePath = Properties.Settings.Default.SourcePath;
                if (Directory.Exists(strFilePath))
                {
                    string strFullFile = Path.Combine(strFilePath, objTif.FileName);
                    if (File.Exists(strFullFile))
                    {
                        objTif.Flag = 0;
                    }
                    else
                    {
                        objTif.Flag = -3;
                    }

                }
                else
                {
                    objTif.Flag = -2;
                }
                if (objTif.Flag == 0)
                {
                    int intRef = -1;
                    objCommFun.InsertDMSLog(objTif.ApplicationNo, "Found", ref intRef);
                }
                else
                {
                    int intRef = -1;
                    objCommFun.InsertDMSLog(objTif.ApplicationNo, "Not Found", ref intRef);
                }
                Logger.Error("STAG 3 :PageName :TPA_DMS_Service.CS // MethodeName :FetchPDF End" + System.Environment.NewLine);
            }
            catch (Exception ex)
            {
                CommFun objComm = new CommFun();
                objTif.Flag = 1;
                objTif.Message = "FetchPDF " + ex.Message;
                Logger.Error("STAG 3 :PageName :TPA_DMS_Service.CS // MethodeName :FetchPDF Error :" + System.Environment.NewLine + ex.ToString());
                objComm.SaveErrorLogs(string.Empty, "Failed", "TPA_DMS_Service", "Commfun.cs", "Main", "E-Error", "", "", ex.ToString());
            }
        }
        private void FetchPDF_MER(TIF objTif_MER)
        {
            try
            {
                UWSaralServices.CommFun objCommFun = new CommFun();
                Logger.Error("STAG 3 :PageName :TPA_DMS_Service.CS // MethodeName :FetchPDF Start" + System.Environment.NewLine);
                string strFilePath = Properties.Settings.Default.SourcePath;
                if (Directory.Exists(strFilePath))
                {

                    string strFullFileMER = Path.Combine(strFilePath, objTif_MER.FileNameMER);
                    if (File.Exists(strFullFileMER))
                    {
                        //objTif.bytArrSend = System.IO.File.ReadAllBytes(strFullFile);
                        //objTif.Extension = Path.GetExtension(strFullFile);
                        objTif_MER.Flag = 0;
                    }
                    else
                    {
                        objTif_MER.Flag = -3;
                    }
                }
                else
                {
                    objTif_MER.Flag = -2;
                }
                if (objTif_MER.Flag == 0)
                {
                    int intRef = -1;
                    objCommFun.InsertDMSLog(objTif_MER.ApplicationNo, "Found", ref intRef);
                }
                else
                {
                    int intRef = -1;
                    objCommFun.InsertDMSLog(objTif_MER.ApplicationNo, "Not Found", ref intRef);
                }
                Logger.Error("STAG 3 :PageName :TPA_DMS_Service.CS // MethodeName :FetchPDF End" + System.Environment.NewLine);
            }
            catch (Exception ex)
            {
                CommFun objComm = new CommFun();
                objTif_MER.Flag = 1;
                objTif_MER.Message = "FetchPDF " + ex.Message;
                Logger.Error("STAG 3 :PageName :TPA_DMS_Service.CS // MethodeName :FetchPDF Error :" + System.Environment.NewLine + ex.ToString());
                objComm.SaveErrorLogs(string.Empty, "Failed", "TPA_DMS_Service", "Commfun.cs", "Main", "E-Error", "", "", ex.ToString());
            }
        }
        private void FetchImageFromBytes(TIF objTiff)
        {
            try
            {
                UWSaralServices.CommFun objCommFun = new CommFun();
                Logger.Error("STAG 5 :PageName :TPA_DMS_Service.CS // MethodeName :FetchImageFromBytes Start " + System.Environment.NewLine);
                //File.WriteAllBytes(Path.Combine(Properties.Settings.Default.DestinationPath, objTiff.FileNameWithTiffExtension), objTiff.bytArrReceive);
                string FTPpathName = Properties.Settings.Default.DestinationPath;
                string FTPUserName = Properties.Settings.Default.UserName;
                string FTPPassword = Properties.Settings.Default.Password;
                string strFilePath = Properties.Settings.Default.SourcePath;
                string strappno = objTiff.ApplicationNo;
                string strFullFile = Path.Combine(strFilePath, objTiff.FileName);
                objTiff.Flag = 1;
                if (File.Exists(strFullFile))
                {

                    FileInfo objfileinfo = null;
                    objfileinfo = new FileInfo(strFullFile);
                    string str = string.Empty;
                    if (objTiff.FileName.Contains("MER"))
                    {
                        str = "New Business_" + strappno + "_" + "Medical Requirement MER.pdf";
                    }
                    else
                    {
                        str = "New Business_" + strappno + "_" + "Medical Requirement.pdf";
                    }
                    string PushedtoDMS = string.Empty;
                    PushedtoDMS = FTPpathName + "\\FG_Processed_Upload" + "\\" + str;
                    objfileinfo.CopyTo(FTPpathName + "\\" + str, true);
                    objTiff.Flag = 0;
                }
                Logger.Error("STAG 5 :PageName :TPA_DMS_Service.CS // MethodeName :FetchImageFromBytes End " + System.Environment.NewLine);
            }
            catch (Exception Error)
            {
                CommFun objComm = new CommFun();
                objTiff.Flag = 1;
                objTiff.Message = "FetchImageFromBytes " + Error.Message;
                Logger.Error("STAG 5 :PageName :TPA_DMS_Service.CS // MethodeName :FetchImageFromBytes Error :" + System.Environment.NewLine + Error.ToString());
                objComm.SaveErrorLogs(string.Empty, "Failed", "TPA_DMS_Service", "Commfun.cs", "Main", "E-Error", "", "", Error.ToString());
            }
        }
        private void FetchImageFromBytes_MER(TIF objTiff_MER)
        {
            try
            {
                UWSaralServices.CommFun objCommFun = new CommFun();
                Logger.Error("STAG 5 :PageName :TPA_DMS_Service.CS // MethodeName :FetchImageFromBytes Start " + System.Environment.NewLine);
                //File.WriteAllBytes(Path.Combine(Properties.Settings.Default.DestinationPath, objTiff.FileNameWithTiffExtension), objTiff.bytArrReceive);
                string FTPpathName = Properties.Settings.Default.DestinationPath;
                string FTPUserName = Properties.Settings.Default.UserName;
                string FTPPassword = Properties.Settings.Default.Password;
                string strFilePath = Properties.Settings.Default.SourcePath;
                string strappno_MER = objTiff_MER.ApplicationNo;
                string strFullFile = Path.Combine(strFilePath, objTiff_MER.FileNameMER);
                objTiff_MER.Flag = 1;
                if (File.Exists(strFullFile))
                {

                    FileInfo objfileinfo = null;
                    objfileinfo = new FileInfo(strFullFile);
                    string str = string.Empty;
                    str = "New Business_" + strappno_MER + ".pdf";
                    string PushedtoDMS = string.Empty;
                    PushedtoDMS = FTPpathName + "\\FG_Processed_Upload" + "\\" + str;
                    //objCommFun.FetchDMSPushedData(ref _ds);                    
                    objfileinfo.CopyTo(FTPpathName + "\\" + str, true);
                    objTiff_MER.Flag = 0;
                }
                Logger.Error("STAG 5 :PageName :TPA_DMS_Service.CS // MethodeName :FetchImageFromBytes End " + System.Environment.NewLine);
            }
            catch (Exception Error)
            {
                CommFun objComm = new CommFun();
                objTiff_MER.Flag = 1;
                objTiff_MER.Message = "FetchImageFromBytes " + Error.Message;
                Logger.Error("STAG 5 :PageName :TPA_DMS_Service.CS // MethodeName :FetchImageFromBytes Error :" + System.Environment.NewLine + Error.ToString());
                objComm.SaveErrorLogs(string.Empty, "Failed", "TPA_DMS_Service", "Commfun.cs", "Main", "E-Error", "", "", Error.ToString());
            }
        }

        private bool OldCasesMedicalValue()
        {
            //fetch data 
            UWSaralServices.CommFun objCommFun = new CommFun();
            List<TIF> lstTiff = new List<TIF>();
            DataSet _ds = new DataSet();
            DataTable dtFile = new DataTable();
            DataTable dtFileMER = new DataTable();

            Logger.Info("***********************Fetch no of documents which is to be pushed****************************" + System.Environment.NewLine);
            objCommFun.UWSaralTPA_Fetch_document_To_Be_Pushed(ref _ds);
            if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
            {
                dtFile = _ds.Tables[0];
                dtFileMER = _ds.Tables[1];
            }
            if (dtFile != null)
            {
                ListTIff listTiff = new ListTIff();

                for (int i = 0; i < dtFile.Rows.Count; i++)
                {

                    TIF objTiff = new TIF();
                    TPA_DMS_Service objTpaDmsService = new TPA_DMS_Service();

                    objTiff.FileName = Convert.ToString(dtFile.Rows[i]["FileName"]) + ".pdf";
                    objTiff.ApplicationNo = Convert.ToString(dtFile.Rows[i]["ApplicationNo"]);
                    string strErrorMessage = string.Empty;
                    if (objTiff.ApplicationNo == "D00297193")
                    {
                        //convert to bytes of array                                                   
                        Logger.Info("***********************Fetch file from source**************************** " + objTiff.FileName + System.Environment.NewLine);
                        objTpaDmsService.FetchPDF(objTiff);
                        if (objTiff.Flag != 1)
                        {
                            //convert into tiff 
                            TiffConversion objTiffConversion = new TiffConversion();
                            Logger.Info("***********************Convert into tiff file **************************** " + objTiff.FileName + System.Environment.NewLine);
                            //objTiffConversion.ConsumeTiffConversion(objTiff, ref strErrorMessage);
                            //if (objTiff.Flag != 1 && objTiff.bytArrReceive != null && objTiff.bytArrReceive.Length > 0)
                            //{
                            //place it in destination folder
                            Logger.Info("***********************save it in dmz folder**************************** " + objTiff.FileName + System.Environment.NewLine);
                            objTpaDmsService.FetchImageFromBytes(objTiff);
                            //}
                            //else
                            //{
                            //    objTiff.Flag = -4;
                            //}
                        }
                        objTiff.GetMessage();
                        if (objTiff.Flag == 0)
                        {
                            //update status
                            Logger.Info("***********************update resolve status**************************** " + objTiff.ApplicationNo + Environment.NewLine);
                            int intRef = -1;
                            objCommFun.UpdateTPAResolveStatus(objTiff.ApplicationNo, ref intRef);
                        }

                        lstTiff.Add(objTiff);
                        listTiff.LstTiff = lstTiff;
                        Logger.Info("***********************insert status of process**************************** " + objTiff.FileName + Environment.NewLine);
                    }
                }
                //UPDATE FLAG OF DOCUMENT PUSHED 
                int intRet = -1;
                objCommFun.UWSaralTPAUpdateDocumentStatus(listTiff.DtLstTiff, ref intRet);
            }
            //For MER file pushed to DMS 
            if (dtFileMER != null)
            {
                ListTIff_MER listTiff_MER = new ListTIff_MER();
                lstTiff.Clear();
                for (int i = 0; i < dtFileMER.Rows.Count; i++)
                {

                    TIF objTiff_MER = new TIF();
                    TPA_DMS_Service objTpaDmsService = new TPA_DMS_Service();

                    //objTiff.FileName = Convert.ToString(dtFile.Rows[i]["FileName"]) + ".pdf";
                    objTiff_MER.ApplicationNo = Convert.ToString(dtFileMER.Rows[i]["ApplicationNo"]);
                    objTiff_MER.FileNameMER = Convert.ToString(dtFileMER.Rows[i]["FileName"]) + ".pdf";

                    string strErrorMessage = string.Empty;

                    //convert to bytes of array                                                   
                    Logger.Info("***********************Fetch file from source**************************** " + objTiff_MER.FileNameMER + System.Environment.NewLine);
                    objTpaDmsService.FetchPDF_MER(objTiff_MER);
                    if (objTiff_MER.Flag != 1)
                    {
                        //convert into tiff 
                        TiffConversion objTiffConversion = new TiffConversion();
                        Logger.Info("***********************Convert into tiff file **************************** " + objTiff_MER.FileNameMER + System.Environment.NewLine);
                        //objTiffConversion.ConsumeTiffConversion(objTiff, ref strErrorMessage);
                        //if (objTiff.Flag != 1 && objTiff.bytArrReceive != null && objTiff.bytArrReceive.Length > 0)
                        //{
                        //place it in destination folder
                        Logger.Info("***********************save it in dmz folder**************************** " + objTiff_MER.FileNameMER + System.Environment.NewLine);
                        objTpaDmsService.FetchImageFromBytes_MER(objTiff_MER);
                        //}
                        //else
                        //{///
                        //    objTiff.Flag = -4;
                        //}
                    }
                    objTiff_MER.GetMessage();
                    if (objTiff_MER.Flag == 0)
                    {
                        //update status
                        Logger.Info("***********************update resolve status**************************** " + objTiff_MER.ApplicationNo + Environment.NewLine);
                        int intRef = -1;
                        objCommFun.UpdateTPAResolveStatus(objTiff_MER.ApplicationNo, ref intRef);
                    };

                    lstTiff.Add(objTiff_MER);

                    listTiff_MER.LstTiff_MER = lstTiff;

                    Logger.Info("***********************insert status of process**************************** " + objTiff_MER.FileNameMER + Environment.NewLine);

                }
                //UPDATE FLAG OF DOCUMENT PUSHED 
                int intRet = -1;
                objCommFun.UWSaralTPAUpdateDocumentStatus_MER(listTiff_MER.DtLstTiff_MER, ref intRet);
            }

            return true;
        }

        private bool RevampMedicalCases()
        {
            _ds = new DataSet();
            //fetch records which medical have been received 
            FetchApplicationMedicalReceived(ref _ds);

            //fetch medical record and move it to DMS
            
            MoveMedicalToDMS(_ds);
            return true;
        }

        private void FetchApplicationMedicalReceived(ref DataSet _ds)
        {
            objRevampCommFun = new CommFun();
            objRevampCommFun.FetchRevampMedicalReceived(ref _ds);
        }

        private void MoveMedicalToDMS(DataSet _ds)
        {
            if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
            {
                objRevampCommFun = new CommFun();
                int intRef = -1;
                for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                {
                    switch (Convert.ToInt32(_ds.Tables[0].Rows[i]["partnerrefkey"]))
                    {
                        case 1:
                            {
                                TIF objTiff = new TIF();
                                objTiff.FileName = Convert.ToString(_ds.Tables[0].Rows[i]["FileName"]) + ".pdf";
                                objTiff.ApplicationNo = Convert.ToString(_ds.Tables[0].Rows[i]["ApplicationNo"]);
                                string strErrorMessage = string.Empty;
                                MoveToDMS(objTiff);
                                objTiff.GetMessage();
                                if (objTiff.Flag == 0)
                                {
                                    //update status
                                    Logger.Info("***********************update resolve status**************************** " + objTiff.ApplicationNo + Environment.NewLine);
                                    if (Convert.ToString(_ds.Tables[0].Rows[i]["CHANNEL"]).ToUpper() == "ONLINE")
                                    {
                                        objRevampCommFun.UpdateTPAResolveStatus(Convert.ToString(_ds.Tables[0].Rows[i]["applicationno"]), ref intRef);
                                    }
                                    else
                                    {
                                        objRevampCommFun.UpdateTPAResolveStatus(objTiff.ApplicationNo, ref intRef);
                                    }
                                    objRevampCommFun.UWSaralTPAUpdateDocumentStatus(Convert.ToString(_ds.Tables[0].Rows[i]["FileName"]), objTiff.Flag, objTiff.Message, ref intRef);

                                }

                                //MER DATA
                                objTiff.FileName = Convert.ToString(_ds.Tables[0].Rows[i]["FileName"]) + "_MER.pdf";
                                objTiff.ApplicationNo = Convert.ToString(_ds.Tables[0].Rows[i]["ApplicationNo"]);
                                MoveToDMS(objTiff);
                                objTiff.GetMessage();

                                if (objTiff.Flag == 0)
                                {
                                    //update status
                                    Logger.Info("***********************update resolve status**************************** " + objTiff.ApplicationNo + Environment.NewLine);
                                    if (Convert.ToString(_ds.Tables[0].Rows[i]["CHANNEL"]).ToUpper() == "ONLINE")
                                    {
                                        objRevampCommFun.UpdateTPAResolveStatus(Convert.ToString(_ds.Tables[0].Rows[i]["applicationno"]), ref intRef);
                                    }
                                    else
                                    {
                                        objRevampCommFun.UpdateTPAResolveStatus(objTiff.ApplicationNo, ref intRef);
                                    }
                                    objRevampCommFun.UWSaralTPAUpdateDocumentStatus(Convert.ToString(_ds.Tables[0].Rows[i]["FileName"]), objTiff.Flag, objTiff.Message, ref intRef);

                                }
                                break;
                            }
                        case 2:
                            {
                                MonthFileDownload(Convert.ToString(_ds.Tables[0].Rows[i]["filename"]), Convert.ToString(_ds.Tables[0].Rows[i]["ApplicationNo"]), Convert.ToString(_ds.Tables[0].Rows[i]["PreviousApplicationNo"]));
                                break;
                            }

                    }
                }
            }
        }

        private void MoveToDMS(TIF objTiff)
        {

            //DMSDownload.DMSDocumentDownloadService dMSDownload = new UWSaralSchedulerTPA.DMSDownload.DMSDocumentDownloadService();
            //dMSDownload.getDocfromDocList()
            TPA_DMS_Service objTpaDmsService = new TPA_DMS_Service();
            //convert to bytes of array                                                   
            Logger.Info("***********************Fetch file from source**************************** " + objTiff.FileName + System.Environment.NewLine);
            objTpaDmsService.FetchPDF(objTiff);
            if (objTiff.Flag != 1)
            {
                //convert into tiff 
                TiffConversion objTiffConversion = new TiffConversion();
                Logger.Info("***********************Convert into tiff file **************************** " + objTiff.FileName + System.Environment.NewLine);
                objTpaDmsService.FetchImageFromBytes(objTiff);
            }
            Logger.Info("***********************insert status of process**************************** " + objTiff.FileName + Environment.NewLine);
        }

        private void MonthFileDownload(string strTPARefNo, string strCurrentApplicationNo, string strPreviousApplicationNo)
        {
            objRevampCommFun = new CommFun();
            int intRef = -1;
            //DOWNLOAD FILE AT A PATH ON SERVER
            if (DownloadPreviousFile(strPreviousApplicationNo))
            {
                //UPLOAD TO DMS WITH CURRENT FILE NAME
                if (MoveToDMS(strCurrentApplicationNo, strPreviousApplicationNo))
                {
                    //update document status
                    objRevampCommFun.UWSaralTPAUpdateDocumentStatus(strTPARefNo, 0, "Success", ref intRef);
                    //tpa resolve flag
                    //objRevampCommFun.UpdateTPAResolveStatus(strCurrentApplicationNo, ref intRef);
                }
            }
        }

        private bool DownloadPreviousFile(string strPreviousApplicationNo)
        {
            string strDocType = Properties.Settings.Default.DocType
                , strFilePath = Properties.Settings.Default.DMSDownloadPath, strAppName = Properties.Settings.Default.SystemName;
            DMSDownload.DMSDocumentDownloadService objDMSDocumentDownloadService = new DMSDownload.DMSDocumentDownloadServiceClient();
            return objDMSDocumentDownloadService.getDocfromDocList(strPreviousApplicationNo, strDocType, strFilePath, strAppName);

        }

        private bool MoveToDMSOld(string strCurrentApplicationNo, string PreviousApplicationNo)
        {
            try
            {
                UWSaralServices.CommFun objCommFun = new CommFun();
                Logger.Error("STAG 5 :PageName :TPA_DMS_Service.CS // MethodeName :FetchImageFromBytes Start " + System.Environment.NewLine);
                //File.WriteAllBytes(Path.Combine(Properties.Settings.Default.DestinationPath, objTiff.FileNameWithTiffExtension), objTiff.bytArrReceive);
                string FTPpathName = Properties.Settings.Default.DestinationPath;
                string FTPUserName = Properties.Settings.Default.UserName;
                string FTPPassword = Properties.Settings.Default.Password;
                string strFilePath = Properties.Settings.Default.DMSDownloadPath;
                string strappno = strCurrentApplicationNo;
                string strFullFile = Path.Combine(strFilePath, PreviousApplicationNo, PreviousApplicationNo + "_Medical Requirement.pdf");
                if (File.Exists(strFullFile))
                {

                    FileInfo objfileinfo = null;
                    objfileinfo = new FileInfo(strFullFile);
                    string str = string.Empty;
                    str = "New Business_" + strappno + "_" + "Medical Requirement.pdf";
                    string PushedtoDMS = string.Empty;
                    PushedtoDMS = FTPpathName + "\\FG_Processed_Upload" + "\\" + str;

                    objfileinfo.CopyTo(FTPpathName + "\\" + str, true);
                }
                Logger.Error("STAG 5 :PageName :TPA_DMS_Service.CS // MethodeName :FetchImageFromBytes End " + System.Environment.NewLine);
                return true;
            }
            catch (Exception Error)
            {
                CommFun objComm = new CommFun();
                Logger.Error("STAG 5 :PageName :TPA_DMS_Service.CS // MethodeName :FetchImageFromBytes Error :" + System.Environment.NewLine + Error.ToString());
                objComm.SaveErrorLogs(string.Empty, "Failed", "TPA_DMS_Service", "Commfun.cs", "Main", "E-Error", "", "", Error.ToString());
                return false;
            }
        }

        private bool MoveToDMS(string strCurrentApplicationNo, string PreviousApplicationNo)
        {
            try
            {
                UWSaralServices.CommFun objCommFun = new CommFun();
                Logger.Error("STAG 5 :PageName :TPA_DMS_Service.CS // MethodeName :FetchImageFromBytes Start " + System.Environment.NewLine);
                //File.WriteAllBytes(Path.Combine(Properties.Settings.Default.DestinationPath, objTiff.FileNameWithTiffExtension), objTiff.bytArrReceive);
                string FTPpathName = Properties.Settings.Default.DestinationPath;
                string FTPUserName = Properties.Settings.Default.UserName;
                string FTPPassword = Properties.Settings.Default.Password;
                string strFilePath = Properties.Settings.Default.DMSDownloadPath;
                string strappno = strCurrentApplicationNo;

                string strFullFile = Path.Combine(strFilePath, PreviousApplicationNo);

                if (Directory.Exists(strFullFile))
                {
                    foreach (string strFullFileName in Directory.GetFiles(strFullFile))
                    {
                        if (File.Exists(strFullFileName))
                        {
                            FileInfo objfileinfo = null;
                            objfileinfo = new FileInfo(strFullFileName);
                            string str = string.Empty;
                            str = "New Business_" + strappno+ "_Medical Requirement.pdf";
                            string PushedtoDMS = string.Empty;
                            PushedtoDMS = FTPpathName + "\\FG_Processed_Upload" + "\\" + str;

                            objfileinfo.CopyTo(FTPpathName + "\\" + str, true);
                        }
                    }

                }
                Logger.Error("STAG 5 :PageName :TPA_DMS_Service.CS // MethodeName :FetchImageFromBytes End " + System.Environment.NewLine);
                return true;
            }
            catch (Exception Error)
            {
                CommFun objComm = new CommFun();
                Logger.Error("STAG 5 :PageName :TPA_DMS_Service.CS // MethodeName :FetchImageFromBytes Error :" + System.Environment.NewLine + Error.ToString());
                objComm.SaveErrorLogs(string.Empty, "Failed", "TPA_DMS_Service", "Commfun.cs", "Main", "E-Error", "", "", Error.ToString());
                return false;
            }
        }
        /*
        private void FetchImageFromBytes(TIF objTiff)
        {
            try
            {
                Logger.Error("STAG 5 :PageName :TPA_DMS_Service.CS // MethodeName :FetchImageFromBytes Start " + System.Environment.NewLine);
                //File.WriteAllBytes(Path.Combine(Properties.Settings.Default.DestinationPath, objTiff.FileNameWithTiffExtension), objTiff.bytArrReceive);
                string FTPpathName = Properties.Settings.Default.DestinationPath;
                string FTPUserName = Properties.Settings.Default.UserName;
                string FTPPassword = Properties.Settings.Default.Password;

                // Creating FTP request                
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(FTPpathName + objTiff.FileNameWithTiffExtension);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(FTPUserName, FTPPassword);                
                // Uploading stream on FTP
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(objTiff.bytArrReceive, 0, objTiff.bytArrReceive.Length);
                reqStream.Close();
                Logger.Error("STAG 5 :PageName :TPA_DMS_Service.CS // MethodeName :FetchImageFromBytes End " + System.Environment.NewLine);
            }
            catch (Exception Error)
            {
                CommFun objComm = new CommFun();
                objTiff.Flag = 1;
                objTiff.Message = "FetchImageFromBytes " + Error.Message;
                Logger.Error("STAG 5 :PageName :TPA_DMS_Service.CS // MethodeName :FetchImageFromBytes Error :" + System.Environment.NewLine + Error.ToString());
                objComm.SaveErrorLogs(string.Empty, "Failed", "TPA_DMS_Service", "Commfun.cs", "Main", "E-Error", "", "", Error.ToString());
            }
        }
        */
    }
}