using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportzMagazine.Models;

namespace SportzMagazine.Catalogs
{
    public class ApplicantCatalog
    {
        private List<Applicant> appList;

        // make a method to create induvidual Applicant
        public IndApplicant CreateIndApplicant(string n, string address, string email, string ph,  string cardH,
            string cardNo, DateTime expDate, int cvv)
        {
            appList = new List<Applicant>();
            IndApplicant app1 = new IndApplicant
            {
                Name = n,
                Address = address,
                Email = email,
                Phone = ph,
                CardHolder = cardH,
                CardNo = cardNo,
                ExpDate = expDate,
                Cvv = cvv
            };

            // the list add the aplicant to intself
            appList.Add(app1);
            return app1;
        }

        //  make a method to create corporate Applicant
        public CorporApplicant CreateCorpApplicant(string n, string address, string email, string ph,  string title,
            string mailStop, string companyDep)
        {
            appList = new List<Applicant>();
            CorporApplicant app2 = new CorporApplicant
            {
                Name = n,
                Address = address,
                Email = email,
                Phone = ph,
                Title = title,
                MailStop = mailStop,
                CompanyDepartment = companyDep
            };
            return app2;
        }

    }
}
