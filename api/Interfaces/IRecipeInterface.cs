using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Recipes;
using api.Services;
using api.Repository;

namespace api.Interfaces
{
    public interface IRecipeInterface
    {
        Task<ComplexSearchResponseDto?> GetRecipesAsync(string query, int number);
        Task<RandomSearchResponseDto?> GetRandomRecipeAsync(int number);
    }
}