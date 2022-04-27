using HealthCare.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Domain.Interfaces;

public interface IEquipmentService : IService<EquipmentDomainModel>
{
    Task<IEnumerable<EquipmentDomainModel>> SearchByName(string nameAlike);
    Task<IEnumerable<EquipmentDomainModel>> Filter(decimal equipmentTypeId, int minAmmount, int maxAmmount, decimal roomTypeId);
    Task<Tuple<EquipmentDomainModel, EquipmentDomainModel>> Transfer(decimal roomIdIn, decimal roomIdOut, decimal equipmentID, decimal amount);
    public Task<IEnumerable<EquipmentDomainModel>> ReadAll();
}