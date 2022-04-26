using HealthCare.Domain.Models;
using HealthCare.Repositories;
using HealthCare.Data.Entities;

namespace HealthCare.Domain.Interfaces;

public class MedicalRecordService : IMedicalRecordService {
    private IMedicalRecordRepository _medicalRecordRepository;

    public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository) {
        _medicalRecordRepository = medicalRecordRepository;
    }

    // Async awaits info from database
    // GetAll is the equivalent of SELECT *
    public async Task<IEnumerable<MedicalRecordDomainModel>> GetAll()
    {
        var data = await _medicalRecordRepository.GetAll();
        if (data == null)
            return null;

        List<MedicalRecordDomainModel> results = new List<MedicalRecordDomainModel>();
        MedicalRecordDomainModel medicalRecordModel;
        foreach (var item in data)
        {
            medicalRecordModel = new MedicalRecordDomainModel
            {
                isDeleted = item.isDeleted,
                Allergies = item.Allergies,
                BedriddenDiseases = item.BedriddenDiseases,
                Height = item.Height,
                PatientId = item.PatientId,
                Weight = item.Weight
            };
            results.Add(medicalRecordModel);
        }

        return results;
    } 

    public async Task<MedicalRecordDomainModel> GetForPatient(decimal id)
    {
        var data =  await _medicalRecordRepository.GetByPatientId(id);

        if (data != null)
        {
            MedicalRecordDomainModel medicalRecordModel = new MedicalRecordDomainModel
            {
                isDeleted = data.isDeleted,
                Allergies = data.Allergies,
                BedriddenDiseases = data.BedriddenDiseases,
                Height = data.Height,
                PatientId = data.PatientId,
                Weight = data.Weight
            };
            return medicalRecordModel;
        } else
        {
            return null; 
        }

        

        
    }

    public async Task<MedicalRecordDomainModel> Update(MedicalRecordDomainModel model)
    {
        MedicalRecord medicalRecord = _medicalRecordRepository.Update(parseFromModel(model));
        _medicalRecordRepository.Save();

        if (medicalRecord != null)
        {
            return parseToModel(medicalRecord);
        } else
        {
            return null;
        }
    }

    private MedicalRecordDomainModel parseToModel(MedicalRecord medicalRecord)
    {
        return new MedicalRecordDomainModel
        {
            Height = medicalRecord.Height,
            Weight = medicalRecord.Weight,
            BedriddenDiseases = medicalRecord.BedriddenDiseases,
            PatientId = medicalRecord.PatientId,
            Allergies = medicalRecord.Allergies,
            isDeleted = medicalRecord.isDeleted
        };
    }

    private MedicalRecord parseFromModel(MedicalRecordDomainModel domainModel)
    {
        return new MedicalRecord
        {
            Height = domainModel.Height,
            Weight = domainModel.Weight,
            BedriddenDiseases =domainModel.BedriddenDiseases,
            PatientId = domainModel.PatientId,
            Allergies = domainModel.Allergies,
            isDeleted = domainModel.isDeleted
        };
    }
}