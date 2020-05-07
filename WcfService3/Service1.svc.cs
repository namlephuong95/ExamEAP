﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService3.Models;

namespace WcfService3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public WebServiceDbContext db = new WebServiceDbContext();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public Student GetStudentData(Student student)
        {
            //var student = new Student()
            //{
            //    Name = Name
            //};
            db.Students.Add(student);
            db.SaveChanges();
            return student;
        }

        public Account GetAccount(string code, string pass)
        {
            var account = db.Accounts.Where(p => p.Code == code && p.Password == pass).First();
            return account;
        }

        public string TransferMoney(string sCode, string rCode, double amount)
        {
            var message = "fail";
            var sAcount = db.Accounts.Where(p => p.Code == sCode).FirstOrDefault();
            var rAcount = db.Accounts.Where(p => p.Code == rCode).FirstOrDefault();

            if (sAcount.Money >= amount)
            {
                sAcount.Money -= amount;
                rAcount.Money += amount;

                db.Accounts.AddOrUpdate(sAcount);
                db.Accounts.AddOrUpdate(rAcount);
                message = "success";
            }
            return message;
        }
    }
}
