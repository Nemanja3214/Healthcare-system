﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCare.Data.Context;
using HealthCare.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Repositories {
    public interface IUserRoleRepository : IRepository<UserRole> {

    }
    public class UserRoleRepository : IUserRoleRepository {
        private readonly HealthCareContext _healthCareContext;

        public UserRoleRepository(HealthCareContext healthCareContext) {
            _healthCareContext = healthCareContext;
        }
        public async Task<IEnumerable<UserRole>> GetAll() {
            return await _healthCareContext.UserRoles.ToListAsync();
        }
    }
}
