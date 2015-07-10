using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KempsTuroTuro.Data.Domain;
using KempsTuroTuro.Data.Interface;

namespace KempsTuroTuro.Data.Repository
{
    public class RecipeRepository : RepositoryBase<Recipe, int>, IRecipeRepository
    {
        public RecipeRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }


    }

    public interface IRecipeRepository : IRepository<Recipe, int>
    {
        
    }
}
