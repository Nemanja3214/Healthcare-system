﻿using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using HealthCare.Domain.Interfaces;
using HealthCare.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        [Route("schedule/doctorId={id}/{date}")]
        public async Task<ActionResult<IEnumerable<AppointmentDomainModel>>> GetDoctorsSchedule(decimal id, DateTime date)
        {
            IEnumerable<AppointmentDomainModel> appointments = await _appointmentService.GetAllForDoctor(id, date);
            if (appointments == null)
            {
                appointments = new List<AppointmentDomainModel>();
            }
            return Ok(appointments);
        }
    }
}
