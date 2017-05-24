using HtmlAgilityPack;

namespace HackatonBot.EmployeeBot.Infrastructure
{
    public class PeopleHr
    {

        public class Rootobject
        {
            public bool isError { get; set; }
            public int Status { get; set; }
            public string Message { get; set; }
            public Result Result { get; set; }
        }

        public class Result
        {
            public Employeeid EmployeeId { get; set; }
            public Title Title { get; set; }
            public Firstname FirstName { get; set; }
            public Lastname LastName { get; set; }
            public Othername OtherName { get; set; }
            public Knownas KnownAs { get; set; }
            public Emailid EmailId { get; set; }
            public Startdate StartDate { get; set; }
            public Dateofbirth DateOfBirth { get; set; }
            public Jobrole JobRole { get; set; }
            public Company Company { get; set; }
            public Companyeffectivedate CompanyEffectiveDate { get; set; }
            public Location Location { get; set; }
            public Locationeffectivedate LocationEffectiveDate { get; set; }
            public Department Department { get; set; }
            public Departmenteffectivedate DepartmentEffectiveDate { get; set; }
            public Jobrolechangedate JobRoleChangeDate { get; set; }
            public Reportsto ReportsTo { get; set; }
            public Reportstoeffectivedate ReportsToEffectiveDate { get; set; }
            public Reportstoemployeeid ReportsToEmployeeId { get; set; }
            public Reportstoemailaddress ReportsToEmailAddress { get; set; }
            public Nisnumber NISNumber { get; set; }
            public Nationality Nationality { get; set; }
            public Employmenttype EmploymentType { get; set; }
            public Employmenttypeeffectivedate EmploymentTypeEffectiveDate { get; set; }
            public Employeestatus EmployeeStatus { get; set; }
            public Holidayallowancedays HolidayAllowanceDays { get; set; }
            public Holidayallowancemins HolidayAllowanceMins { get; set; }
            public Noticeperiod NoticePeriod { get; set; }
            public Probationenddate ProbationEndDate { get; set; }
            public Gender Gender { get; set; }
            public Contactdetail ContactDetail { get; set; }
            public object[] OtherContact { get; set; }
            public object[] RightToWork { get; set; }
            public object[] BackgroundDetail { get; set; }
            public Bankdetail BankDetail { get; set; }
            public Employmentdetail EmploymentDetail { get; set; }
            public string LeavingDate { get; set; }
            public string ReasonForLeaving { get; set; }
            public string EmployeeImage { get; set; }
            public string APIColumn1 { get; set; }
            public string APIColumn2 { get; set; }
            public string APIColumn3 { get; set; }
            public string APIColumn4 { get; set; }
            public string APIColumn5 { get; set; }
            public object lstFieldHistoryJobrole { get; set; }
        }

        public class Employeeid
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Title
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Firstname
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Lastname
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Othername
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Knownas
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Emailid
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Startdate
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Dateofbirth
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Jobrole
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistoryForJobRole { get; set; }
        }

        public class Company
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistoryForEffectiveDate { get; set; }
        }

        public class Companyeffectivedate
        {
            public string DisplayValue { get; set; }
        }

        public class Location
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistoryForEffectiveDate { get; set; }
        }

        public class Locationeffectivedate
        {
            public string DisplayValue { get; set; }
        }

        public class Department
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistoryForEffectiveDate { get; set; }
        }

        public class Departmenteffectivedate
        {
            public string DisplayValue { get; set; }
        }

        public class Jobrolechangedate
        {
            public string DisplayValue { get; set; }
        }

        public class Reportsto
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistoryForEffectiveDate { get; set; }
        }

        public class Reportstoeffectivedate
        {
            public string DisplayValue { get; set; }
        }

        public class Reportstoemployeeid
        {
            public string DisplayValue { get; set; }
        }

        public class Reportstoemailaddress
        {
            public string DisplayValue { get; set; }
        }

        public class Nisnumber
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Nationality
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Employmenttype
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistoryForEffectiveDate { get; set; }
        }

        public class Employmenttypeeffectivedate
        {
            public string DisplayValue { get; set; }
        }

        public class Employeestatus
        {
            public string DisplayValue { get; set; }
        }

        public class Holidayallowancedays
        {
            public string DisplayValue { get; set; }
        }

        public class Holidayallowancemins
        {
            public string DisplayValue { get; set; }
        }

        public class Noticeperiod
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Probationenddate
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Gender
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Contactdetail
        {
            public Address Address { get; set; }
            public Workphonenumber WorkPhoneNumber { get; set; }
            public Personalphonenumber PersonalPhoneNumber { get; set; }
            public Personalemail PersonalEmail { get; set; }
            public Mobile Mobile { get; set; }
        }

        public class Address
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Workphonenumber
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Personalphonenumber
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Personalemail
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Mobile
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Bankdetail
        {
            public Bankname BankName { get; set; }
            public Bankaddress BankAddress { get; set; }
            public Bankcode BankCode { get; set; }
            public Accountnumber AccountNumber { get; set; }
            public Accountname AccountName { get; set; }
        }

        public class Bankname
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Bankaddress
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Bankcode
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Accountnumber
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Accountname
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Employmentdetail
        {
            public Payrollcompany PayrollCompany { get; set; }
            public Payrollid PayrollID { get; set; }
            public Timeandattendanceid TimeAndAttendanceID { get; set; }
            public Rotaid RotaID { get; set; }
            public CRMID CRMID { get; set; }
            public ATSID ATSID { get; set; }
            public Performanceid PerformanceID { get; set; }
            public Benefitsid BenefitsID { get; set; }
            public System1id System1ID { get; set; }
            public System2id System2ID { get; set; }
            public System3id System3ID { get; set; }
            public Methodofrecruitment MethodOfRecruitment { get; set; }
        }

        public class Payrollcompany
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Payrollid
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Timeandattendanceid
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Rotaid
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class CRMID
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class ATSID
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Performanceid
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Benefitsid
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class System1id
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class System2id
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class System3id
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

        public class Methodofrecruitment
        {
            public string DisplayValue { get; set; }
            public object[] FieldHistory { get; set; }
        }

    }
}