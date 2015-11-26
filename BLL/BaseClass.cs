using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OAS.BLL
{
    public class BaseClass
    {
        /// <summary>
        /// 根据名称和当前时间，自动生成文件夹
        /// </summary>
        /// <param name="FolderName"></param>
        /// <returns>生成后的文件夹名称</returns>
        //public string CreatFolder(string FolderName)
        //{
        //    //把相对路径转为服务器上的绝对路径,并检查是否存在绝对路径指向的文件或目录
        //    string strTmpPath = "~/" + FolderName + "/";
        //    if (!File.Exists(HttpContext.Current.Server.MapPath(strTmpPath)
        //        + Convert.ToString(DateTime.Today.Year)
        //        + Convert.ToString(DateTime.Today.Month)))
        //    {
        //        //根据当前日期建立绝对路径文件夹
        //        System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(strTmpPath)
        //            + Convert.ToString(DateTime.Today.Year) + Convert.ToString(DateTime.Today.Month));
        //        //返回创建好的文件夹名
        //        return Convert.ToString(DateTime.Today.Year) + Convert.ToString(DateTime.Today.Month);
        //    }
        //    else
        //    {
        //        return Convert.ToString(DateTime.Today.Year) + Convert.ToString(DateTime.Today.Month);
        //    }
        //}

        /// <summary>
        /// 根据生成的文件夹名，上传1张或多张图片
        /// </summary>
        /// <param name="strFolderName"></param>
        /// <param name="objA"></param>
        /// <param name="strCityName"></param>
        /// <param name="strErrImgName"></param>
        /// <param name="intUpLoadNum"></param>
        /// <returns>上传图片后的保存路径</returns>
        //public string UploadImgOneOrLot(string strFolderName, FileUpload objA,
        //       string strCityName, string strErrImgName, int intUpLoadNum)
        //{
        //    //生成保存文件夹
        //    string strSaveFileName = CreatFolder(strFolderName);
        //    //设置路径
        //    string strNewPath = HttpContext.Current.Server.MapPath("~/") 
        //                        + strFolderName + "/" + strSaveFileName + "/";
        //    //如果有图片，上传并获取保存路径
        //    if (objA.HasFile)
        //    {
        //        string strFileName = "";
        //        //如果是上传多张
        //        if (intUpLoadNum != 0)
        //        {
        //            strFileName = strCityName + Convert.ToString(DateTime.Now.Hour) +
        //                          Convert.ToString(DateTime.Now.Minute) + Convert.ToString(DateTime.Now.Second) +
        //                          Convert.ToString(intUpLoadNum) + objA.FileName.Substring(objA.FileName.Length - 4, 4);
        //        }
        //        else
        //        {
        //            strFileName = strCityName + Convert.ToString(DateTime.Now.Hour) +
        //                          Convert.ToString(DateTime.Now.Minute) + Convert.ToString(DateTime.Now.Second) +
        //                          objA.FileName.Substring(objA.FileName.Length - 4, 4);
        //        }
        //        strNewPath += strFileName;
        //        objA.SaveAs(strNewPath);
        //        return "~/" + strFolderName + "/" + strSaveFileName + "/" + strFileName;
        //    }
        //    else
        //    {
        //        return "~/" + strErrImgName;
        //    }
        //}
    }
}
