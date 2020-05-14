﻿using HranaLibrary.Models;
using System.Collections.Generic;


namespace HranaLibrary.Services
{
    public interface IRecipeService1
    {
        bool UpdateRecipe(int id, Recipe value);
        bool AddRecipe(Recipe value);
        Recipe GetRecipe(int id);
        IEnumerable<Recipe> GetRecipes();
    }
}


