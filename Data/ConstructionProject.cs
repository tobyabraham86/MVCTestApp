using System;
using System.Collections.Generic;

namespace MVCTestApp.Data;

public partial class ConstructionProject
{
    public int Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public string ProjectDetails { get; set; } = null!;

    public string ProjectLocation { get; set; } = null!;

    public string ProjectStatus { get; set; } = null!;

    public DateOnly? ProjectDateCompletion { get; set; }
}
