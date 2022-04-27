﻿using System.Diagnostics.Eventing.Reader;
using HealthCare.Domain.Interfaces;
using HealthCare.Domain.Models;
using HealthCare.Domain.Models.ModelsForCreate;
using HealthCare.Domain.Models.ModelsForUpdate;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase {
        private IPatientService _patientService;

        public PatientController(IPatientService patientService) {
            _patientService = patientService;
        }

        // https://localhost:7195/api/patient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDomainModel>>> GetAll() {
            IEnumerable<PatientDomainModel> patients = await _patientService.GetAll();
            return Ok(patients);
        }
        
        [HttpGet]
        [Route("read")]
        public async Task<ActionResult<IEnumerable<PatientDomainModel>>> ReadAll() {
            IEnumerable<PatientDomainModel> patients = await _patientService.ReadAll();
            return Ok(patients);
        }

        [HttpGet]
        [Route("medical_record/patientId={id}")]
        public async Task<ActionResult<PatientDomainModel>> GetWithMedicalRecord(decimal id)
        {
            PatientDomainModel patient = await _patientService.GetWithMedicalRecord(id);
            return Ok(patient);
        }

        // https://localhost:7195/api/patient/create
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<CreatePatientDomainModel>> CreatePatient([FromBody] CreatePatientDomainModel patientModel)
        {
            var insertedPatientModel = await _patientService.Add(patientModel);
            return Ok(insertedPatientModel);
        }
        
        // https://localhost:7195/api/patient/update
        [HttpPut]
        [Route("update/{id}")]
        public async Task<ActionResult<PatientDomainModel>> UpdatePatient(decimal id, UpdatePatientDomainModel patientModel)
        {
            var updatedPatientModel = await _patientService.Update(patientModel, id);
            return Ok(updatedPatientModel);
        }
        
        // https://localhost:7195/api/patient/delete
        [HttpPut]
        [Route("delete/{id}")]
        public async Task<ActionResult<PatientDomainModel>> DeletePatient(decimal id)
        {
            var deletedPatientModel = await _patientService.Delete(id);
            return Ok(deletedPatientModel);
        }
        
        // https://localhost:7195/api/patient/block
        [HttpPut]
        [Route("block/{id}")]
        public async Task<ActionResult<PatientDomainModel>> BlockPatient(decimal id)
        {
            var blockedPatient = await _patientService.Block(id);
            return Ok(blockedPatient);
        }
        
        [HttpGet]
        [Route("block")]
        public async Task<ActionResult<IEnumerable<PatientDomainModel>>> GetBlockedPatients()
        {
            IEnumerable<PatientDomainModel> blockedPatients = await _patientService.GetBlockedPatients();
            return Ok(blockedPatients);
        }
        
        // https://localhost:7195/api/patient/unblock
        [HttpPut]
        [Route("unblock/{id}")]
        public async Task<ActionResult<PatientDomainModel>> UnblockPatient(decimal id)
        {
            var blockedPatient = await _patientService.Unblock(id);
            return Ok(blockedPatient);
        }
    }
}
