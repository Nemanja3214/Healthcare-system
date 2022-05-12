﻿using System.Diagnostics.Eventing.Reader;
using HealthCare.Domain.DataTransferObjects;
using HealthCare.Domain.DTOs;
using HealthCare.Domain.Interfaces;
using HealthCare.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareAPI.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExaminationController : ControllerBase 
    {
        private IExaminationService _examinationService;
        private IDoctorService _doctorService;
        private IPatientService _patientService;

        public ExaminationController(IExaminationService examinationService, IDoctorService doctorService, IPatientService patientService) 
        {
            _examinationService = examinationService;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        // https://localhost:7195/api/examination
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExaminationDomainModel>>> GetAll() 
        {
            IEnumerable<ExaminationDomainModel> examinations = await _examinationService.GetAll();
            return Ok(examinations);
        }
        
        [HttpGet]
        [Route("read")]
        public async Task<ActionResult<IEnumerable<ExaminationDomainModel>>> ReadAll() 
        {
            IEnumerable<ExaminationDomainModel> examinations = await _examinationService.ReadAll();
            return Ok(examinations);
        }

        // https://localhost:7195/api/examination/patientId=___
        [HttpGet]
        [Route("patientId={id}")]
        public async Task<ActionResult<IEnumerable<ExaminationDomainModel>>> GetAllForPatient(decimal id) 
        {
            IEnumerable<ExaminationDomainModel> examinations = await _examinationService.GetAllForPatient(id);
            if (examinations == null) {
                examinations = new List<ExaminationDomainModel>();
            }
            return Ok(examinations);
        }

        // https://localhost:7195/api/examination/sort/
        [HttpGet]
        [Route("sort")]
        public async Task<ActionResult<IEnumerable<ExaminationDomainModel>>> GetAllForPatientSorted([FromBody] SortExaminationDTO dto)
        {
            IEnumerable<ExaminationDomainModel> examinations = await _examinationService.GetAllForPatientSorted(dto, _doctorService);
            if (examinations == null)
            {
                examinations = new List<ExaminationDomainModel>();
            }
            return Ok(examinations);
        }

        [HttpGet]
        [Route("doctorId={id}")]
        public async Task<ActionResult<IEnumerable<ExaminationDomainModel>>> GetAllForDoctor(decimal id)
        {
            IEnumerable<ExaminationDomainModel> examinations = await _examinationService.GetAllForDoctor(id);
            if (examinations == null)
            {
                examinations = new List<ExaminationDomainModel>();
            }
            return Ok(examinations);
        }

        // https://localhost:7195/api/examination/delete
        [HttpPut]
        [Route("delete")]
        public async Task<ActionResult<ExaminationDomainModel>> DeleteExamination([FromBody] DeleteExaminationDTO dto) 
        {
            try
            {
                ExaminationDomainModel deletedExaminationModel = await _examinationService.Delete(dto);
                return Ok(deletedExaminationModel);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ExaminationDomainModel>> CreateExamination([FromBody] CUExaminationDTO dto) 
        {
            try
            {
                ExaminationDomainModel createdExaminationModel = await _examinationService.Create(dto);
                return Ok(createdExaminationModel);
            }
            catch(Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<CUExaminationDTO>> UpdateExamination([FromBody] CUExaminationDTO dto) 
        {
            try
            {
                ExaminationDomainModel updatedExaminationModel = await _examinationService.Update(dto);
                return Ok(updatedExaminationModel);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }

        }

        [HttpPost]
        [Route("recommend")]
        public async Task<ActionResult<IEnumerable<CUExaminationDTO>>> RecommendExaminations([FromBody] ParamsForRecommendingFreeExaminationsDTO paramsDTO)
        {
            try
            {
                IEnumerable<CUExaminationDTO> recommendedExaminations = await _examinationService.GetRecommendedExaminations(paramsDTO, _doctorService);
                return Ok(recommendedExaminations);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }


        // https://localhost:7195/api/examination/search
        [HttpGet]
        [Route("search/patientId={id}/substring={substring}")]
        public async Task<ActionResult<IEnumerable<ExaminationDomainModel>>> GetByName(SearchByNameDTO dto)
        {
            try
            {
                IEnumerable<ExaminationDomainModel> examinations = await _examinationService.SearchByAnamnesis(dto);
                return Ok(examinations);

            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPut]
        [Route("urgent")]
        public async Task<ActionResult<IEnumerable<ExaminationDomainModel>>> CreateUrgentExamination(CreateUrgentExaminationDTO dto)
        {
            List<ExaminationDomainModel> operationModels =
                (List<ExaminationDomainModel>) await _examinationService.CreateUrgent(dto, _doctorService, _patientService);
            if (operationModels.Count == 0) return Ok();
            return operationModels;
        }

    }
}
