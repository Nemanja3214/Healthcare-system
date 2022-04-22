using HealthCare.Domain.Models;
using HealthCare.Domain.Models.ModelsForCreate;
using HealthCare.Domain.Models.ModelsForUpdate;

namespace HealthCare.Domain.Interfaces;

public interface IExaminationService : IService<ExaminationDomainModel> {
    public Task<IEnumerable<ExaminationDomainModel>> GetAllForPatient(decimal id);
    public Task<ExaminationDomainModel> Delete(DeleteExaminationDomainModel updateExamination);
    public Task<CreateExaminationDomainModel> Create(CreateExaminationDomainModel examinationModel);
    public Task<UpdateExaminationDomainModel> Update(UpdateExaminationDomainModel examinationModel);


}