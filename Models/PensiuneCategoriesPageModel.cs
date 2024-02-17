
using Microsoft.AspNetCore.Mvc.RazorPages;
using PensiuneaMea.Data;
namespace PensiuneaMea.Models
{
    public class PensiuneCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(PensiuneaMeaContext context, Pensiune pensiune)
        {
            var allCategories = context.Category;
            var pensiuneCategories = new HashSet<int>(
                pensiune.PensiuneCategories.Select(c => c.CategoryID)); // Presupunem că PensiuneCategories este o colecție de legături
            AssignedCategoryDataList = new List<AssignedCategoryData>();

            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = pensiuneCategories.Contains(cat.ID)
                });
            }
        }

        public void UpdatePensiuneCategories(PensiuneaMeaContext context, string[] selectedCategories, Pensiune pensiuneToUpdate)
        {
            if (selectedCategories == null)
            {
                pensiuneToUpdate.PensiuneCategories = new List<PensiuneCategory>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var pensiuneCategories = new HashSet<int>(
                pensiuneToUpdate.PensiuneCategories.Select(c => c.Category.ID));

            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!pensiuneCategories.Contains(cat.ID))
                    {
                        pensiuneToUpdate.PensiuneCategories.Add(new PensiuneCategory
                        {
                            PensiuneID = pensiuneToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (pensiuneCategories.Contains(cat.ID))
                    {
                        PensiuneCategory categoryToRemove = pensiuneToUpdate.PensiuneCategories.SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(categoryToRemove);
                    }
                }
            }
        }
    }
}
