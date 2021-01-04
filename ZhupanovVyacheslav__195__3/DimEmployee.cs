namespace ZhupanovVyacheslav__195__3
{
    public class DimEmployee : DimLine
    {
        public int EmployeeKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string BirthDate { get; set; }
        public string LoginID { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public byte PayFrequency { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public string DepartmentName { get; set; }
        public string StartDate { get; set; }

        public override string GetName => "DimEmployee";

        public override int GetKey => EmployeeKey;

        public DimEmployee(int employeeKey, string firstName, string lastName, string title, string birthDate, string loginID,
            string emailAddress, string phone, string maritalStatus, string gender, byte payFrequency, short vacationHours,
            short sickLeaveHours, string departmentName, string startDate)
        {
            EmailAddress = emailAddress;
            EmployeeKey = employeeKey;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            BirthDate = birthDate;
            LoginID = loginID;
            Phone = phone;
            MaritalStatus = maritalStatus;
            Gender = gender;
            PayFrequency = payFrequency;
            VacationHours = vacationHours;
            SickLeaveHours = sickLeaveHours;
            DepartmentName = departmentName;
            StartDate = startDate;
        }
    }
}
