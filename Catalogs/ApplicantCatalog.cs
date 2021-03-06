﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportzMagazine.Models;

namespace SportzMagazine.Catalogs
{
    public class ApplicantCatalog
    {
        private ObservableCollection<Applicant> appList;

        // make a method to create induvidual Applicant
        public IndApplicant CreateIndApplicant(string n, string address, string email, string ph,  string cardH,
            string cardNo, DateTime expDate, int cvv, string password)
        {
            appList = new ObservableCollection<Applicant>();
            IndApplicant app1 = new IndApplicant
            {
                Name = n,
                Address = address,
                Email = email,
                Phone = ph,
                CardHolder = cardH,
                CardNo = cardNo,
                ExpDate = expDate,
                Cvv = cvv,
                Password=password
            };

            // the list add the aplicant to intself
            appList.Add(app1);
            return app1;
        }

        //  make a method to create corporate Applicant
        public CorporApplicant CreateCorpApplicant(string n, string address, string email, string ph,  string title,
            string mailStop, string companyDep, string password)
        {
            appList = new ObservableCollection<Applicant>();
            CorporApplicant app2 = new CorporApplicant
            {
                Name = n,
                Address = address,
                Email = email,
                Phone = ph,
                Title = title,
                MailStop = mailStop,
                CompanyDepartment = companyDep,
                Password=password
            };
            return app2;
        }

    }
}
