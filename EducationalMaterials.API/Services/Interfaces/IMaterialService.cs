﻿namespace EducationalMaterials.API.Services.Interfaces
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialDisplayDto>> GetAllAsync();
    }
}
