﻿using System;
using System.Net;
using System.Collections.Generic;
using SMT.HRM.CustomModel;
using TM_SaaS_OA_EFModel;

namespace SMT.HRM.BLL
{
    public class LoginUser
    {
        public LoginUser()
        {
            
            CustomPerms = new List<T_SYS_ENTITYMENUCUSTOMPERM>();
            EntityMenu = new List<T_SYS_ENTITYMENU>();
            UserInfo = new T_SYS_USER();
            UserLoginRecord = new T_SYS_USERLOGINRECORD();
        }
        public T_SYS_USER UserInfo { get; set; }
        public List<SMT.SaaS.Permission.DAL.V_Permission> PermissionInfo { get; set; }
        public V_EMPLOYEEPOST EmployeeInfo { get; set; }
        public List<T_SYS_ENTITYMENUCUSTOMPERM> CustomPerms { get; set; }
        public T_SYS_USERLOGINRECORD UserLoginRecord { get; set; }
        public List<T_SYS_ENTITYMENU> EntityMenu { get; set; }
        private T_HR_POST currentLoginPost;

        public T_HR_POST CurrentLoginPost
        {
            get
            {
                if (currentLoginPost == null)
                {
                    if (EmployeeInfo != null && EmployeeInfo.EMPLOYEEPOSTS != null)
                    {
                        currentLoginPost = EmployeeInfo.EMPLOYEEPOSTS[0].T_HR_POST;
                    }
                }
                return currentLoginPost;
            }
            set { currentLoginPost = value; }
        }
    }
}