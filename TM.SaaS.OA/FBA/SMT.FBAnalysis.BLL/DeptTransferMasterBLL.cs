﻿
/*
 * 文件名：DeptTransferMasterBLL.cs
 * 作  用：T_FB_DEPTTRANSFERMASTER 业务逻辑类
 * 创建人：吴鹏
 * 创建时间：2010-12-15 11:47:04
 * 修改人：
 * 修改时间：
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.Objects.DataClasses;
using System.Linq.Dynamic;
using System.Linq.Expressions;

using SMT_FB_EFModel;
using SMT.FBAnalysis.DAL;
using SMT.FBAnalysis.CustomModel;

namespace SMT.FBAnalysis.BLL
{
    public class DeptTransferMasterBLL
    {
        public DeptTransferMasterBLL()
        { }

        #region 获取数据

        /// <summary>
        /// 获取T_FB_DEPTTRANSFERMASTER信息
        /// </summary>
        /// <param name="strDeptTransferMasterId">主键索引</param>
        /// <returns></returns>
        public T_FB_DEPTTRANSFERMASTER GetDeptTransferMasterByID(string strDeptTransferMasterId)
        {
            if (string.IsNullOrEmpty(strDeptTransferMasterId))
            {
                return null;
            }

            DeptTransferMasterDAL dalDeptTransferMaster = new DeptTransferMasterDAL();
            StringBuilder strFilter = new StringBuilder();
            List<string> objArgs = new List<string>();
            
            if (!string.IsNullOrEmpty(strDeptTransferMasterId))
            {
                strFilter.Append(" DEPTTRANSFERMASTERID == @0");
                objArgs.Add(strDeptTransferMasterId);
            }

            T_FB_DEPTTRANSFERMASTER entRd = dalDeptTransferMaster.GetDeptTransferMasterRdByMultSearch(strFilter.ToString(), objArgs.ToArray());
            return entRd;
        }

        /// <summary>
        /// 根据条件，获取T_FB_DEPTTRANSFERMASTER信息
        /// </summary>
        /// <param name="strVacName"></param>
        /// <param name="strVacYear"></param>
        /// <param name="strCountyType"></param>
        /// <param name="strSortKey"></param>
        /// <returns></returns>
        public static IQueryable<T_FB_DEPTTRANSFERMASTER> GetAllDeptTransferMasterRdListByMultSearch(string strFilter, List<object> objArgs, string strSortKey)
        {
            DeptTransferMasterDAL dalDeptTransferMaster = new DeptTransferMasterDAL();
            string strOrderBy = string.Empty;

            if (!string.IsNullOrEmpty(strSortKey))
            {
                strOrderBy = strSortKey;
            }
            else
            {
                strOrderBy = " DEPTTRANSFERMASTERID ";
            }

            var q = dalDeptTransferMaster.GetDeptTransferMasterRdListByMultSearch(strOrderBy, strFilter, objArgs.ToArray());
            return q;
        }

        /// <summary>
        /// 根据条件，获取T_FB_DEPTTRANSFERMASTER信息,并进行分页
        /// </summary>
        /// <param name="strFilter">查询条件</param>
        /// <param name="objArgs">查询参数</param>
        /// <param name="strSortKey">排序字段</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">页码大小</param>
        /// <param name="pageCount">总页数</param>
        /// <returns>T_FB_DEPTTRANSFERMASTER信息</returns>
        public IQueryable<T_FB_DEPTTRANSFERMASTER> GetDeptTransferMasterRdListByMultSearch(string strFilter, List<object> objArgs,
            string strSortKey, int pageIndex, int pageSize, ref int pageCount)
        {
            var q = GetAllDeptTransferMasterRdListByMultSearch(strFilter, objArgs, strSortKey);

            return Utility.Pager<T_FB_DEPTTRANSFERMASTER>(q, pageIndex, pageSize, ref pageCount);
        }

        /// <summary>
        /// 计算批复月度预算(调拨)。
        /// </summary>
        /// <param name="conditions">查询条件对象集。</param>
        /// <returns>返回批复月度预算(调拨)金额。</returns>
        public static IQueryable<V_Money> GetDeptTransfer(ExecutionConditions conditions)
        {
            DeptTransferMasterDAL dalDeptTransferMaster = new DeptTransferMasterDAL();

            return dalDeptTransferMaster.GetDeptTransfer(conditions);
        }
        #endregion

    }
}
