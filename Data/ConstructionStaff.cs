using System;
using System.Collections.Generic;

namespace MVCTestApp.Data;

public partial class ConstructionStaff
{
    public int StaffId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public string EmploymentStatus { get; set; } = null!;

    public DateOnly? DateOfHire { get; set; }
}
