﻿using HealthCare.Data.Context;
using HealthCare.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Repositories
{
    public interface IDrugIngredientRepository : IRepository<DrugIngredient>
    {
        public DrugIngredient Post(DrugIngredient drugIngredient);
        DrugIngredient Get(decimal id);
        DrugIngredient Update(DrugIngredient drugIngredient);
    }

    public class DrugIngredientRepository : IDrugIngredientRepository
    {
        private readonly HealthCareContext _healthCareContext;

        public DrugIngredientRepository(HealthCareContext healthCareContext)
        {
            _healthCareContext = healthCareContext;
        }

        public DrugIngredient Get(decimal id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DrugIngredient>> GetAll()
        {
            IEnumerable<DrugIngredient> drugIngredients = await _healthCareContext.DrugIngredients.ToListAsync();
            return drugIngredients;
        }

        public DrugIngredient Post(DrugIngredient drugIngredient)
        {
            EntityEntry<DrugIngredient> result = _healthCareContext.DrugIngredients.Add(drugIngredient);
            return result.Entity;
        }

        public void Save()
        {
            _healthCareContext.SaveChanges();
        }

        public DrugIngredient Update(DrugIngredient drugIngredient)
        {
            EntityEntry<DrugIngredient> updatedEntry = _healthCareContext.DrugIngredients.Attach(drugIngredient);
            _healthCareContext.Entry(drugIngredient).State = EntityState.Modified;
            return updatedEntry.Entity;
        }
    }
}
