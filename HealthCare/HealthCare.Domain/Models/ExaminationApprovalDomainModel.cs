using HealthCare.Data.Entities;

namespace HealthCare.Domain.Models;

public class ExaminationApprovalDomainModel
{
    public decimal Id { get; set; }
    public string State { get; set; }
    public decimal OldExaminationId { get; set; }
    public decimal NewExaminationId { get; set; }
    public bool isDeleted { get; set; }

    //public ExaminationDomainModel Examination { get; set; }

}