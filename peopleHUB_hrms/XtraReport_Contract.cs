using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace peopleHUB_hrms
{
    public partial class XtraReport_Contract : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_Contract()
        {
            InitializeComponent();
        }

        public static string name = string.Empty;
        public static string date = string.Empty;
        public static string position = string.Empty;
        public static string startDate = string.Empty;
        public static string salaryAmount = string.Empty;


        string noticePeriod = "14 Days";               
        string benefits = "13th month pay, PhilHealth, SSS and Pag-Ibig Fund";
        string workingHours = "8 hours per day, from 8:00 am to 5:00 pm";
        string employer = "Company ABCDEFGHJKLMNOPQRSTUVWXY";

        private void XtraReport_Contract_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            xrRichText1.Text = $@"            
            This agreement is made on {date} between:


            Company: {employer}
            Employee: {name}


            1. Position and Duties  
            The Employee will work as {position} and perform tasks as assigned by the Employer.

            2. Term  
            This contract is effective from {startDate} and may be terminated by either party with {noticePeriod} notice.

            3. Compensation  
            The Employee will be paid {salaryAmount} per month, with salary disbursed on the 15th and 30th 
            (or last day) of each month, and may be eligible for bonuses.

            4. Benefits  
            The Employee is entitled to {benefits}.

            5. Working Hours  
            The Employee will work {workingHours}.

            6. Confidentiality  
            The Employee agrees to maintain confidentiality regarding all company information.

            7. Termination  
            Either party may terminate this contract with {noticePeriod} notice. The Employer may terminate 
            the Employee for misconduct.









            Signatures  

            Employer: _________________________  

            Employee: _________________________
            ";

        }

    }
}
