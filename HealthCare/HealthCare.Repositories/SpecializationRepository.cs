﻿using HealthCare.Data.Context;
using HealthCare.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Repositories
{
    public interface ISpecializationRepository : IRepository<Specialization>
    {

    }
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly HealthCareContext _healthCareContext;

        public SpecializationRepository(HealthCareContext healthCareContext)
        {
            _healthCareContext = healthCareContext;
        }

        public async Task<IEnumerable<Specialization>> GetAll()
        {
            return await _healthCareContext.Specializations.ToListAsync();
        }

        public void Save()
        {
            _healthCareContext.SaveChanges();
        }
    }
}
